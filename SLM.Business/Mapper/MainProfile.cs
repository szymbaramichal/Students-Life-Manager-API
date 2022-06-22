using AutoMapper;
using SLM.Common.Dtos.Todo;
using SLM.Common.Dtos.Todo.Command;
using SLM.Data.Entities;

namespace SLM.Business.Mapper;

public class MainProfile : Profile
{
    public MainProfile()
    {
        CreateMap<CreateTodoCommand, TodoEntity>();
        CreateMap<TodoDto, TodoEntity>().ReverseMap();
    }
}
