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
        public MainWindow()
        {
            InitializeComponent();
            textBoxEmail.Focus();

        }

        private void Button_ClickRegister(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow();
            registration.Show();
            this.Close();

        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            if ((textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordSignin.Password == String.Empty))
            {
                MessageBox.Show("Please, fill all fields", "Error");

            }
            else
            {
                MyProfile profile = new MyProfile();
                profile.Show();
                this.Close();
            }


        }

        private void PasswordBoxPasswordSignin_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
               
                if ((textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordSignin.Password == String.Empty))
                {
                        MessageBox.Show("Please, fill all fields", "Error");

                }
                else
                {
                    MyProfile profile = new MyProfile();
                    profile.Show();
                    this.Close();

                }
             
            }
        }
        
    }
}
