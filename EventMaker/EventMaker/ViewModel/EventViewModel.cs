using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Model;
using EventMaker.ViewModel;

namespace EventMaker.ViewModel
{
    class EventViewModel: INotifyPropertyChanged
    {
       
        public EventCatalogSingleton CatalogSingleton { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }
        public Handler.EventHandler eventHandler { get; set; }
        
        public Event SelectedEvent { get; set; }
        public ICommand CreateEventCommand { get; set; }
        public ICommand DeleteEventCommand { get; set; }
        public EventViewModel()
        {
            CatalogSingleton = EventCatalogSingleton.Instance;
            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second); 
            eventHandler = new Handler.EventHandler(this);
            CreateEventCommand = new RelayCommand(eventHandler.CreateEvent);
            DeleteEventCommand = new RelayCommand(eventHandler.DeleteAnEvent);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}