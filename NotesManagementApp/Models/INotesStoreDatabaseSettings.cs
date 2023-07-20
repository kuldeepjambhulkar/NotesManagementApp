namespace NotesManagementApp.Models
{
    public interface INotesStoreDatabaseSettings
    {
        string NotesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
