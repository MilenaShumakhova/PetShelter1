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
      
        public RegistrationWindow()
        {
            InitializeComponent();
            textBoxName.Focus();
            
        }

        private void Button_ClickBACK(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }

        private void Button_ClickOK(object sender, RoutedEventArgs e)
        {
            if ((textBoxName.Text == String.Empty) || (textBoxSurname.Text == String.Empty) || (textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordRegistration.Password == String.Empty) || (PasswordBoxPasswordRegistration2.Password == String.Empty)||(textBoxAddress.Text == String.Empty) || (textBoxPhone.Text == String.Empty))
            {
                MessageBox.Show("Please, fill all fields", "Error");

            }



            else
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            }
            string name = textBoxName.Text;
            string surname = textBoxSurname.Text;
            string phone = textBoxPhone.Text;
            string city = textBoxCity.Text;
            string address = textBoxAddress.Text;
           
        }

        private void PasswordBoxPasswordRegistration2_KeyDown(object sender, KeyEventArgs e)
        {
            if ((textBoxName.Text == String.Empty) || (textBoxSurname.Text == String.Empty) || (textBoxEmail.Text == String.Empty) || (PasswordBoxPasswordRegistration.Password == String.Empty) || (PasswordBoxPasswordRegistration2.Password == String.Empty)||(textBoxAddress.Text==String.Empty)||(textBoxPhone.Text==String.Empty))
            {
                MessageBox.Show("Please, fill all fields", "Error");

            }
            else if (e.Key == Key.Enter)
            {

                MyProfile profile = new MyProfile();
                profile.Show();
                this.Close();
            }
        }

        private void textBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
