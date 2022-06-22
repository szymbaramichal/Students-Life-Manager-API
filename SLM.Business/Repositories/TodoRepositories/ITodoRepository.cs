using SLM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.Business.Repositories.TodoRepositories;

public interface ITodoRepository
{
    /// <summary>
    /// Add new Todo
    /// </summary>
    /// <param name="todoEntity">Todo to add</param>
    /// <returns>New todo id</returns>
    int Add(TodoEntity todoEntity);

    /// <summary>
    /// Update existing Todo
    /// </summary>
    /// <param name="todoEntity">Todo to update</param>
    void Update(TodoEntity todoEntity);

    /// <summary>
    /// Get Todo by id
    /// </summary>
    /// <param name="id">Todo id</param>
    /// <returns>Todo Entity</returns>
    Task<TodoEntity> GetById(int id);

    /// <summary>
    /// Get all todos
    /// </summary>
    /// <returns>Collection of Todos</returns>
    ICollection<TodoEntity> GetAll();

    /// <summary>
    /// Delete existing Todo
    /// </summary>
    /// <param name="id">Todo id</param>
    void Delete(int id);
}

