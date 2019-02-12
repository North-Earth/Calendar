using Calendar.DataAccess.Models;
using Calendar.Library.Models;
using Calendar.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Calendar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        #region Fields

        /// <summary>
        /// Интерфейс для работы с БД.
        /// </summary>
        private readonly IRepository _repository;

        /// <summary>
        /// Файл конфигурации, используется для извлечения запросов к БД.
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Коллекция с Sql запросами.
        /// </summary>
        private readonly IEnumerable<SqlQuery> _queries;

        #endregion

        #region Constructors

        public StaffController(IConfiguration configuration)
        {
            _configuration = configuration;
            _queries = _configuration?.GetSection("SqlQueries")?
                .Get<IEnumerable<SqlQuery>>();

            _repository = new Repository(_configuration?
                .GetConnectionString("DefaultConnection"));
        }

        #endregion

        #region Methods

        /// <summary>
        /// Возвращает выгрузку из таблицы с персоналом.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Staff> Get()
        {
            return _repository.GetData<Staff>(_queries.Where(q
                => q.Name == "StaffSelect")?.FirstOrDefault()?.Query)?.Result.ToList();
        }

        /// <summary>
        /// Возвращает модель опреденного пользователя из таблицы персонала.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Staff Get(int id)
        {
            return Get()?.Where(s => s.Id == id)?.FirstOrDefault();
        }

        /// <summary>
        /// Добавляет нового пользователя в таблицу с персоналом.
        /// </summary>
        [HttpPut]
        public void Put(Staff staff)
        {
            _repository.LoadData(_queries.Where(q
                => q.Name == "StaffInsert")?
                .FirstOrDefault()?
                .Query, new List<Staff> { staff });
        }

        /// <summary>
        /// Удаляет пользователя из таблицы по идентификатору.
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var staff = Get()?.Where(s => s.Id == id)?.FirstOrDefault();

            _repository.LoadData(_queries.Where(q
                => q.Name == "StaffDelete")?
                .FirstOrDefault()?
                .Query, new List<Staff> { staff });
        }

        #endregion
    }
}