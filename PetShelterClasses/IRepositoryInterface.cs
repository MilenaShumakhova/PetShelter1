using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShelterClasses
{
    interface IRepositoryInterface
    {
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
