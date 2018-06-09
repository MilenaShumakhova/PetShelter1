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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Team.Pages;

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
   
         
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.textBlock1.Text = msg;
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
            //Page1 page = new Page1();
            //ContentFrame.Navigate(page);
            ////NavigationService nav = NavigationService.GetNavigationService(this);
            ////nav.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            //ContentFrame.Navigate(new System.Uri("/Pages/Page1.xaml",
            // UriKind.RelativeOrAbsolute));
            ContentFrame.Navigate( typeof(Page1));
           
        }
    }
}
