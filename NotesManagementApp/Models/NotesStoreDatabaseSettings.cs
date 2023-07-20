namespace NotesManagementApp.Models
{
    public class NotesStoreDatabaseSettings : INotesStoreDatabaseSettings
    {
        public string NotesCollectionName { get; set; } = String.Empty;
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
    }
}
