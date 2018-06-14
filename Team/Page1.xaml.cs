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
        IRepositoryInterface rep;
        Context context;
        public Page1(User us,IRepositoryInterface repo,Context cont)
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
            if(pet==null)
            {
                MessageBox.Show("You should choose a pet!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string description = Description.Text;
            double p = Slider1.Value;
            DateTime? sd = DateFrom.SelectedDate;
            DateTime? ed = DateEnd.SelectedDate;
            if (sd == null || ed == null)
            {
                MessageBox.Show("You have entered an incorrect date!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                DateTime sd2 = (DateTime)sd;
                DateTime ed2 = (DateTime)ed;
                if (sd2.CompareTo(ed2) == 1)
                {
                    MessageBox.Show("You have entered an incorrect date!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                        var NeedableUs = rep.ToCreateUsersList(pet, description, sd, ed, p, ThisUser);
                        NeedableUsers.ItemsSource = NeedableUs;
                }
            }
        }
        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.textBlock1.Text = msg;
        }

        private void Button_Click_Choose(object sender, RoutedEventArgs e)
        {
            if(NeedableUsers.SelectedItem==null)
            {
                MessageBox.Show("Please, choose a getter!");
            }
            else
            {
                Pet pet = ChoosePet.SelectedItem as Pet;
                string description = Description.Text;
                double p = Slider1.Value;
                DateTime? sd = DateFrom.SelectedDate;
                DateTime? ed = DateEnd.SelectedDate;
                User user = NeedableUsers.SelectedItem as User;
                var getterRequests=rep.ToReturnListWithRequestsFromMe(ThisUser);
                if(getterRequests.Exists(up=>up.Request.Pet.ID==pet.ID&&up.Request.Description==description&&up.Request.Start==sd&&up.Request.End==ed))
                {
                    var request=getterRequests.FirstOrDefault(up => up.Request.Pet.ID == pet.ID && up.Request.Description == description && up.Request.Start == sd && up.Request.End == ed);
                    if (request.User.ID == user.ID)
                    {
                        MessageBox.Show("You have already sent this request to this user!", "Oops", MessageBoxButton.OK);
                    }
                    else
                    {
                        rep.ToAddRequest(user, ThisUser, pet, description, sd, ed);
                        MessageBox.Show("Your request was sent");
                    }
                }
                else
                {
                    rep.ToCreateUsersPet(pet, description, ThisUser, sd, ed, p);
                    rep.ToAddRequest(user, ThisUser, pet, description, sd, ed);
                    MessageBox.Show("Your request was sent");
                }
            }
            
        }
    }
}
