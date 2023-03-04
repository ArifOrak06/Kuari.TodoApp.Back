using Kuari.TodoApp.Core.DTOs;
using Kuari.TodoApp.Core.Entities;
using Kuari.TodoApp.Core.Services;
using Kuari.TodoApp.SharedLibrary.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kuari.TodoApp.WebAPI.Controllers
{

    public class TodosController : CustomBaseController
    {
        private readonly IService<ToDo, TodoListDto, TodoCreateDto, TodoUpdateDto> _service;

        public TodosController(IService<ToDo, TodoListDto, TodoCreateDto, TodoUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos()
        {
            var result = await _service.GetAllAsync();
            return CreateActionResult<IEnumerable<TodoListDto>>(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return CreateActionResult<TodoListDto>(result);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(TodoCreateDto todoCreateDto)
        {
            var result = await _service.AddAsync(todoCreateDto);
            return CreateActionResult<TodoCreateDto>(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(TodoUpdateDto todoUpdateDto)
        {
            var result = await _service.UpdateAsync(todoUpdateDto, todoUpdateDto.Id);
            return CreateActionResult<TodoUpdateDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var result = await _service.DeleteAsync(id);
            return CreateActionResult<NoContentDto>(result);
        }
        

    }
}
