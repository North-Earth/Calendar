using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calendar.Service.Helper.Binding
{
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        protected virtual void RaiseOnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (string.IsNullOrEmpty(prop))
                throw new ArgumentException("Значение не может быть пустым или NULL");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

    }
}
