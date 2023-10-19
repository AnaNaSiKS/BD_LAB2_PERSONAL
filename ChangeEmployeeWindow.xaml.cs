using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ChangeEmployeeWindow.xaml
    /// </summary>
    public partial class ChangeEmployeeWindow : Window
    {
        private readonly Employee inputEmployee;
        public ChangeEmployeeWindow(Employee employeeContext)
        {
            InitializeComponent();
            this.DataContext = employeeContext; 
            inputEmployee = employeeContext;
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new HostelDataBaseContext();

                Employee? changeEmployee = db.Employees.FirstOrDefault(employee => employee.EmplId == inputEmployee.EmplId);
                if (changeEmployee != null)
                {
                    changeEmployee.SecondName = TextBoxSecondName.Text;
                    changeEmployee.FirstName = TextBoxFirstName.Text;
                    changeEmployee.LastName = TextBoxLastName.Text;
                    changeEmployee.EmplId = Convert.ToInt64(TextBoxEmplId.Text);
                    changeEmployee.Address = TextBoxAddres.Text;
                    changeEmployee.Gender = TextBoxGender.Text;
                    changeEmployee.PositionsId = Convert.ToInt64(TextBoxPositionId.Text);
                    changeEmployee.TelephoneNumber = TextBoxTelephoneNumber.Text;
                    changeEmployee.PassportDetails = TextBoxPasportDetails.Text;
                    changeEmployee.Birthday = TextBoxBirthday.Text;

                    db.SaveChanges();
                }
                else MessageBox.Show("Object not found");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
