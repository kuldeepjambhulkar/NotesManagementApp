using MongoDB.Driver;
using NotesManagementApp.Models;

namespace NotesManagementApp.Services
{
    public class NotesService : INotesService
    {
        private readonly IMongoCollection<Note> _notes;

        public NotesService(INotesStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _notes = database.GetCollection<Note>(settings.NotesCollectionName);
        }
        public Note Create(Note note)
        {
            _notes.InsertOne(note);
            return note;
        }

        public List<Note> Get()
        {
            return _notes.Find(note => true).ToList();
        }

        public Note Get(string id)
        {
            return _notes.Find(note => note.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _notes.DeleteOne(note => note.Id == id);
        }

        public void Update(string id, Note note)
        {
            _notes.ReplaceOne(note => note.Id == id, note);
        }
    }
}
