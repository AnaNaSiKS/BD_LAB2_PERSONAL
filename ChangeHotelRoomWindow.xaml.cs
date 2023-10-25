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
    /// Логика взаимодействия для ChangeHotelRoomWindow.xaml
    /// </summary>
    public partial class ChangeHotelRoomWindow : Window
    {
        private readonly HotelRoom inputHotelRoom;
        public ChangeHotelRoomWindow(HotelRoom hotelRoom)
        {
            InitializeComponent();
            this.DataContext = hotelRoom;
            inputHotelRoom = hotelRoom;
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var db = new HostelDataBaseContext();

                HotelRoom? changeHotelRoom = db.HotelRooms.FirstOrDefault(hotelRoom => hotelRoom.NumberId == inputHotelRoom.NumberId);

                if (changeHotelRoom != null)
                {
                    changeHotelRoom.NumberName = TextBoxNumberName.Text;
                    changeHotelRoom.Capacity = Convert.ToInt64(TextBoxCapacity.Text);
                    changeHotelRoom.Description = TextBoxDescription.Text;
                    changeHotelRoom.Price = Convert.ToInt64(TextBoxPrice.Text);
                    changeHotelRoom.EmplsId = Convert.ToInt64(TextBoxEmplId.Text);

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
