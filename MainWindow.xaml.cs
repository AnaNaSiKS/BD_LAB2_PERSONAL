using System;
using System.Collections.Generic;
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
    }
}
