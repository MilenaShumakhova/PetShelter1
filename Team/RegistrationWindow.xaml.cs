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
        RepositoryDB repo;

        public RegistrationWindow(RepositoryDB r, Context context)
        {
            InitializeComponent();
            TextBoxFullName.Focus();
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
            if ((TextBoxFullName.Text == String.Empty) || (TextBoxEmail.Text == String.Empty) || (PasswordRegistration.Password == String.Empty) || (PasswordRegistration2.Password == String.Empty) || (TextBoxAddress.Text == String.Empty)||(TextBoxPhone.Text==String.Empty))
            {
                MessageBox.Show("Please, fill all fields", "Error");

            }
            else 
            {
                string name = TextBoxFullName.Text;
                string email = TextBoxEmail.Text;
                string phone = TextBoxPhone.Text;
                string password = us.GetHash(PasswordRegistration.Password);
                string password2 = us.GetHash(PasswordRegistration2.Password);
                string city = TextBoxCity.Text;
                string address = TextBoxAddress.Text;
                if (password != password2)
                {
                    MessageBox.Show("Passwords do not match");
                }
                else
                {
                    ThisUser = repo.ToCreateNewPerson(name, password, email, city, address);

                    if (repo.Users.Count==0)
                    {
                        repo.ToRegistrate(ThisUser);
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        if (repo.ToCompare(email) == true)
                        {
                            repo.ToRegistrate(ThisUser);
                            MainWindow main = new MainWindow();
                            main.Show();
                            this.Close();
                        }
                        else
                            MessageBox.Show("Such login already exists!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //private void PasswordRegistration2_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if (e.Key == Key.Enter)
        //    {
        //        if ((TextBoxFullName.Text == String.Empty) || (TextBoxEmail.Text == String.Empty) || (PasswordRegistration.Password == String.Empty) || (PasswordRegistration2.Password == String.Empty) || (TextBoxAddress.Text == String.Empty))
        //        {
        //            MessageBox.Show("Please, fill all fields", "Error");

        //        }
        //        else
        //        {
        //            MainWindow main = new MainWindow();
        //            main.Show();
        //            this.Close();
        //        }
        //    }

        //}
       
    }
}
