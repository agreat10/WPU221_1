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
using WPU221_1.Controller;
using WPU221_1.Model;


namespace WPU221_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Note selectedNote;
        public DContext dContext { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            // Создание коллекции объектов класса Note
            //List<Note> notes = new List<Note>
            // {
            //     new Note { Name = "Заметка 1", Description = "Описание заметки 1" },
            //     new Note { Name = "Заметка 2", Description = "Описание заметки 2" },
            //     new Note { Name = "Заметка 3", Description = "Описание заметки 3" }
            // };
            dContext = new DContext();
            DataContext = dContext;


            // Привязка коллекции к ListBox
            lbMenu.ItemsSource = dContext.notes;

        }

        private void lbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tbInfo.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            // Получение выбранного объекта из ListBox
            selectedNote = (Note)lbMenu.SelectedItem;
            Title = $"{selectedNote.Id} {selectedNote.Name} {selectedNote.Description}";

            // Дальнейшая обработка выбранного объекта...
        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            Title = "RU";
            //btnCreate.Content = Languages.Message_ru_ru.BtnCreate;
        }

        private void rbEng_Checked(object sender, RoutedEventArgs e)
        {
            Title = "Eng";
            btnCreate.Content = Languages.Message_en_us.BtnCreate;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Create", selectedNote);
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Update", selectedNote);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Delete", selectedNote);
        }
    }
}
