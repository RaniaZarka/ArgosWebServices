using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Converter;
using EventMaker.Model;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    class EventHandler
    {
        public EventViewModel Evm { get; set; }

        public EventHandler(EventViewModel evm)
        {
            Evm = evm;
        }

        public void CreateEvent()
        {
            DateTime dt = DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(Evm.Date, Evm.Time);
            Event ev = new Event(Evm.Id, Evm.Name, Evm.Description, Evm.Place,dt);
            Evm.CatalogSingleton.AddEvent(ev);
        }

        public void DeleteAnEvent()
        {
            
            Evm.CatalogSingleton.DeleteEvent(Evm.SelectedEvent);
        }

    }
}

