using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPU221_1.Model;

namespace WPU221_1
{
    public class DContext
    {
        public ObservableCollection<Note> notes { get; set; }
        public DContext() 
        {
            using (AppContext db = new AppContext())
            {
                int count = db.Notes.Count();
                if(count == 0)
                {
                    notes = new ObservableCollection<Note>
                    {
                        new Note { Name = "Заметка 1", Description = "Описание заметки 1" },
                        new Note { Name = "Заметка 2", Description = "Описание заметки 2" },
                        new Note { Name = "Заметка 3", Description = "Описание заметки 3" }
                    };
                }
                else
                {
                    var tempNote = db.Notes.ToList();
                    notes = new ObservableCollection<Note>();
                    foreach (var note in tempNote)
                    {
                        Note tempnote = new Note { Description = note.Description, Name = note.Name, Id = note.Id};
                        notes.Add(tempnote);
                    }
                }
                
            }
        }
    }
}
