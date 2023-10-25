using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
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
            if (string.IsNullOrWhiteSpace(TextBoxNumberId.Text)) { MessageBox.Show("Поле код номера не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxNumberName.Text)) { MessageBox.Show("Поле название помера не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxCapacity.Text)) { MessageBox.Show("Поле вместимости не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxDescription.Text)) { MessageBox.Show("Поле описание не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxPrice.Text)) { MessageBox.Show("Поле цены не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxEmplId.Text)) { MessageBox.Show("Поле кода сотрудника не введено"); return; }
            if (!int.TryParse(TextBoxEmplId.Text, out _)) { MessageBox.Show("Неверный формат кода сотрудника"); return; }
            if (!int.TryParse(TextBoxNumberId.Text, out _)) { MessageBox.Show("Неверный формат кода номера"); return; }
            if (!int.TryParse(TextBoxCapacity.Text, out _)) { MessageBox.Show("Неверный формат вместимости"); return; }
            if (!double.TryParse(TextBoxPrice.Text, out _)) { MessageBox.Show("Неверный формат цены"); return; }
            

            try
            {
                HotelRoom room = new HotelRoom
                {
                    NumberId = Convert.ToInt64(TextBoxNumberId.Text),
                    NumberName = TextBoxNumberName.Text,
                    Capacity = Convert.ToInt64(TextBoxCapacity.Text),
                    Description = TextBoxDescription.Text,
                    Price = Convert.ToDouble(TextBoxPrice.Text),
                    EmplsId = Convert.ToInt64(TextBoxEmplId.Text)
                };

                var db = new HostelDataBaseContext();
                db.HotelRooms.Add(room);
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
