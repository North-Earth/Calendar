using Calendar.Library.Models;
using Calendar.Service.Helper.Binding;
using System.Collections.ObjectModel;

namespace Calendar.Client.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private ObservableCollection<Staff> _staff { get; set; }
        /// <summary>
        /// Коллекция данных персонала(пользователей)
        /// </summary>
        public ObservableCollection<Staff> Staff
        {
            get => _staff;
            set { _staff = value; RaiseOnPropertyChanged(); }
        }

        private ObservableCollection<Vacation> _vacation { get; set; }
        /// <summary>
        /// Коллекция данных отпусков.
        /// </summary>
        public ObservableCollection<Vacation> Vacation
        {
            get => _vacation;
            set { _vacation = value; RaiseOnPropertyChanged(); }
        }

        private ObservableCollection<Color> _color { get; set; }
        /// <summary>
        /// Коллекция цветов.
        /// </summary>
        public ObservableCollection<Color> Color
        {
            get => _color;
            set { _color = value; RaiseOnPropertyChanged(); }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {

        }

        #endregion

        #region Methods

        #endregion
    }
}
