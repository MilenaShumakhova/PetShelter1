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
using System.Windows.Shapes;

namespace Team
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        Context c;
        User us = new User();
        public User ThisUser = new User();
        public RepositoryDB repo { get; set; }

        public RegistrationWindow(RepositoryDB r, Context context)
        {
            InitializeComponent();
            textBoxFullName.Focus();
            repo = r;
            c = context;
        }

        private void Button_ClickBACK(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            string name = textBoxFullName.Text;
            string email = textBoxEmail.Text;
            string password = PasswordBoxPasswordRegistration.Password;
           // password = repo.GetHash(password);
            //string phone = textBoxPhone.Text;
            string city = textBoxCity.Text;
            string address = textBoxAddress.Text;

            //ThisUser = repo.ToCreateNewPerson(name, password,email, city, address);
            
            //if ((textBoxFullName.Text == String.Empty) || (textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordRegistration.Password == String.Empty) || (PasswordBoxPasswordRegistration2.Password == String.Empty) || (textBoxAddress.Text == String.Empty))
            //{
            //    MessageBox.Show("Please, fill all fields", "Error");
                
            //}
            
            // else if (repo.Users == null)
            // {
            //        repo.ToRegistrate(ThisUser);
            //        MainWindow main = new MainWindow();
            //        this.Close();
            // }
            
            //else
            //{

            //    if (repo.ToCompare(email) == true)
            //    {
            //        repo.ToRegistrate(ThisUser);

            //        this.Close();
            //    }
            //    else
            //        MessageBox.Show("Such login already exists!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            //}


        }

        private void PasswordBoxPasswordRegistration2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                if ((textBoxFullName.Text == String.Empty) || (textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordRegistration.Password == String.Empty) || (PasswordBoxPasswordRegistration2.Password == String.Empty) || (textBoxAddress.Text == String.Empty))
                {
                    MessageBox.Show("Please, fill all fields", "Error");

                }
                else
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                }
            }

        }

        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
