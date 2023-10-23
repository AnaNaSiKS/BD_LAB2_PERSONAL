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

namespace BD_LAB2_PERSONAL
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = new Employee
                {
                    SecondName = TextBoxSecondName.Text,
                    FirstName = TextBoxFirstName.Text,
                    LastName = TextBoxLastName.Text,
                    EmplId = Convert.ToInt64(TextBoxEmplId.Text),
                    Address = TextBoxAddres.Text,
                    Gender = TextBoxGender.Text,
                    PositionsId = Convert.ToInt64(TextBoxPositionId.Text),
                    TelephoneNumber = TextBoxTelephoneNumber.Text,
                    PassportDetails = TextBoxPasportDetails.Text,
                    Birthday = TextBoxBirthday.Text.Replace(".", "-")
                };
                var db = new HostelDataBaseContext();
                db.Employees.Add(employee);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
