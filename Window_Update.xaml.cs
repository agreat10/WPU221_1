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
        Note _notes; 
        public Window_Update(Note note, bool Lang)
        {
            InitializeComponent();
            tbName.Text = note.Name;
            tbDescription.Text = note.Description;
            _notes = note;
            if (Lang == true)
            {
                btnUpdates.Content = Languages.Message_ru_ru.BtnUpdate;
                btnNo.Content = Languages.Message_ru_ru.BtnNo;
            }
            else
            {
                btnUpdates.Content = Languages.Message_en_us.BtnUpdate;
                btnNo.Content = Languages.Message_en_us.BtnNo;
            }
        }

        private void btnUpdates_Click(object sender, RoutedEventArgs e)
        {      
            using(AppContext db = new AppContext())
            {
                try
                { 
                    var tempnote = db.Notes.Find(_notes.Id);
                    if (tempnote is null)
                    { this.Close(); return; }
                    tempnote.Name = tbName.Text;
                    tempnote.Description = tbDescription.Text;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }   
            }
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
