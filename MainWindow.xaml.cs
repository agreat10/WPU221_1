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
        Note? selectedNote;
        
        bool Lang = true;
        public DContext dContext { get; set; }

        public MainWindow()
        {
            InitializeComponent();            
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
        }

        private void rbRus_Checked(object sender, RoutedEventArgs e)
        {
            Lang = true;
            Title = "Заметки";
            if (btnCreate == null) return;
            btnCreate.Content = Languages.Message_ru_ru.BtnCreate;
            btnUpdate.Content = Languages.Message_ru_ru.BtnUpdate;
            btnDelete.Content = Languages.Message_ru_ru.BtnDelete;
            tbLabel.Text = Languages.Message_ru_ru.TbLabel;
        }

        private void rbEng_Checked(object sender, RoutedEventArgs e)
        {
            Lang = false;
            Title = "Notes";
            btnCreate.Content = Languages.Message_en_us.BtnCreate;
            btnUpdate.Content = Languages.Message_en_us.BtnUpdate;
            btnDelete.Content = Languages.Message_en_us.BtnDelete;
            tbLabel.Text = Languages.Message_en_us.TbLabel;
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Create", selectedNote,Lang);
            ListBoxItem();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Update", selectedNote, Lang);
            ListBoxItem();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            NoteController nc = new NoteController("Delete", selectedNote, Lang);
            ListBoxItem();
        }
        private void ListBoxItem()
        {
            dContext.notes.Clear();
            using (AppContext db = new AppContext())
            {
                var tempList = db.Notes.ToList();
                foreach (var note in tempList) { dContext.notes.Add(note); }
            }
            if (lbMenu.Items.Count > 0) lbMenu.SelectedIndex = 0;
        }
    }
}
