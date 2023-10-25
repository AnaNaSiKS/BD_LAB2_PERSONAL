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
    /// Логика взаимодействия для AddPositionWindow.xaml
    /// </summary>
    public partial class AddPositionWindow : Window
    {
        public AddPositionWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxId.Text)) { MessageBox.Show("Поле кода должности не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxName.Text)) { MessageBox.Show("Поле Название должности не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxSalary.Text)) { MessageBox.Show("Поле оклада не введено"); return; }
            if (string.IsNullOrWhiteSpace(TextBoxDuties.Text)) { MessageBox.Show("Поле обязанностей не введено"); return; } 
            if (string.IsNullOrWhiteSpace(TextBoxRequirments.Text)) { MessageBox.Show("Поле требований не введено"); return; }
            if (!int.TryParse(TextBoxId.Text, out _)) { MessageBox.Show("Неверный фомат кода должности"); return; }
            if (!int.TryParse(TextBoxSalary.Text, out _)) { MessageBox.Show("Неверный фомат оклада"); return; }
            
            try
            {
                Position position = new Position
                {
                    PositionId = Convert.ToInt64(TextBoxId.Text),
                    PositionName = TextBoxName.Text,
                    Salary = Convert.ToInt64(TextBoxSalary.Text),
                    Duties = TextBoxDuties.Text,
                    Requirements = TextBoxRequirments.Text,
                };

                var db = new HostelDataBaseContext();
                db.Positions.Add(position);
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
