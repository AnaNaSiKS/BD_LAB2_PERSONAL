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

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.Show();
        }

        private void ButtonAddPosition_Click(object sender, RoutedEventArgs e)
        {
            AddPositionWindow addPositionWindow = new AddPositionWindow();
            addPositionWindow.Show();
        }

        private void ButtonAddHotelRoom_Click(object sender, RoutedEventArgs e)
        {
            AddHotelRoomWindow addHotelRoomWindow = new AddHotelRoomWindow();
            addHotelRoomWindow.Show();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            var db = new HostelDataBaseContext();
            DataGridPosition.ItemsSource = db.Positions.ToList();
            DataGridEmloyees.ItemsSource = db.Employees.ToList();
            DataGridHotelRoom.ItemsSource = db.HotelRooms.ToList();
        }
    }
}
