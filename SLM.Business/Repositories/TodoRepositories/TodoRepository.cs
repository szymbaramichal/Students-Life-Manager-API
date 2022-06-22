using Microsoft.EntityFrameworkCore;
using SLM.Data;
using SLM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLM.Business.Repositories.TodoRepositories;

public class TodoRepository : ITodoRepository
{
    #region Variables
    private readonly DataContext context;

    #endregion

    #region Constructor
    public TodoRepository(DataContext context)
    {
        this.context = context;
    }
    #endregion

    #region Interface Methods
    /// <inheritdoc/>
    public int Add(TodoEntity todoEntity)
    {
        todoEntity.CreationDate = DateTime.UtcNow;
        todoEntity.ModificationDate = DateTime.UtcNow;
        context.Todos.Add(todoEntity);

        context.SaveChanges();

        return todoEntity.Id;
    }

    /// <inheritdoc/>
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public ICollection<TodoEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<TodoEntity> GetById(int id)
    {
        var todo = await context.Todos.FirstOrDefaultAsync(x => x.Id == id);
        return todo;
    }

    /// <inheritdoc/>
    public void Update(TodoEntity todoEntity)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Private methods
    private async Task<bool> TodoExists(int id)
    {
        return await context.Todos.AnyAsync(x => x.Id == id);
    }
    #endregion
}

