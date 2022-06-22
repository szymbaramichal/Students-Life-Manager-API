using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SLM.Business.Repositories;
using SLM.Business.Repositories.TodoRepositories;
using SLM.Common.Dtos.Todo;
using SLM.Common.Dtos.Todo.Command;
using SLM.Common.Enums;
using SLM.Data.Entities;
using Students_Life_Manager_API.Resources;

namespace SLM.API
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        public readonly ITodoRepository todoRepository;
        public readonly IMapper mapper;
        public TodosController(ITodoRepository todoRepository, IMapper mapper)
        {
            this.todoRepository = todoRepository;
            this.mapper = mapper;
        }


        [HttpPost("create")]
        public ActionResult<int> Post(CreateTodoCommand command)
        {
            if (command == null)
            {
                return BadRequest(ControllerMessage.RequestNull);
            }

            var todoEntity = mapper.Map<TodoEntity>(command);

            switch (command.TodoType) {
                case 0:
                    todoEntity.TodoType = TodoType.Task;
                    break;
                case 1:
                    todoEntity.TodoType = TodoType.Important;
                    break;
                case 2:
                    todoEntity.TodoType = TodoType.Reminder;
                    break;
                default:
                    return BadRequest(ControllerMessage.InvalidTodoType);
            }


            todoRepository.Add(todoEntity);

            return Ok(todoEntity.Id);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<TodoDto>> Get(int id)
        {
            if (id == null)
            {
                return BadRequest(ControllerMessage.RequestNull);
            }

            var todoEntity = await todoRepository.GetById(id);

            if(todoEntity is null)
            {
                return NotFound($"{ControllerMessage.NotFoundTodo} {id}");
            }

            return Ok(mapper.Map<TodoDto>(todoEntity));
        }
    }
}