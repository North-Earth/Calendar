using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Service
{
    public interface IRestDataLoader
    {
        #region Methods

        /// <summary>
        /// Возвращает коллекцию моделей данных.
        /// </summary>
        /// <typeparam name="T">Тип модели данных</typeparam>
        /// <param name="controllerName">Название контроллера</param>
        Task<IEnumerable<T>> GetData<T>(string controllerName) where T : new();

        /// <summary>
        /// Передаёт модель данных для записи.
        /// </summary>
        /// <param name="data">Модель данных</param>
        /// <param name="controllerName">Название контроллера</param>
        void SetData<T>(string controllerName, T data) where T : class;

        /// <summary>
        /// Передаёт модель данных для изменения.
        /// </summary>
        /// <param name="data">Модель данных</param>
        /// <param name="controllerName">Название контроллера</param>
        void ChangeData<T>(string controllerName, T data) where T : class;

        /// <summary>
        /// Передаёт модель данных для удаления.
        /// </summary>
        /// <param name="data">Модель данных</param>
        /// <param name="controllerName">Название контроллера</param>
        void DeleteData<T>(string controllerName, T data) where T : class;

        #endregion
    }
}
