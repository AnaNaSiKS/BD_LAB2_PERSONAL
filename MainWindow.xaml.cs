using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
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

namespace BD_LAB2_PERSONAL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static void ShowWindow (Window window)
        {
            window.Show();
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new AddEmployeeWindow());
        }

        private void ButtonAddPosition_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new AddPositionWindow());
        }

        private void ButtonAddHotelRoom_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(new AddHotelRoomWindow());
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            var db = new HostelDataBaseContext();
            DataGridPosition.ItemsSource = db.Positions.ToList();
            DataGridEmloyees.ItemsSource = db.Employees.ToList();
            DataGridHotelRoom.ItemsSource = db.HotelRooms.ToList();
        }

        private void DataGridEmloyees_Click(object sender, MouseButtonEventArgs e)
        {
            Employee employee = (Employee)DataGridEmloyees.Items[DataGridEmloyees.SelectedIndex];
            ShowWindow(new ChangeEmployeeWindow(employee));
        }

        private void DataGridPosition_Click(object sender, MouseButtonEventArgs e)
        {
            Position position = (Position)DataGridPosition.Items[DataGridPosition.SelectedIndex];
            ShowWindow(new ChangePositionWindow(position));
        }

        private void DataGridHotelRoom_Click(object sender, MouseButtonEventArgs e)
        {
            HotelRoom hotelRoom = (HotelRoom)DataGridHotelRoom.Items[DataGridHotelRoom.SelectedIndex];
            ShowWindow(new ChangeHotelRoomWindow(hotelRoom));
        }

        private void MenuItemCutEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee employee = (Employee)DataGridEmloyees.Items[DataGridEmloyees.SelectedIndex];
                var db = new HostelDataBaseContext();

                db.Employees.Remove(employee);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void MenuItemCutHotelRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HotelRoom hotelRoom = (HotelRoom)DataGridHotelRoom.Items[DataGridHotelRoom.SelectedIndex];
                var db = new HostelDataBaseContext();

                db.HotelRooms.Remove(hotelRoom);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void MenuItemCutPosition_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Position position = (Position)DataGridPosition.Items[DataGridPosition.SelectedIndex];
                var db = new HostelDataBaseContext();

                db.Positions.Remove(position);
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void ButtonSelection_Click(object sender, RoutedEventArgs e)
        {
            var db = new HostelDataBaseContext();

            var employeesIdLess3 = db.Employees.Where(empl => empl.EmplId < 3);

            foreach (var employee in employeesIdLess3)
            {
                MessageBox.Show(employee.FirstName);
            }

            var employeesNameIncludeD = db.Employees.Where(empl => empl.FirstName.Contains("D"));

            foreach (var employee in employeesNameIncludeD)
            {
                MessageBox.Show(employee.FirstName);
            }
        }

        private void ButtonSelectionConnection_Click(object sender, RoutedEventArgs e)
        {
            var db = new HostelDataBaseContext();

            var employeeConn = db.Employees.Join(db.HotelRooms, e => e.EmplId, h => h.EmplsId, (e, h) => new {Name = e.FirstName, Number = h.NumberName, Price = h.Price }).Where(empl => empl.Price > 100);

            foreach (var employee in employeeConn)
            {
                MessageBox.Show(employee.Name+ "\n" + employee.Number + "\n" + employee.Price.ToString());
            }
        }

        private void CalculateAge_Click(object sender, RoutedEventArgs e)
        {
            var db = new HostelDataBaseContext();

            var startDate = DateTime.ParseExact("01.01.2022", "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("31.12.2023", "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var empl = db.Employees.ToList().Where(e => DateTime.ParseExact(e.Birthday,"dd.MM.yyyy", CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(e.Birthday,"dd.MM.yyyy", CultureInfo.InvariantCulture) <= endDate);

            foreach (var employee in empl) {
                MessageBox.Show(employee.FirstName);
            }


        }
    }
}
