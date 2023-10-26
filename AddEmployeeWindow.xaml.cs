using Microsoft.EntityFrameworkCore.Query;
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
            TextBoxBirthday.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddYears(-18), new DateTime(9999, 12, 31)));
            TextBoxBirthday.BlackoutDates.Add(new CalendarDateRange(new DateTime(1, 1, 1), DateTime.Today.AddYears(-110)));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxFirstName.Text)) { MessageBox.Show("Введите Имя"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxSecondName.Text)) { MessageBox.Show("Введите Фамилию"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxLastName.Text)) { MessageBox.Show("Введите Отчество"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxAddres.Text)) { MessageBox.Show("Введите Адрес"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxGender.Text)) { MessageBox.Show("Введите пол"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxTelephoneNumber.Text)) { MessageBox.Show("Введите номер"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxPasportDetails.Text)) { MessageBox.Show("Введите паспортные данные"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxBirthday.Text)) { MessageBox.Show("Введите дату рождения"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxEmplId.Text)) { MessageBox.Show("Введите код сотрудника"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxPositionId.Text)) { MessageBox.Show("Введите код должности"); return; }
            if (TextBoxGender.SelectedItem == null) { MessageBox.Show("Поле пол не выбрано"); return; }
            if (!int.TryParse(TextBoxEmplId.Text, out _)) { MessageBox.Show("Неверный формат Кода сотрудника"); return; }
            if (!int.TryParse(TextBoxPositionId.Text, out _)) { MessageBox.Show("Неверный фомат номера должности"); return; }
            if (!DateTime.TryParse(TextBoxBirthday.Text, out _)) { MessageBox.Show("Неверный фомат даты"); return; }
            if (TextBoxTelephoneNumber.Text.Length != 11) { MessageBox.Show("Неверный формат номера телефона"); return; }
            foreach (char symbol in TextBoxTelephoneNumber.Text)
            {
                if (char.IsLetter(symbol)) { MessageBox.Show("Неверный формат номера"); return; }
            }


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
