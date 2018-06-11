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
    public class RepositoryDB
    {
        public List<User> Users { get; set; }
        public List<Pet> Pets { get; set; }
        public List<UsersPets> UsersPets { get; set; }
        public List<Pet> ExpectedPets { get; set; }

        public RepositoryDB()
        {
            RestoreUsers();
        }

        Context context = new Context();

        public void RestoreUsers()
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
                UsersPets = (from usp in context.UsersPets
                             select usp).ToList();
            }
            catch
            {
                Pets = new List<Pet>();
                UsersPets = new List<UsersPets>();
            }

        }
        public void RestoreExpectedPets(User Us)
        {
            List<Pet> FirstPets;
            List<Pet> SecondPents = new List<Pet>();
            Us.ExpectedPets = new List<Pet>();
            FirstPets= context.Pets.Include(p => p.Users).ToList();
            for (int i = 0; i < FirstPets.Count; i++)
            {
                if (FirstPets[i].Users.Count != 0)
                    SecondPents.Add(FirstPets[i]);
            }
            foreach(var pp in SecondPents)
            {
                foreach(var usp in pp.Users)
                {
                    if(usp.ID==Us.ID)
                    {
                       Us.ExpectedPets.Add(pp);
                    }
                }
            }


            //}
            //catch
            //{
            //    ExpectedPets = new List<Pet>();

            //}
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
                Payment=p,
                Start=sd,
                End=ed,
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
                us.ExpectedPets.AddRange(pets);
                us.StartGetter = sd;
                us.EndGetter = ed;
                us.PaymentGetter = p;
            }
            context.SaveChanges();
        }
    }    
}
