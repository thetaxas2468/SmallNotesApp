using Microsoft.EntityFrameworkCore;
using SimpleNotesApi.Interfaces;
using SimpleNotesApi.Models;
using SimpleNotesApi.Repositories;

namespace SimpleNotesApi.Services
{
    public class NotesService : INoteService
    {
        private readonly INotesRepository _notesRepo;
        private readonly ILogger<NotesService> _logger;
        public NotesService(INotesRepository noteRepository, ILogger<NotesService> logger)
        {
            _notesRepo = noteRepository;
            _logger = logger;
        }
        public async Task createNode(DescriptionTitleNote note)
        {
            // Check desciption and title validations
            await _notesRepo.createNode(note);

        }

        public async Task<Note?> deleteNote(int id)
        {
            try
            {
                var result = await _notesRepo.deleteNote(id);
                if (result == null)
                {
                    throw new Exception("Note not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Note is not found {ex.Message}");
                return null;
            }
        }

        public async Task<Note?> editNote(int id, DescriptionTitleNote semiNote)
        {
            try
            {
                var result = await _notesRepo.editNote(id, semiNote);
                if (result == null)
                {
                    throw new Exception("Note not found");
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Note is not found {ex.Message}");
                return null;
            }
        }

        public async Task<Note?> getNodeDetails(int id)
        {
            return await _notesRepo.getNodeDetails(id);
        }

        public async Task<List<Note>> getNodes()
        {
            return await _notesRepo.getNodes();
        }

    }
}
