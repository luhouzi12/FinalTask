using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1.Common
{
    public interface IRepository
    {

        Task<List<ToDoItem>> QueryAllAsync();
        Task DeleteAsync(string id);
        Task<ToDoItem> GetAsync(string id);
        Task<List<ToDoItem>> QueryAsync(string id);
        Task<ToDoItem> UpdateAsync(string id, ToDoItem updateModel);
        Task UpsertAsync(ToDoItem model);
    }
}