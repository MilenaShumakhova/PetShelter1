using PetShelterClasses;
using PetShelterClasses.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Team
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        User ThisUser;
        RepositoryDB rep;
        Context context;
        public Page1(User us,RepositoryDB repo,Context cont)
        {
            ThisUser = us;
            rep = repo;
            context = cont;
            InitializeComponent();
            ChoosePet.ItemsSource = repo.Pets;
          
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Pet pet = ChoosePet.SelectedItem as Pet;
            string description = Description.Text;
            DateTime? sd = DateFrom.SelectedDate;
            DateTime? ed = DateEnd.SelectedDate;
            double p =Slider1.Value;
            rep.ToCreateUsersPet(pet, description, ThisUser,sd,ed,p);
            List<User> Us = new List<User>();
            List<User> NeedableUs = new List<User>();
            Us.AddRange(context.Users.Where(us => us.ID!=ThisUser.ID&&us.City == ThisUser.City && us.StartGetter <= ThisUser.StartGiver && us.EndGetter >= ThisUser.EndGiver && us.PaymentGetter <= ThisUser.PaymentGiver));
            foreach (var us in Us)
            {
                rep.RestoreExpectedPets(us);
                foreach (var usp in us.ExpectedPets)
                {
                    foreach (var tp in ThisUser.MyPets)
                    {
                        if (tp.Pet == usp)
                        {
                            NeedableUs.Add(us);
                        }
                    }
                }
            }
            //var Users = (from us in Us
            //   from usp in us.ExpectedPets
            //   from up in ThisUser.MyPets
            //   where usp == up.Pet
            //   select us).ToList();
            //NeedableUs.AddRange(Users);
            NeedableUsers.ItemsSource = NeedableUs;
        }



        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.textBlock1.Text = msg;
        }

        
    }
}
