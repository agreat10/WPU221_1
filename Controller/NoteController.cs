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
            if (str=="Create") { Create(); }
            else if(str == "Update") { Update(); }
            else if (str == "Delete") { Delete(); }
        }

        private void Delete()
        {
            MessageBox.Show($"Delete, {_selectedNote.Name}");
        }

        private void Update()
        {
            MessageBox.Show($"Update, {_selectedNote.Name}");
        }

        private void Create()
        {
            MessageBox.Show($"Create, {_selectedNote.Name}");
        }
    }
}
