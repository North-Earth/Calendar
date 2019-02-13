using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Service
{
    internal interface IRestDataLoder
    {
        #region Methods

        /// <summary>
        /// Возвращает коллекцию моделей данных.
        /// </summary>
        /// <typeparam name="T">Модель данных</typeparam>
        Task<IEnumerable<T>> GetData<T>() where T : class;

        /// <summary>
        /// Передаёт модель данных для записи и возвращает результат.
        /// </summary>
        /// <param name="data">Модель данных</param>
        bool SetData<T>(T data) where T : class;

        /// <summary>
        /// Передаёт модель данных для изменения и возвращает результат.
        /// </summary>
        /// <param name="data">Модель данных</param>
        bool ChangeData<T>(T data) where T : class;

        /// <summary>
        /// Передаёт модель данных для удаления и возвращает результат.
        /// </summary>
        /// <param name="data">Модель данных</param>
        bool DeleteData<T>(T data) where T : class;

        #endregion
    }
}
