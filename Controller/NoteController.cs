using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPU221_1.Model;

namespace WPU221_1.Controller
{
    public class NoteController
    {
        string _str;
        Note _selectedNote;
        public NoteController(string str, Note selectedNote)
        {
            _selectedNote = selectedNote;
            _str = str;            
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
            MessageBox.Show($"Delete, {_selectedNote.Name}");
        }

        private void Update()
        {            
            Window_Update wu = new Window_Update(_selectedNote);
            wu.ShowDialog();
        }

        private void Create()
        {            
            Window_Create wc = new Window_Create(_selectedNote);
            wc.ShowDialog();
        }
    }
}
