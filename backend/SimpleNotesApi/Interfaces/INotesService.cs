using SimpleNotesApi.Models;

namespace SimpleNotesApi.Interfaces
{
    public interface INoteService
    {
        Task<List<Note>> getNodes();
        Task<Note?> getNodeDetails(int id);
        Task createNode(DescriptionTitleNote note);
        Task<Note?> editNote(int id, DescriptionTitleNote semiNote);
        Task<Note?> deleteNote(int id);
    }
}
