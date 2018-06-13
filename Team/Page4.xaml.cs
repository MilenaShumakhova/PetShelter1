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
        User ThisUser;
        RepositoryDB rep;
        Context context;
        public Page4(User us, RepositoryDB repo, Context cont)
        {
            ThisUser = us;
            rep = repo;
            context = cont;
            InitializeComponent();
            rep.RestoreRequests();
            FromMe.ItemsSource =rep.ToReturnListWithRequestsFromMe(ThisUser);
           

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    GiveRequestShow giveRequest = new GiveRequestShow(ThisUser,rep,context);
        //    giveRequest.Show();
            
           
        //}

        private void Button_ClickGive(object sender, RoutedEventArgs e)
        {
            GetterRequests giveRequests = FromMe.SelectedItem as GetterRequests;
            GiveRequestShow giveRequest = new GiveRequestShow(ThisUser, rep, context, giveRequests);
            giveRequest.Show();
        }
    }
}
