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
    /// Логика взаимодействия для Window_Create.xaml
    /// </summary>
    public partial class Window_Create : Window
    {
        public Window_Create(bool Lang)
        {
            InitializeComponent();
            
            
            if(Lang == true)
            {
                btnCreates.Content = Languages.Message_ru_ru.BtnCreate;
                btnNo.Content = Languages.Message_ru_ru.BtnNo;
                tbName.Text = "Новая заметка";
                tbDescription.Text = "Новое описание заметки";
                tblockName.Text = Languages.Message_ru_ru.NameNote;
                tblockDescription.Text = Languages.Message_ru_ru.DescriptionNote;
            }
            else
            {
                btnCreates.Content = Languages.Message_en_us.BtnCreate;
                btnNo.Content = Languages.Message_en_us.BtnNo;
                tbName.Text = "New note";
                tbDescription.Text = "New note description";
                tblockName.Text = Languages.Message_en_us.NameNote;
                tblockDescription.Text = Languages.Message_en_us.DescriptionNote;
            }
        }

        private void btnCreates_Click(object sender, RoutedEventArgs e)
        {
            using (AppContext db = new AppContext())
            {
                Note note = new Note 
                { 
                    Name = tbName.Text,
                    Description = tbDescription.Text
                };
                db.Notes.Add(note);
                db.SaveChanges();
                
            }
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
