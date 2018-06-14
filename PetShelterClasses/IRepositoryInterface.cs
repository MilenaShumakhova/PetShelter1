using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    public interface IRepositoryInterface
    {
         List<User> Users { get; set; }
         List<Pet> Pets { get; set; }
         List<UsersPets> UsersPets { get; set; }
         List<Pet> ExpectedPets { get; set; }
         List<GetterRequests> GetterRequests { get; set; }

        void RestorePets();
        void RestoreRequests();
        void RestoreExpectedPets(User Us);
        User ToCreateNewPerson(string name, string pass, string log, string city, string address, string phone);
        void ToRegistrate(User us);
        bool ToCompare(string email);
        void ToCreateUsersPet(Pet pet, string description, User us, DateTime? sd, DateTime? ed, double p);
        void ToCreateExpectedPets(List<Pet> pets, User us, DateTime? sd, DateTime? ed, double p);
        List<User> ToCreateUsersList(Pet pet, string description, DateTime? sd, DateTime? ed, double p, User user);
        void ChangeMainInformation(User user, string name, string email, string city, string phone, string address, string password);
        void ToAddRequest(User user, User ThisUser, Pet pet, string description, DateTime? sd, DateTime? ed);
        List<GetterRequests> ToReturnListWithRequestsFromMe(User ThisUser);
        void RemoveGetterRequest(GetterRequests requests);
        List<GetterRequests> ToGetRequestsToMe(User user);
        void ChangeStatusToAccept(GetterRequests g);
        void ChangeStatusToDecline(GetterRequests g);

    }
}
