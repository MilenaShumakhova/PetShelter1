﻿using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public class RepositoryDB:IRepositoryInterface
    {
        public List<User> Users { get; set; }
        public List<Pet> Pets { get; set; }
        public List<UsersPets> UsersPets { get; set; }
        public List<Pet> ExpectedPets { get; set; }
        public List<GetterRequests> GetterRequests { get; set; }

        public RepositoryDB()
        {
            RestoreUsers();
        }

        Context context = new Context();

        private void RestoreUsers()
        {
            try
            {
                Users = (from us in context.Users
                         select us).ToList();
            }
            catch
            {
                Users = new List<User>();
            }

        }
        public void RestorePets()
        {
            try
            {
                Pets = (from p in context.Pets
                        select p).ToList();

            }
            catch
            {
                Pets = new List<Pet>();

            }

        }
        public void RestoreRequests()
        {
            try
            {
                UsersPets = (from usp in context.UsersPets
                             select usp).ToList();
                GetterRequests = (from g in context.GetterRequests
                                  select g).ToList();
            }
            catch
            {
                UsersPets = new List<UsersPets>();
                GetterRequests = new List<GetterRequests>();
            }

        }
        public void RestoreExpectedPets(User Us)
        {
            try
            {
                List<Pet> FirstPets;
                List<Pet> SecondPents = new List<Pet>();
                FirstPets = context.Pets.Include(p => p.Users).ToList();
                for (int i = 0; i < FirstPets.Count; i++)
                {
                    if (FirstPets[i].Users.Count != 0)
                        SecondPents.Add(FirstPets[i]);
                }
                Us.ExpectedPets = new List<Pet>();
                foreach (var pp in SecondPents)
                {
                    foreach (var usp in pp.Users)
                    {
                        if (usp.ID == Us.ID)
                        {
                            Us.ExpectedPets.Add(pp);
                        }
                    }
                }
            }
            catch
            {
                Us.ExpectedPets = new List<Pet>();

            }
        }


        public User ToCreateNewPerson(string name, string pass, string log, string city, string address, string phone)
        {
            User u = new User()
            {
                NameSurname = name,
                Password = pass,
                Email = log,
                City = city,
                Address = address,
                Phone = phone,
            };
            return u;
        }

        public void ToRegistrate(User us)  
        {
            context.Users.Add(us);
            context.SaveChanges();
        }

        public bool ToCompare(string email)
        {
            bool m = Users.All(us => us.Email != email);
            return m;
        }

        public void ToCreateUsersPet(Pet pet, string description, User us, DateTime? sd, DateTime? ed, double p)
        {

            UsersPets uspet = new UsersPets()
            {
                Pet = pet,
                Description = description,
                User = us,
                Payment = p,
                Start = sd,
                End = ed,
            };
            if (us.MyPets == null)
            {
                us.MyPets = new List<UsersPets>();
                us.MyPets.Add(uspet);
                context.UsersPets.Add(uspet);
                context.SaveChanges();
            }
            else
            {
                us.MyPets.Add(uspet);
                context.UsersPets.Add(uspet);
                context.SaveChanges();
            }
        }

        public void ToCreateExpectedPets(List<Pet> pets, User us, DateTime? sd, DateTime? ed, double p)
        {
            RestoreExpectedPets(us);
            if (us.ExpectedPets == null)
            {
                us.ExpectedPets = new List<Pet>();
                us.ExpectedPets.AddRange(pets);
                us.StartGetter = sd;
                us.EndGetter = ed;
                us.PaymentGetter = p;
            }
            else
            {
                us.ExpectedPets.Clear();
                us.ExpectedPets.AddRange(pets);
                us.StartGetter = sd;
                us.EndGetter = ed;
                us.PaymentGetter = p;
            }
            context.SaveChanges();
        }

        public List<User> ToCreateUsersList(Pet pet, string description, DateTime? sd, DateTime? ed, double p, User user)//(User user,Pet pet, string description,double p)
        {

            List<User> Us = new List<User>();
            List<User> NeedableUs = new List<User>();
            DateTime s = (DateTime)sd;
            DateTime end = (DateTime)ed;
            Us.AddRange(context.Users.Where(us => us.ID != user.ID && us.City == user.City && s.CompareTo((DateTime)us.StartGetter) >= 0 && end.CompareTo((DateTime)us.EndGetter) <= 0 && us.PaymentGetter <= p));
            foreach (var us in Us)
            {

                RestoreExpectedPets(us);

                foreach (var usp in us.ExpectedPets)
                {

                    if (pet == usp)
                    {

                        NeedableUs.Add(us);
                    }
                }
            }

            return NeedableUs;
        }

        public void ChangeMainInformation(User user, string name, string email, string city, string phone, string address, string password)
        {
            user.NameSurname = name;
            user.Email = email;
            user.City = city;
            user.Phone = phone;
            user.Address = address;
            user.Password = user.GetHash(password);
            context.SaveChanges();
        }

        public void ToAddRequest(User user, User ThisUser, Pet pet, string description, DateTime? sd, DateTime? ed)
        {
            UsersPets needpet = context.UsersPets.FirstOrDefault(p => p.User.ID == ThisUser.ID && p.Description == description && p.Pet.ID == pet.ID && p.Start == sd && p.End == ed);
            GetterRequests g = new GetterRequests()
            {
                Request = needpet,
                User = user,
                StatusGiver= "Waiting answer!",
                StatusGetter="This is a new request!"

            };
            if (user.GetterRequests == null)
            {
                user.GetterRequests = new List<GetterRequests>();
                user.GetterRequests.Add(g);
                context.GetterRequests.Add(g);
                context.SaveChanges();
            }
            else
            {
                user.GetterRequests.Add(g);
                context.GetterRequests.Add(g);
                context.SaveChanges();
            }
        }
        public List<GetterRequests> ToReturnListWithRequestsFromMe(User ThisUser) 
        {
            RestoreRequests();
            List<GetterRequests> getterRequests = new List<GetterRequests>();
            getterRequests = GetterRequests.FindAll(g => g.Request.User.ID == ThisUser.ID);
            return getterRequests;
        }
        public void RemoveGetterRequest(GetterRequests requests)
        {
            List<GetterRequests> getters = new List<GetterRequests>();
            foreach (var g in GetterRequests)
            {
                if (g.Request.ID == requests.Request.ID)
                {
                    getters.Add(g);
                }
            }
            if (getters.Count == 1)
            {
                Mark mark=context.Marks.FirstOrDefault(m => m.IRequest.ID == requests.ID);
                if (mark != null)
                {
                    mark.IRequest = null;
                }
                context.UsersPets.Remove(requests.Request);
                context.GetterRequests.Remove(requests);
                context.SaveChanges();
            }
            else
            {
                Mark mark = context.Marks.FirstOrDefault(m => m.IRequest.ID == requests.ID);
                if (mark != null)
                {
                    mark.IRequest = null;
                }
                context.GetterRequests.Remove(requests);
                context.SaveChanges();
            }
            RestoreRequests();

        }
        public List<GetterRequests> ToGetRequestsToMe(User user)  
        {
            if (user.GetterRequests != null)
            {
              return   user.GetterRequests.FindAll(g => g.User.ID == user.ID&&(g.StatusGiver== "Waiting answer!" || g.StatusGiver== "This is a new request!"));
            }
            else
            {
                List<GetterRequests> requests = new List<GetterRequests>();
                return requests;
            }
        }

        public void ChangeStatusToAccept(GetterRequests g)
        {
            GetterRequests gr = context.GetterRequests.FirstOrDefault(gg => gg.ID == g.ID);
            gr.StatusGiver = "Your request has been accepted!";
            gr.StatusGetter = "You made a request. Wait for an answer!";
            context.SaveChanges();
        }
        public void ChangeStatusToDecline(GetterRequests g) 
        {
            GetterRequests gr = context.GetterRequests.FirstOrDefault(gg => gg.ID == g.ID);
            gr.StatusGiver = "Your request was rejected";
            context.SaveChanges();
        }

        public void AddGrade(double v, User user, GetterRequests g)
        {
            Mark usermark = new Mark()
            {
                RatedUser =user,
                Grade = v,
                IRequest=g,
            };
            context.Marks.Add(usermark);
            context.SaveChanges();
            List<Mark> marks = (context.Marks.Where(m => m.RatedUser.ID == user.ID)).ToList();
            double sum = 0;
            for (int i = 0; i < marks.Count; i++)
            {
                sum += marks[i].Grade;
            }
            double r = sum / marks.Count;
            user.Rating = r;
            context.SaveChanges();
        }
    }
   
}   

