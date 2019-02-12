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
    public class VacationController : ControllerBase
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

        public VacationController(IConfiguration configuration)
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
        /// Возвращает выгрузку с отпусками.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            return _repository.GetData<Vacation>(_queries.Where(q
                => q.Name == "Vacation")?.FirstOrDefault()?.Query)?.Result.ToList();
        }

        /// <summary>
        /// Возвращает коллекцию с отпусками конкретного пользователя.
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IEnumerable<Vacation> Get(int userId)
        {
            return Get()?.Where(s => s.UserId == userId)?.ToList();
        }

        /// <summary>
        /// Добавляет новую запись отпуска в БД.
        /// </summary>
        [HttpPut]
        public void Put(Vacation vacation)
        {
            _repository.LoadData(_queries.Where(q
                => q.Name == "VacationInsert")?
                .FirstOrDefault()?
                .Query, new List<Vacation> { vacation });
        }

        /// <summary>
        /// Удаляет запись отпуска из таблицы по идентификатору.
        /// </summary>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ///TODO: добавить индентификатор отпусков в модель и БД.
        }

        #endregion
    }
}