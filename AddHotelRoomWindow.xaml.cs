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
    /// Логика взаимодействия для AddHotelRoomWindow.xaml
    /// </summary>
    public partial class AddHotelRoomWindow : Window
    {
        public AddHotelRoomWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            HotelRoom room = new HotelRoom { 
                NumberId = Convert.ToInt64(TextBoxNumberId.Text),
                NumberName = TextBoxNumberName.Text,
                Capacity = Convert.ToInt64(TextBoxCapacity.Text),
                Description = TextBoxDescription.Text,
                Price = Convert.ToInt64(TextBoxPrice.Text),
                EmplsId = Convert.ToInt64(TextBoxEmplId.Text)
            };

            var db = new HostelDataBaseContext();
            db.HotelRooms.Add(room);
            db.SaveChanges();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
