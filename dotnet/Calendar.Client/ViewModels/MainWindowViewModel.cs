using Calendar.Library.Models;
using Calendar.Service;
using Calendar.Service.Helper.Binding;
using Calendar.Service.Helper.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calendar.Client.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Fields

        /// <summary>
        /// Интерфейс взаимодействия с REST сервисом.
        /// </summary>
        private readonly IRestDataLoader dataLoader;

        private ObservableCollection<Staff> _staff { get; set; }
        /// <summary>
        /// Коллекция данных персонала(пользователей).
        /// </summary>
        public ObservableCollection<Staff> Staff
        {
            get => _staff;
            set { _staff = value; RaiseOnPropertyChanged(); }
        }

        private Staff _selectedUser { get; set; }
        /// <summary>
        /// Модель выбранного пользователя.
        /// </summary>
        public Staff SelectedUser
        {
            get => _selectedUser;
            set { _selectedUser = value; RaiseOnPropertyChanged(); SelectUser(); }
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

        private IEnumerable<Vacation> _userVacations { get; set; }
        /// <summary>
        /// Коллекция с отпусками выбранного пользователя.
        /// </summary>
        public IEnumerable<Vacation> UserVacations
        {
            get => _userVacations;
            set { _userVacations = value; RaiseOnPropertyChanged(); }
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

        private Visibility _isDataLoad { get; set; }

        public Visibility IsDataLoad
        {
            get => _isDataLoad;
            set { _isDataLoad = value; RaiseOnPropertyChanged(); }
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

        #endregion TEST

        #endregion Command

        #endregion Fields

        #region Constructors

        public MainWindowViewModel()
        {
            //Вынести URL в статический ресурс.
            dataLoader = new RestDataLoader("http://localhost:51963");

            StartAsync();

            ShutdownCommand = new DelegateCommand(param => { Shutdown(); });
            TestCommand = new DelegateCommand(param => { Test(); });
        }

        #endregion

        #region Methods

        /// <summary>
        /// Запускает асинхронно процессы приложения.
        /// </summary>
        /// <returns></returns>
        public async Task StartAsync()
        {
            try
            {
                await Task.Run(() => AutoUpdateAsync());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Непредвиденное исключение");
            }
        }

        /// <summary>
        /// Каждые 30 секунд обновляет данные приложения.
        /// </summary>
        /// <returns></returns>
        public async Task AutoUpdateAsync()
        {
            //Счётчик повторных ошибок подключения.
            int errorCount = 0;

            while (errorCount <= 3)
            {
                try
                {
                    IsDataLoad = Visibility.Visible;

                    await Task.Run(() => UpdateDataAsync());

                    //Сбрасываем счётчик ошибок.
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    //TODO: добавить логирование.
                }
                finally
                {
                    IsDataLoad = Visibility.Hidden;
                }

                //Ожидание 30 секунд до следующего обновления.
                await Task.Delay(30000);
            }

            throw new Exception("Превышено допустимое количество повторных попыток автоматического подключения к API сервису.");
        }

        /// <summary>
        /// Обновляет данные пользователей и отпусков.
        /// </summary>
        public async Task UpdateDataAsync()
        {
            //throw new Exception();
            var dataStaff = await dataLoader.GetData<Staff>("staff");
            Staff = new ObservableCollection<Staff>();
            dataStaff?.ToList().ForEach(Staff.Add);

            var dataVacation = await dataLoader.GetData<Vacation>("vacations");
            Vacations = new ObservableCollection<Vacation>();
            dataVacation?.ToList().ForEach(Vacations.Add);
        }

        /// <summary>
        /// Делает выборку отпусков по выбраному пользователю.
        /// </summary>
        private void SelectUser()
            => UserVacations = Vacations?.Where(v
                => v.UserId == SelectedUser?.Id) ?? default;

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
