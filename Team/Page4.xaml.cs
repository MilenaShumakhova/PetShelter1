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
        delegate void UsersStatuses(User user);
        UsersStatuses us;
        User ThisUser;
        RepositoryDB rep;
        Context context;
        public Page4(User user, RepositoryDB repo, Context cont)
        {
           
            ThisUser = user;
            rep = repo;
            context = cont;
            InitializeComponent();
            rep.RestoreRequests();
            var RequestsFromMe= rep.ToReturnListWithRequestsFromMe(ThisUser);
            FromMe.ItemsSource = RequestsFromMe;
            var RequestsToMe = rep.ToGetRequestsToMe(ThisUser);
            ToMe.ItemsSource = RequestsToMe;
        }

        private void Button_ClickGive(object sender, RoutedEventArgs e)
        {
            GetterRequests giveRequests = FromMe.SelectedItem as GetterRequests;
            GiveRequestShow giveRequest = new GiveRequestShow(ThisUser, rep, context, giveRequests);
            giveRequest.Show();
           
        }

        private void Button_ClickGet(object sender, RoutedEventArgs e)
        {
            GetterRequests getterRequests = ToMe.SelectedItem as GetterRequests;
            GetterRequestShow getterRequest = new GetterRequestShow(ThisUser, rep, context,getterRequests);
            getterRequest.Show();
        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {
            GetterRequests request = FromMe.SelectedItem as GetterRequests;
            rep.RemoveGetterRequest(request);
            FromMe.ItemsSource = rep.ToReturnListWithRequestsFromMe(ThisUser);


        }

        private void Button_ClickAccept(object sender, RoutedEventArgs e)
        {
            GetterRequests g = ToMe.SelectedItem as GetterRequests;
            rep.ChangeStatusToAccept(g);
        }

        private void Button_ClickDecline(object sender, RoutedEventArgs e)
        {
            GetterRequests g = ToMe.SelectedItem as GetterRequests;
            rep.ChangeStatusToDecline(g); 
            var RequestsToMe = rep.ToGetRequestsToMe(ThisUser);
            ToMe.ItemsSource = RequestsToMe;
            MessageBox.Show("You declined this request");

        }
    }
}
