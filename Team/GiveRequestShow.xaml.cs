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
using System.Windows.Shapes;

namespace Team
{
    /// <summary>
    /// Логика взаимодействия для GiveRequestShow.xaml
    /// </summary>
    public partial class GiveRequestShow : Window
    {
        User ThisUser;
        RepositoryDB rep;
        Context context;
        GetterRequests giverRequests;
        public GiveRequestShow(User us, RepositoryDB repo, Context cont,GetterRequests giver )
        {
            InitializeComponent();
            ThisUser = us;
            rep = repo;
            context = cont;
            giverRequests = giver;
            textBoxType.Text = giverRequests.Request.Pet.Type;
            textBoxDescription.Text = giverRequests.Request.Description;
            textBoxPayment.Text = giverRequests.User.PaymentGetter.ToString();
            textBoxAddress.Text = giverRequests.User.Address;
            textBoxPhone.Text = giverRequests.User.Phone;
            textBoxGetter.Text = giverRequests.User.NameSurname;
            textBoxEmail.Text = giverRequests.User.Email;
            textBoxFrom.Text = giverRequests.Request.Start.ToString();
            textBoxTo.Text = giverRequests.Request.End.ToString();
            

        }

        private void Button_ClickDelete(object sender, RoutedEventArgs e)
        {

        }

        private void Button_ClickBack(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

     
    }
}
