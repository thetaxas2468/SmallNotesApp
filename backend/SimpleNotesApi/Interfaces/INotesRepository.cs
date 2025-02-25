using SimpleNotesApi.Models;

namespace SimpleNotesApi.Interfaces
{
    public interface INotesRepository
    {
        Task<List<Note>> getNodes();
        Task createNode(DescriptionTitleNote note);
        Task<Note?> editNote(int id, DescriptionTitleNote semiNote);
        Task<Note?> deleteNote(int id);
        Task<Note?> getNodeDetails(int id);
    }
}
