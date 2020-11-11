using ConsoleApp1.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoItemController : ControllerBase
    {
        private IRepository _repository;
        private readonly GetOptions _getOptions = new GetOptions();
        public ToDoItemController(IRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            configuration.Bind("GetOptions", _getOptions);
        }

        /// <summary>
        /// Query ToDoItem by specific description and done
        /// </summary>
        /// <remarks>
        /// In remarks, we can document some detail information
        /// </remarks>
        /// <param name="description">ToDoItem description</param>
        /// <param name="done">ToDoItem status</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> QueryallAsync()
        {
            var list = await _repository.QueryAllAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetSpecifiedAsync(
    string id)
        {
            var item = await _repository.GetAsync(id);
            return item;
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddAsync(//add
            [Required] ToDoItem updateModel)
        {
             await _repository.UpsertAsync(updateModel);
            var item = await _repository.GetAsync(updateModel.Id);
            if (item == null)
                return new ObjectResult(500) { };
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteAsync(
            [Required] string id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]//put
        public async Task<ActionResult<ToDoItem>> UpsertAsync(
            [Required] ToDoItem model)
        {
             await _repository.UpsertAsync(model);
            var item = await _repository.GetAsync(model.Id);
            if (item == null)
                return new ObjectResult(500) { };
            return Ok(item);
        }
    }
}
