using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WPU221_1.Model;

namespace WPU221_1.Controller
{
    public class NoteController
    {
        string _str;
        Note _selectedNote;
        bool _Lang;
        public NoteController(string str, Note selectedNote, bool Lang)
        {
            _selectedNote = selectedNote;
            _str = str;
            _Lang = Lang;
            switch (_str)
            {
                case "Create": { Create(); break; }
                case "Update": { Update(); break; }
                case "Delete": { Delete(); break; }

                default:
                    break;
            }

        }

        private void Delete()
        {
            if (_selectedNote == null) return;
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить это?", "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Логика удаления здесь
                using (AppContext db = new AppContext())
                {
                    try
                    {
                        var tempnote = db.Notes.Find(_selectedNote.Id);
                        if (tempnote is null){  return; }
                        db.Notes.Remove(tempnote);                       
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                MessageBox.Show("Удаление выполнено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Удаление отменено.", "Отмена", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            //MessageBox.Show($"Delete, {_selectedNote.Name}");
        }

        private void Update()
        {            
            Window_Update wu = new Window_Update(_selectedNote, _Lang);
            wu.ShowDialog();
        }

        private void Create()
        {            
            Window_Create wc = new Window_Create(_Lang);
            wc.ShowDialog();
        }
    }
}
