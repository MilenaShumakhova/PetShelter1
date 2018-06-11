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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User us = new User();
        RepositoryDB rep = new RepositoryDB();
        Context context = new Context();
        public User ThisUser = new User();

        public MainWindow()
        {
            InitializeComponent();
            TextBoxEmail.Focus();

        }

        private void Button_ClickRegister(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow(rep,context);
            registration.Show();
            this.Close();

        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            string email = TextBoxEmail.Text;
            string password = us.GetHash(PasswordSignin.Password);
            if ((email=="") || (password==""))
            {
                MessageBox.Show("Please, fill all fields!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (rep.Users.Exists(us => us.Email == email && us.Password == password))
               {
                    ThisUser = rep.Users.First(us => us.Email == email && us.Password == password);
                    MyProfile profile = new MyProfile(ThisUser,rep,context);
                    profile.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Input data are incorrect!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                   
                }
            }
        }

         private void PasswordBoxPasswordSignin_KeyDown(object sender, KeyEventArgs e)
         {
            string email = TextBoxEmail.Text;
            string password = us.GetHash(PasswordSignin.Password);
            bool u = rep.Users.Exists(us => us.Email == email && us.Password == password);
            if (e.Key == Key.Enter)
            {

                if ((TextBoxEmail.Text == String.Empty) || (PasswordSignin.Password == String.Empty))
                {
                    MessageBox.Show("Please, fill all fields", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    if(u==true)
                    {
                        ThisUser= rep.Users.First(us => us.Email == email && us.Password == password);
                        MyProfile profile = new MyProfile(ThisUser,rep,context);
                        profile.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Input data are incorrect!", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    

                }

            }
         }

    }
}
