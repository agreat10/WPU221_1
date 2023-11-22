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
        public Window_Create(Note note)
        {
            InitializeComponent();
            tbName.Text = note.Name;
            tbDescription.Text = note.Description;
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
                //var notes = db.Notes.ToList();
            }
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
