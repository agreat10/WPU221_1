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

namespace WPU221_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        ///Для наглядности заполнения ListBox
        /// </summary>
        List<string> lis;
        public MainWindow()
        {
            InitializeComponent();
            //Заполняем
            //lis = new List<string> { "1 Заметка", "2 Заметка", "3 Заметка", "4 Заметка" };
            //Привязываем
            //lbMenu.ItemsSource = lis;

            // Создание коллекции объектов класса Note
            List<Note> notes = new List<Note>
            {
                new Note { Name = "Заметка 1", Description = "Описание заметки 1" },
                new Note { Name = "Заметка 2", Description = "Описание заметки 2" },
                new Note { Name = "Заметка 3", Description = "Описание заметки 3" }
            };

            // Привязка коллекции к ListBox
            lbMenu.ItemsSource = notes;



        }

        private void lbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbInfo.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            Title = "RU";
            
        }

        private void rbEng_Checked(object sender, RoutedEventArgs e)
        {
            Title = "Eng";
            
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    // Определение класса Note
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    
}
