﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Team
{
    /// <summary>
    /// Логика взаимодействия для MyProfile.xaml
    /// </summary>
    public partial class MyProfile : Window
    {
        bool StateClosed = true;
        public MyProfile()
        {
            InitializeComponent();
            Page1 page1 = new Page1();

           ContentFrame.NavigationService.Navigate(page1);
   
         
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
           
        }



        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            if (StateClosed)
            {
                Storyboard sb = this.FindResource("OpenMenu") as Storyboard;
                sb.Begin();
            }
            else
            {
                Storyboard sb = this.FindResource("CloseMenu") as Storyboard;
                sb.Begin();
            }

            StateClosed = !StateClosed;
        }

        private void RadioButton_ClickRequests(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_ClickGiver(object sender, RoutedEventArgs e)
        {
            //PageTest page = new PageTest();
            //this.NavigationService.Navigate(page);


            //ContentFrame.Navigate(page);
            ////NavigationService nav = NavigationService.GetNavigationService(this);
            ////nav.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            //ContentFrame.Navigate(new System.Uri("/Pages/Page1.xaml",
            // UriKind.RelativeOrAbsolute));
            //ContentFrame.Navigate( typeof(Page1));
            Page1 page1 = new Page1();
            ContentFrame.NavigationService.Navigate(page1);
           
        }

        private void RadioButton_ClickGetter(object sender, RoutedEventArgs e)
        {
            Page2 page2 = new Page2();
            ContentFrame.NavigationService.Navigate(page2);
        }

        private void RadioButton_ClickSettings(object sender, RoutedEventArgs e)
        {
            Page3 page3 = new Page3();
            ContentFrame.NavigationService.Navigate(page3);
        }
    }
}
