using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Library.Repositories
{
    public class Repository : IRepository
    {
        #region Fields

        /// <summary>
        /// Строка подключения к БД.
        /// </summary>
        private readonly string _connectionString = null;

        #endregion

        #region Constructors

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Возвращает колекцию данных из БД.
        /// </summary>
        /// <typeparam name="T">Модель данных</typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetData<T>(string sqlQuery) where T : class
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var data = await connection.QueryAsync<T>(sqlQuery);
                return data.ToList();
            }
        }

        /// <summary>
        /// Выполняет запрос записиси/удаления данных в БД.
        /// </summary>
        /// <typeparam name="T">Модель данных</typeparam>
        /// <param name="data">Колекция данных</param>
        public async void LoadData<T>(string sqlQuery, IEnumerable<T> data) where T : class
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, data);
            }
        }

        #endregion
    }
}
