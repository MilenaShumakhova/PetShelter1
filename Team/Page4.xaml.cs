using PetShelterClasses;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Team
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        delegate void UsersStatuses(GetterRequests requests);
        delegate List<GetterRequests> GetInfo(User user);
        GetInfo gf;
        UsersStatuses us;
        User ThisUser;
        IRepositoryInterface rep;
        Context context;
        public Page4(User user, IRepositoryInterface repo, Context cont)
        {
           
            ThisUser = user;
            rep = repo;
            context = cont;
            InitializeComponent();
            rep.RestoreRequests();
            gf = rep.ToReturnListWithRequestsFromMe;
            FromMe.ItemsSource = gf.Invoke(ThisUser);
            gf = rep.ToGetRequestsToMe;
            ToMe.ItemsSource = gf.Invoke(ThisUser); 
        }

        private void Button_ClickGive(object sender, RoutedEventArgs e)
        {
            if(FromMe.SelectedItem!=null)
            {
                GetterRequests giveRequests = FromMe.SelectedItem as GetterRequests;
                GiveRequestShow giveRequest = new GiveRequestShow(ThisUser, rep, context, giveRequests);
                giveRequest.Show();
            }
            else
            {
                MessageBox.Show("Please, select a request","Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           
        }

        private void Button_ClickGet(object sender, RoutedEventArgs e)
        {
            if(ToMe.SelectedItem!=null)
            {
                GetterRequests getterRequests = ToMe.SelectedItem as GetterRequests;
                GetterRequestShow getterRequest = new GetterRequestShow(ThisUser, rep, context, getterRequests);
                getterRequest.Show();
            }
            else
            {
                MessageBox.Show("Please, select a request", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            if(FromMe.SelectedItem!=null)
            {
                GetterRequests request = FromMe.SelectedItem as GetterRequests;
                rep.ChangeStatusToAccept(request);
                FromMe.ItemsSource = rep.ToReturnListWithRequestsFromMe(ThisUser);
            }
            else
            {
                MessageBox.Show("Please, select a request", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
    


        }

        private void Button_ClickAccept(object sender, RoutedEventArgs e)
        {
            if (ToMe.SelectedItem!=null)
            {
                GetterRequests g = ToMe.SelectedItem as GetterRequests;
                us = rep.ChangeStatusToAccept;
                us.Invoke(g);
                MessageBox.Show("You accepted this request");
            }

            else
            {
                MessageBox.Show("Please, select a request", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_ClickDecline(object sender, RoutedEventArgs e)
        {
            if(ToMe.SelectedItem!=null)
            {
                GetterRequests g = ToMe.SelectedItem as GetterRequests;
                us = rep.ChangeStatusToDecline;
                us.Invoke(g);
                var RequestsToMe = rep.ToGetRequestsToMe(ThisUser);
                ToMe.ItemsSource = RequestsToMe;
                MessageBox.Show("You declined this request");
            }
            else
            {
                MessageBox.Show("Please, select a request", "Oops", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           

        }
    }
}
