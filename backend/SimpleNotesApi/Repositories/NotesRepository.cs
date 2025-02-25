using Microsoft.EntityFrameworkCore;
using SimpleNotesApi.Database;
using SimpleNotesApi.Interfaces;
using SimpleNotesApi.Models;

namespace SimpleNotesApi.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly SimpleNotesContext _context;
        private readonly ILogger<NotesRepository> _logger;
        public NotesRepository(SimpleNotesContext database, ILogger<NotesRepository> logger)
        {
            _context = database;
            _logger = logger;
        }

        public async Task createNode(DescriptionTitleNote note)
        {
            try
            {
                Note temp = new Note
                {
                    Description = note.Description,
                    Title = note.Title,
                };
                _context.Notes.Add(temp);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Note has been created");

            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Data base error:{ex.Message}");
                return;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to create the note: {ex}");
                return;
            }

        }

        public async Task<Note?> deleteNote(int id)
        {
            try
            {
                var note = await _context.Notes
                .FirstOrDefaultAsync(m => m.Id == id);
                if (note == null)
                {
                    return null;
                }
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Note has been deleted");
                return note;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Data base error:{ex.Message}");
                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to delete the note:{ex.Message}");
                return null;

            }
        }

        public async Task<Note?> editNote(int id, DescriptionTitleNote semiNote)
        {
            try
            {
                var existingNote = await _context.Notes
                            .FirstOrDefaultAsync(m => m.Id == id);
                if (existingNote != null)
                {
                    // Retain the Created timestamp from the existing note
                    existingNote.Description = semiNote.Description;
                    existingNote.Title = semiNote.Title;

                    // Update the note in the context
                    _context.Update(existingNote);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Note has been edited");
                    return existingNote;

                }
                return null;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Data base error:{ex.Message}");
                return null;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to edit the note :{ex.Message}");
                return null;

            }
        }

        public async Task<Note?> getNodeDetails(int id)
        {
            try
            {
                return await _context.Notes.FindAsync(id);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Data base error:{ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get a note's details :{ex.Message}");
                return null;
            }
        }

        public async Task<List<Note>> getNodes()
        {
            try
            {
                return await _context.Notes.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Data base error:{ex.Message}");
                return new List<Note>();  // You can return an empty list or null
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to fetch notes :{ex.Message}");
                return new List<Note>();
            }
        }

    }
}
