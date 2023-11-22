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

namespace WPU221_1
{
    /// <summary>
    /// Логика взаимодействия для Window_Create.xaml
    /// </summary>
    public partial class Window_Create : Window
    {
        public Window_Create()
        {
            InitializeComponent();
        }

        private void btnCreates_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
