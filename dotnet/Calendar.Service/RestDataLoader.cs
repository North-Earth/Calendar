using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Service
{
    public class RestDataLoader : IRestDataLoader
    {
        #region Fields

        private readonly IRestClient _client;

        #endregion

        #region Constructor

        /// <param name="url">URL адресс API сервера</param>
        public RestDataLoader(string url)
            => _client = new RestClient(url);

        #endregion

        #region Methods

        /// <summary>
        /// Возвращает коллекцию моделей данных.
        /// </summary>
        /// <typeparam name="T">Тип модели данных</typeparam>
        /// <param name="controllerName">Название контроллера</param>
        public async Task<IEnumerable<T>> GetData<T>(string controllerName) where T : new()
        {
            var request = new RestRequest($"api/{controllerName}", Method.GET);

            var response = _client.Execute<List<T>>(request);

            //Если нет ошибок возвращаем резульатат.
            if (response.ErrorException == null)
            {
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        return response.Data;
                        //TODO: обработка статусов.
                    default:
                        break;
                }
                throw new Exception();
            }
            else
                throw new Exception(); //TODO: Анализировать и обработать возможные ошибки.
        }

        public void SetData<T>(string controllerName, T data) where T : class
        {
            var request = new RestRequest($"api/{controllerName}", Method.PUT);
            request.AddJsonBody(data);

            var response = _client.Execute(request);

            if (response.ErrorException != null)
                throw new Exception(); //TODO: Анализировать и обработать возможные ошибки.
        }

        public void ChangeData<T>(string controllerName, T data) where T : class
        {
            throw new NotImplementedException();
        }

        public void DeleteData<T>(string controllerName, T data) where T : class
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
