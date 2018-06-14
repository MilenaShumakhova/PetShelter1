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
        IRepositoryInterface rep;
        Context context;
        GetterRequests giverRequests;
        public GiveRequestShow(User us, IRepositoryInterface repo, Context cont,GetterRequests giver)
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
            textBoxStatus.Text = giverRequests.StatusGiver;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBlock.Text!="")
            {
                double v= Slider1.Value;
                if (context.Marks != null)
                {
                    Mark oldmark = context.Marks.FirstOrDefault(m => m.RatedUser.ID == giverRequests.User.ID && m.Request.ID == giverRequests.ID);
                    if (oldmark != null)
                    {
                        MessageBox.Show("You can not rate a user more than once!");
                    }
                    else
                    {
                        rep.AddGrade(v, giverRequests.User, giverRequests);
                    }
                }
                else
                {

                }
               
            }
            this.Close();
        }

        private void Slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format(" {0}", val);
            this.TextBlock.Text = msg;
        }
    }
}
