using PetShelterClasses;
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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        User ThisUser;
        RepositoryDB rep;
        Context context;
        public Page3(User us, RepositoryDB repo, Context cont)
        {
            ThisUser = us;
            context = cont;
            rep = repo;
            InitializeComponent();
            TextBoxFullName.Text = us.NameSurname;
            TextBoxEmail.Text = us.Email;
            TextBoxCity.Text = us.City;
            TextBoxPhone.Text = us.Phone;
            TextBoxAddress.Text = us.Address;
            PasswordRegistration.Password = us.Password;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxFullName.Text;
            string email = TextBoxEmail.Text;
            string city = TextBoxCity.Text;
            string phone = TextBoxPhone.Text;
            string address = TextBoxAddress.Text;
            string password = PasswordRegistration.Password;
            rep.ChangeMainInformation(ThisUser, name, email, city, phone, address, password);
           
           
        }

        
      
    }
}
