using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Persistency;
using EventMaker.ViewModel;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {

        public ObservableCollection<Event> events { get; set; }

        private static EventCatalogSingleton _Instance;
        public  EventCatalogSingleton()
        {
            events = new ObservableCollection<Event>();
            events.Add(new Event(1, "Roskilde festival", "Music", "Roskilde", new DateTime(2020,6,9,0,0,0)));
            events.Add(new Event(2, "Shopping days", "Sale", "Roskilde", new DateTime(2020,6,23,0,0,0)));

            //LoadEventsAsync();
        }

       /* public async void LoadEventsAsync()
        {
            List<Event> collection;
            collection = await PersistencyService.LoadEventsFromJsonAsync();
            if (collection != null)
            {
                foreach (var ev in collection)
                
                {
                    events.Add(ev);
                }
            }
        }*/

        public static EventCatalogSingleton Instance
        {
            get
            {
                if (_Instance != null)
                    return _Instance;
                else return _Instance=new EventCatalogSingleton();

                //return _Instance??(_Instance=new EventCatalogSingleton());
                // the last line means exactly like the if statement 
            }
        }
        public void AddEvent(Event ev)
        {
            events.Add(ev);
            PersistencyService.SaveEventsAsJsonAsync(events);
            
        }

        public void DeleteEvent(Event ev) 
        {
            events.Remove(ev);
            PersistencyService.SaveEventsAsJsonAsync(events);

        }
    }
}
