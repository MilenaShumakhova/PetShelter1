﻿using PetShelterClasses;
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
        delegate void NewUsersInfo(User us); 
        Context c;
        User us = new User();
        public User ThisUser = new User();
        IRepositoryInterface repo;

        public RegistrationWindow(IRepositoryInterface r, Context context)
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
            
                string name = TextBoxFullName.Text;
                string email = TextBoxEmail.Text;
                string phone = TextBoxPhone.Text;
                string password = us.GetHash(PasswordRegistration.Password);
                string password2 = us.GetHash(PasswordRegistration2.Password);
                string city = TextBoxCity.Text;
                string address = TextBoxAddress.Text;
            if ( (name=="")||(email=="") || (password == "") || (password2 == "") ||(city=="")|| (address == "") || (phone == ""))
            {
                MessageBox.Show("Please, fill all fields", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (password != password2)
                {
                    MessageBox.Show("Passwords do not match" ,"Oops", MessageBoxButton.OK, MessageBoxImage.Error);
                    PasswordRegistration2.Clear();
                }
                else
                {
                    ThisUser = repo.ToCreateNewPerson(name, password, email, city, address,phone);

                    if (repo.Users.Count==0)
                    {
                        NewUsersInfo d = repo.ToRegistrate;
                        d(ThisUser);
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        if (repo.ToCompare(email) == true)
                        {
                            NewUsersInfo d = repo.ToRegistrate;
                            d(ThisUser);
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
       
    }
}
