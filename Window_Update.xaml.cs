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
using WPU221_1.Model;

namespace WPU221_1
{
    /// <summary>
    /// Логика взаимодействия для Window_Update.xaml
    /// </summary>
    public partial class Window_Update : Window
    {
        public Window_Update(Note note)
        {
            InitializeComponent();
            tbName.Text = note.Name;
            tbDescription.Text = note.Description;
        }

        private void btnUpdates_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
