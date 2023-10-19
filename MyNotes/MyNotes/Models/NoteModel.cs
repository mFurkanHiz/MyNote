using MyNotes.Entities;
using System.Reflection.Metadata;

namespace MyNotes.Models
{
    public class NoteModel
    {
        public NoteModel()
        {
            SelectedNote = new Note();
        }

        public Note SelectedNote { get; set; }
    }
}
