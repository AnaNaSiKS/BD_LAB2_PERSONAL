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
    /// Логика взаимодействия для ShowResultRequestDataGrid.xaml
    /// </summary>
    public partial class ShowResultRequestDataGrid : Window
    {

        public ShowResultRequestDataGrid(List<Employee> employee, string name)
        {
            InitializeComponent();

            this.Title = name;
            DataGrid.ItemsSource = employee;
        }

        public ShowResultRequestDataGrid(List<Position> position, string name)
        {
            InitializeComponent();

            this.Title = name;
            DataGrid.ItemsSource = position;
        }


        public ShowResultRequestDataGrid(List<HotelRoom> position, string name)
        {
            InitializeComponent();

            this.Title = name;
            DataGrid.ItemsSource = position;
        }

        public ShowResultRequestDataGrid(List<dynamic> position, string name)
        {
            InitializeComponent();

            this.Title = name;
            DataGrid.ItemsSource = position;
        }

    }
}
