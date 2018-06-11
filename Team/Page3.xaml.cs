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
            textBoxFullName.Text = us.NameSurname;
            textBoxEmail.Text = us.Email;
            textBoxCity.Text = us.City;
            textBoxPhone.Text = us.Phone;
            textBoxAddress.Text = us.Address;
            PasswordBoxPasswordRegistration.Password = us.Password;
        }
    }
}
