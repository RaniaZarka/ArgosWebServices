using AppExercice.Common;
using AppExercice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;

namespace AppExercice.ViewModel
{
    public class StoresViewModel : INotifyPropertyChanged
    {
       
        private readonly StoresCatalog _storesCatalog;
        private Stores _selectedStore;
        private readonly DeleteCommand _deletionCommand;
        private string _imageSource;

        public StoresViewModel()
        {
            _storesCatalog = new StoresCatalog();
            _selectedStore = null;
            AddStoreCommand = new RelayCommand(AddStore);
            _deletionCommand = new DeleteCommand(_storesCatalog, this);
        }

        public ICommand AddStoreCommand { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Category { get; set; }
        public string OpeningHours { get; set; }

        public string ImageSource
        {
            get => _imageSource;
            //  set => _imageSource = "..\\Assets\\" + value;
            set => _imageSource = ApplicationData.Current.LocalFolder.Path + "\\" + value;
        }

        public Stores SelectedStore
        {
            get => _selectedStore;
            set
            {
                _selectedStore = value;
                OnPropertyChanged();
                _deletionCommand.RaiseCanExecuteChanged();
            }
        }

        public DeleteCommand DeletionCommand => _deletionCommand;

        public ObservableCollection<Stores> StoreCollection => _storesCatalog.Stores;

        public void AddStore()
        {
            _storesCatalog.AddStore(new Stores(Name, Phone, Website, Category, OpeningHours, ImageSource));
            //here i can have an if statement for the admin so only the admin can acces it 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

