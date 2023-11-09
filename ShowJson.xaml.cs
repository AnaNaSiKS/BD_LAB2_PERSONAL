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
    /// Логика взаимодействия для ShowJson.xaml
    /// </summary>
    public partial class ShowJson : Window
    {
        public ShowJson(string json)
        {
            InitializeComponent();

            TextBoxShow.Text = json;
        }
    }
}
