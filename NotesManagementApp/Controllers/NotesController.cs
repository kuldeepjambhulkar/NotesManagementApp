using Microsoft.AspNetCore.Mvc;
using NotesManagementApp.Models;
using NotesManagementApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace NotesManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INotesService notesService;

        public NotesController(INotesService notesService)
        {
            this.notesService = notesService;   
        }

        // GET: api/<NotesController>
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            return notesService.Get();
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public ActionResult<Note> Get(string id)
        {
            var note = notesService.Get(id);
            if (note == null) { 
                return NotFound($"Note with {id} not found!");
            }
            return note;
        }

        // POST api/<NotesController>
        [HttpPost]
        public ActionResult<Note> Post([FromBody] Note note)
        {
            notesService.Create(note);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Note note)
        {
            var existingNote = notesService.Get(id);
            if (existingNote == null)
            {
                return NotFound($"Note with {id} not found!");
            }
            notesService.Update(id, note);
            return NoContent();
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var existingNote = notesService.Get(id);
            if (existingNote == null)
            {
                return NotFound($"Note with {id} not found!");
            }
            notesService.Remove(existingNote.Id);
            return Ok($"Note with id = {id}, deleted");
        }
    }
}
