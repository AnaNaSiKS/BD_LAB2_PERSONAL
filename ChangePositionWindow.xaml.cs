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
    /// Логика взаимодействия для ChangePositionWindow.xaml
    /// </summary>
    public partial class ChangePositionWindow : Window
    {
        private readonly Position inputPosition;
        public ChangePositionWindow(Position positionContext)
        {
            InitializeComponent();
            this.DataContext = positionContext;
            inputPosition = positionContext;
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxName.Text)) { MessageBox.Show("Поле Название должности не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxSalary.Text)) { MessageBox.Show("Поле оклада не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxDuties.Text)) { MessageBox.Show("Поле обязанностей не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxRequirments.Text)) { MessageBox.Show("Поле требований не введено"); return; }
            if (!int.TryParse(TextBoxSalary.Text, out _)) { MessageBox.Show("Неверный фомат оклада"); return; }

            try
            {
                var db = new HostelDataBaseContext();

                Position? changeHotelRoom = db.Positions.FirstOrDefault(position => position.PositionId == inputPosition.PositionId);

                if (changeHotelRoom != null)
                {
                    changeHotelRoom.PositionName = TextBoxName.Text;
                    changeHotelRoom.Salary = Convert.ToDouble(TextBoxSalary.Text);
                    changeHotelRoom.Duties = TextBoxDuties.Text;
                    changeHotelRoom.Requirements = TextBoxRequirments.Text;

                    db.SaveChanges();
                }
                else MessageBox.Show("Объект не найден/Нельзя изменить Код должности");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
