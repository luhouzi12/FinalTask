using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1.Common
{
    public class MemoryRepository:IRepository
    {
        private readonly Dictionary<string, ToDoItem> _dic = new Dictionary<string, ToDoItem>();

        public MemoryRepository()
        {
            Init();
        }
        public async Task<List<ToDoItem>> QueryAllAsync(
)
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            return models.ToList();
        }

        public async Task<ToDoItem> GetAsync(string id)
        {
            _dic.TryGetValue(id, out var item);
            return item;
        }

        public async Task UpsertAsync(ToDoItem model)
        {
            _dic[model.Id] = model;
        }

        public async Task DeleteAsync(string id)
        {
            if (_dic.ContainsKey(id))
                _dic.Remove(id);
        }

        public async Task<List<ToDoItem>> QueryAsync(
            string id)
        {
            IEnumerable<ToDoItem> models = _dic.Values.ToList();
            models = models.Where(v => v.Id == id);
            return models.ToList();
        }

        public async Task<ToDoItem> UpdateAsync(string id, ToDoItem updateModel)
        {
            if (_dic.TryGetValue(id, out var item))
            {
                if (!string.IsNullOrEmpty(updateModel.Description))
                    item.Description = updateModel.Description;

                if (updateModel.Favorite != null)
                    item.Favorite = updateModel.Favorite;

                if (updateModel.Done != null)
                    item.Done = updateModel.Done;

                return item;
            }
            return null;
        }


        private void Init()
        {
            for (var i = 1; i < 3; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i.ToString(),
                    CreatedTime = DateTime.UtcNow,
                    Description = $"test item {i}",
                    Done = false,
                    Favorite = false,
                    Children = null
                };
                _dic[item.Id] = item;
            }
        }


    }
}
