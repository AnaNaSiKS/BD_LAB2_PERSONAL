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
            if (string.IsNullOrWhiteSpace(TextBoxFirstName.Text)) { MessageBox.Show("Введите Имя"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxSecondName.Text)) { MessageBox.Show("Введите Фамилию"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxLastName.Text)) { MessageBox.Show("Введите Отчество"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxAddres.Text)) { MessageBox.Show("Введите Адрес"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxGender.Text)) { MessageBox.Show("Введите пол"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxTelephoneNumber.Text)) { MessageBox.Show("Введите номер"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxPasportDetails.Text)) { MessageBox.Show("Введите паспортные данные"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxBirthday.Text)) { MessageBox.Show("Введите дату рождения"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxPositionId.Text)) { MessageBox.Show("Введите код должности"); return; }
            if (TextBoxGender.SelectedItem == null) { MessageBox.Show("Поле пол не выбрано"); return; }
            if (!int.TryParse(TextBoxPositionId.Text, out _)) { MessageBox.Show("Неверный фомат номера должности"); return; }
            if (!DateTime.TryParse(TextBoxBirthday.Text, out _)) { MessageBox.Show("Неверный фомат даты"); return; }
            if (TextBoxTelephoneNumber.Text.Length != 11) { MessageBox.Show("Неверный формат номера телефона"); return; }

            try
            {
                var db = new HostelDataBaseContext();

                Employee? changeEmployee = db.Employees.FirstOrDefault(employee => employee.EmplId == inputEmployee.EmplId);

                if (changeEmployee != null)
                {
                    changeEmployee.SecondName = TextBoxSecondName.Text;
                    changeEmployee.FirstName = TextBoxFirstName.Text;
                    changeEmployee.LastName = TextBoxLastName.Text;
                    changeEmployee.Address = TextBoxAddres.Text;
                    changeEmployee.Gender = TextBoxGender.Text;
                    changeEmployee.PositionsId = Convert.ToInt64(TextBoxPositionId.Text);
                    changeEmployee.TelephoneNumber = TextBoxTelephoneNumber.Text;
                    changeEmployee.PassportDetails = TextBoxPasportDetails.Text;
                    changeEmployee.Birthday = TextBoxBirthday.Text.Replace(".", "-");

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
