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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        User ThisUser;
        Context context;
        IRepositoryInterface rep;
        public Page2(User us,IRepositoryInterface repo,Context cont)
        {
            ThisUser = us;
            context = cont;
            rep = repo;
            InitializeComponent();
            ExpectedPets.ItemsSource = rep.Pets;
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.textBlock1.Text = msg;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Pet> pets = new List<Pet>();
            for (int i = 0; i <ExpectedPets.SelectedItems.Count; i++)
            {
                Pet pet = ExpectedPets.SelectedItems[i] as Pet;
                pets.Add(pet);
            }
            if (pets.Count == 0)
            {
                MessageBox.Show("You should choose pets!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
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
                        double p = Slider1.Value;
                        rep.ToCreateExpectedPets(pets, ThisUser, sd, ed, p);
                        MessageBox.Show("Your request has been accepted!", "", MessageBoxButton.OK);
                    }

                }
            }
        }
    }
}
