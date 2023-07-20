using NotesManagementApp.Models;

namespace NotesManagementApp.Services
{
    public interface INotesService
    {
        List<Note> Get();
        Note Get(string id);
        Note Create(Note note);
        void Update(string id, Note note);
        void Remove(string id);
    }
}
