﻿using PetShelterClasses;
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
using System.Windows.Shapes;

namespace Team
{
    /// <summary>
    /// Логика взаимодействия для GetterRequestShow.xaml
    /// </summary>
    public partial class GetterRequestShow : Window
    {
        User ThisUser;
        IRepositoryInterface rep;
        Context context;
        GetterRequests getterRequest;
        public GetterRequestShow(User user, IRepositoryInterface repo, Context cont,GetterRequests getter)
        {
            InitializeComponent();
            ThisUser = user;
            rep = repo;
            context = cont;
            getterRequest = getter;
            textBoxAddress.Text = getterRequest.Request.User.Address;
            textBoxDescription.Text = getterRequest.Request.Description;
            textBoxEmail.Text = getterRequest.Request.User.Email;
            textBoxFrom.Text = getterRequest.Request.Start.ToString();
            textBoxGive.Text = getterRequest.Request.User.NameSurname;
            textBoxPhone.Text = getterRequest.Request.User.Phone;
            textBoxTo.Text = getterRequest.Request.End.ToString();
            textBoxType.Text = getterRequest.Request.Pet.Type;
            textBoxStatus.Text = getterRequest.StatusGetter;
        }





        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
