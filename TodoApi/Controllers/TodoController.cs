using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using Microsoft.Extensions.Logging;
using TodoApi.Common.Exceptions;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly ILogger<TodoController> _logger;
        private IOLPRRService _lustService;

        public TodoController(TodoContext context, ILogger<TodoController> logger, IOLPRRService lustService)
        {
            _logger = logger;
            _context = context;
            _lustService = lustService;
            if (_context.TodoItems.Count() == 0)
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<IActionResult> GetTodoItems()
        //public async Task<IHttpActionResult> GetTodoItems()
        {
            //_logger.LogError("HELLO FROM TODOCONTROLLER BEFORE I THROW AN EXCEPTION");
            //throw new ResourceNotFoundException("hellllllllllllllllllllllllllllllllllooooooooooo");

            //string[] arrRetValues = null;
            //if (arrRetValues.Length > 0)
            //{ }
            //return Ok(_context.TodoItems);


            //var x = await _olprrService.InsertOLPRRIncidentRecord();

            //var siteTypes = await _olprrService.GetSiteTypes();

            return Ok(await _lustService.GetSiteTypes());
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "GetTodo")]
        public async Task<IActionResult> GetTodoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItem = await _context.TodoItems.SingleOrDefaultAsync(m => m.Id == id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return Ok(todoItem);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem([FromRoute] long id, [FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Todo
        [HttpPost]
        public async Task<IActionResult> PostTodoItem([FromBody] TodoItem todoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoItem = await _context.TodoItems.SingleOrDefaultAsync(m => m.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return Ok(todoItem);
        }

        private bool TodoItemExists(long id)
        {
            return _context.TodoItems.Any(e => e.Id == id);
        }
    }
}