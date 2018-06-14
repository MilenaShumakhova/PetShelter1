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
        User ThisUser;
        IRepositoryInterface rep;
        Context context;
        public MyProfile(User us, IRepositoryInterface repo,Context cont)
        {
            InitializeComponent();
            ThisUser = us;
            rep = repo;
            context = cont;
            rep.RestorePets();
            rep.RestoreRequests();
            Page4 page4 = new Page4(ThisUser, rep, context);
            ContentFrame.NavigationService.Navigate(page4);
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
            Page4 page4 = new Page4(ThisUser, rep, context);
            ContentFrame.NavigationService.Navigate(page4);
        }

        private void RadioButton_ClickGiver(object sender, RoutedEventArgs e)
        {
            Page1 page1 = new Page1(ThisUser,rep,context);
            ContentFrame.NavigationService.Navigate(page1);
        }
        private void RadioButton_ClickGetter(object sender, RoutedEventArgs e)
        {
            Page2 page2 = new Page2(ThisUser,rep,context);
            ContentFrame.NavigationService.Navigate(page2);
        }
        private void RadioButton_ClickSettings(object sender, RoutedEventArgs e)
        {
            Page3 page3 = new Page3(ThisUser,rep,context);
            ContentFrame.NavigationService.Navigate(page3);
        }
    }
}
