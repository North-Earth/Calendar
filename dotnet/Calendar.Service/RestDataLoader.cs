using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Service
{
    public class RestDataLoader : IRestDataLoder
    {
        #region Fields

        #endregion

        #region Constructor

        /// <param name="url">URL адресс API сервера</param>
        public RestDataLoader(string url)
        {

        }

        #endregion

        #region Methods

        public bool ChangeData<T>(T data) where T : class
        {
            throw new NotImplementedException();
        }

        public bool DeleteData<T>(T data) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetData<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(T data) where T : class
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
