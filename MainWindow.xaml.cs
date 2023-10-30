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
            if (DataGridEmloyees.SelectedIndex == -1) { return; }
            Employee employee = (Employee)DataGridEmloyees.Items[DataGridEmloyees.SelectedIndex];
            ShowWindow(new ChangeEmployeeWindow(employee));
        }

        private void DataGridPosition_Click(object sender, MouseButtonEventArgs e)
        {
            if (DataGridPosition.SelectedIndex == -1) { return; }
            Position position = (Position)DataGridPosition.Items[DataGridPosition.SelectedIndex];
            ShowWindow(new ChangePositionWindow(position));
        }

        private void DataGridHotelRoom_Click(object sender, MouseButtonEventArgs e)
        {
            if (DataGridHotelRoom.SelectedIndex == -1) { return; }
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

            var employeesIdLess3 = db.Employees.Where(empl => empl.Gender == "Мужской" && empl.Address == "ул Д").ToList();

            ShowResultRequestDataGrid showResultRequestDataGrid = new ShowResultRequestDataGrid(employeesIdLess3,"Man + Address");
            showResultRequestDataGrid.Show();

            var employeesNameIncludeD = db.Employees.Where(empl => empl.FirstName.StartsWith("Д")).ToList();

            ShowResultRequestDataGrid showResultRequestDataGrid2 = new ShowResultRequestDataGrid(employeesNameIncludeD,"StartsWithD");
            showResultRequestDataGrid2.Show();
        }

        private void ButtonSelectionConnection_Click(object sender, RoutedEventArgs e)
        {
            List<string> result = new List<string>();
            var db = new HostelDataBaseContext();

            var employeeConn = db.Employees.Join(db.HotelRooms, e => e.EmplId, h => h.EmplsId, (e, h) => new {Name = e.FirstName, Number = h.NumberName, Price = h.Price }).Where(empl => empl.Price > 100).Select(empl => (dynamic)empl).ToList();

            ShowResultRequestDataGrid showResultRequestDataGrid = new ShowResultRequestDataGrid(employeeConn,"Connection");
            showResultRequestDataGrid.Show();
        }

        private void CheckDate_Click(object sender, RoutedEventArgs e)
        {

            var db = new HostelDataBaseContext();

            var startDate = DateTime.ParseExact("01-01-2000", "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact("31-12-2002", "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var empl = db.Employees.ToList().Where(e => DateTime.ParseExact(e.Birthday,"dd-MM-yyyy", CultureInfo.InvariantCulture) >= startDate && DateTime.ParseExact(e.Birthday,"dd-MM-yyyy", CultureInfo.InvariantCulture) <= endDate).ToList();

            ShowResultRequestDataGrid showResultRequestDataGrid2 = new ShowResultRequestDataGrid(empl,"Date");
            showResultRequestDataGrid2.Show();

        }

        private void CheckStatistic_Click(object sender, RoutedEventArgs e)
        {
            List<string> result = new List<string>();
            var db = new HostelDataBaseContext();
            try
            {
                var avgSalary = db.Positions.Where(p => p.PositionName == TextBoxRequestStatistic.Text).Average(p => p.Salary);
                MessageBox.Show($"Средняя зарплата {TextBoxRequestStatistic.Text} = {avgSalary}");
            }
            catch (Exception ex) { MessageBox.Show("Не удалось найти должность в БД"); }
        }
    }
}
