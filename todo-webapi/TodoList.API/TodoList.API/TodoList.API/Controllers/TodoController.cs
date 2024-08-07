using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.API.Data;
using TodoList.API.Models;

namespace TodoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ApiCorsPolicy")]
    public class TodoController : ControllerBase
    {
            private readonly TodoDbContext _todoDbContext;

            public TodoController(TodoDbContext todoDbContext)
            {
                _todoDbContext = todoDbContext;
            }

            [HttpGet("getAllTodos")]
            public async Task<IActionResult> GetAllTodos() // this method will return all the todos created 
            {
            //var todos = await _todoDbContext.Todos.ToListAsync();
            // but in the case of deletetion this line will fail as after click on delete button also it will show all todos so we need to apply the condition here that if todo is deleted then it will not show in the frontend todos table
            // Todos -> this is the DB table name where all frontend fields value stored
            var todos = await _todoDbContext.Todos
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();

            return Ok(todos);
            }

           [HttpPost]
           public async Task<IActionResult> AddTodo(Todo todo)
        {
            todo.Id = Guid.NewGuid();
            // Add(todo) -> Add is the property of Microsoft.EntityFrameworkCore
            // 2. And todo is the variable and we initializes in the method AddTodo
            _todoDbContext.Todos.Add(todo);
            // 
            await _todoDbContext.SaveChangesAsync();

            return Ok(todo);


        }

        [HttpPut]
        [Route("{Id:Guid}")] //here id is coming from front end like we are searching the record through the id then we will click on checkbox
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, Todo todoUpdateRequest) { // THE id and Todo attribute is coming from the ts file by giving user input

            var todo = await _todoDbContext.Todos.FindAsync(id); // how we will identify which record has marked as completed through id so we are searching todo task from db through the id

            if(todo == null)
            {
                return NotFound();
            }

            todo.IsCompleted = todoUpdateRequest.IsCompleted; // we are updating Iscompleted flag of model from the value todoUpdateRequest coming from front end
            todo.CompletedDate = DateTime.Now; // we are updating completedate of todo model as a current clicing date and time 

            await _todoDbContext.SaveChangesAsync(); // we are saving the details in the database

            return Ok(todo); // returning the todo model
        }

        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> DeleteTodo([FromRoute] Guid id)
        {
            var todo = await _todoDbContext.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            todo.IsDeleted = true;
            todo.DeletedDate = DateTime.Now;

            await _todoDbContext.SaveChangesAsync();

            return Ok(todo);
        }
        }
    }

