using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleNotesApi.Database;
using SimpleNotesApi.Interfaces;
using SimpleNotesApi.Models;

namespace SimpleNotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        // GET: Notes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _noteService.getNodes());
        }

        // GET: Notes/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var note = await _noteService.getNodeDetails(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // POST: Notes/Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DescriptionTitleNote note)
        {
            if (ModelState.IsValid)
            {
                await _noteService.createNode(note);
                return RedirectToAction(nameof(Index));
            }
            return BadRequest(note);
        }

        // POST: Notes/Edit/5
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] DescriptionTitleNote SemiNote)
        {
            if (ModelState.IsValid)
            {
                var result = await _noteService.editNote(id, SemiNote);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            return BadRequest(SemiNote);  // Return BadRequest if the model state is not valid.
        }


        // GET: Notes/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var note = await _noteService.deleteNote(id);
            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }


    }
}
