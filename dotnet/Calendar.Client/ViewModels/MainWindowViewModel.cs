using Calendar.Library.Models;
using Calendar.Service.Helper.Binding;
using Calendar.Service.Helper.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Calendar.Client.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        private ObservableCollection<Staff> _staff { get; set; }
        /// <summary>
        /// Коллекция данных персонала(пользователей).
        /// </summary>
        public ObservableCollection<Staff> Staff
        {
            get => _staff;
            set { _staff = value; RaiseOnPropertyChanged(); }
        }

        private Staff _selectedStaff { get; set; }
        /// <summary>
        /// Модель выбранного пользователя.
        /// </summary>
        public Staff SelectedUser
        {
            get => _selectedStaff;
            set { _selectedStaff = value; RaiseOnPropertyChanged(); Test2(); }
        }

        private ObservableCollection<Vacation> _vacations { get; set; }
        /// <summary>
        /// Коллекция данных отпусков.
        /// </summary>
        public ObservableCollection<Vacation> Vacations
        {
            get => _vacations;
            set { _vacations = value; RaiseOnPropertyChanged(); }
        }

        /// <summary>
        /// Коллекция с отпусками выбранного пользователя.
        /// </summary>
        public IEnumerable<Vacation> UserVacation => Vacations?.Where(v => v.UserId == SelectedUser?.Id) ?? default;

        private ObservableCollection<Color> _color { get; set; }
        /// <summary>
        /// Коллекция цветов.
        /// </summary>
        public ObservableCollection<Color> Color
        {
            get => _color;
            set { _color = value; RaiseOnPropertyChanged(); }
        }

        #region Command

        private ICommand _shutdownCommand { get; set; }
        /// <summary>
        /// Команда отвечающая за выход из приложения.
        /// </summary>
        public ICommand ShutdownCommand
        {
            get => _shutdownCommand;
            set => _shutdownCommand = value;
        }

        #region TEST

        private ICommand _testCommand { get; set; }
        public ICommand TestCommand
        {
            get => _testCommand;
            set => _testCommand = value;
        }

        public void Test()
        {
            Staff = new ObservableCollection<Staff>
            {
                new Staff { Id = 1, Name = "Энтони Эдвард Старк", ColorId = 1 },
                new Staff { Id = 2, Name = "Питер Паркер", ColorId = 1 },
                new Staff { Id = 3, Name = "Джеймс Хоулетт", ColorId = 1 }
            };

            Vacations = new ObservableCollection<Vacation>
            {
                new Vacation { Id = 1, UserId = 1, CountDays = 10, StartDate = DateTime.Now, EndDate = DateTime.Now },
                new Vacation { Id = 2, UserId = 2, CountDays = 20, StartDate = DateTime.Now, EndDate = DateTime.Now },
                new Vacation { Id = 3, UserId = 3, CountDays = 5, StartDate = DateTime.Now, EndDate = DateTime.Now },
                new Vacation { Id = 4, UserId = 3, CountDays = 9, StartDate = DateTime.Now, EndDate = DateTime.Now },
            };
        }

        public void Test2()
        {
            var a = UserVacation.ToList();
            var b = Vacations?.Where(v => v.UserId == SelectedUser?.Id);
            var c = Vacations?.Where(v => v.UserId == SelectedUser?.Id).ToList();
            bool IsDebug = true;
        }

        #endregion TEST

        #endregion Command

        #endregion Fields

        #region Constructors

        public MainWindowViewModel()
        {
            ShutdownCommand = new DelegateCommand(param => { Shutdown(); });
            TestCommand = new DelegateCommand(param => { Test(); });
        }

        #endregion

        #region Methods

        public void UpdateData()
        {

        }

        public void UpdateUserVacation()
        {

        }

        /// <summary>
        /// Завершает работу приложения.
        /// </summary>
        public void Shutdown()
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
