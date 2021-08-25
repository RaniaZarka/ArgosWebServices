using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.ViewModel;

namespace EventMaker.Model
{
    public class Event
    {
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTime _date;

        public Event(int id, string name, string description, string place, DateTime date)
        {
            _name = Name;
            _id = Id;
            _description = Description;
            _place = Place;
            _date = Date;

        }
        public Event() { }

        public string Name
        {
            get { return _name;}
            set { _name = value; }
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public string Place { get; set; }
        public DateTime Date { get; set;  }

       

        /*public override string ToString()
      
        {
            return $"Event name: {Name} Event Id: {Id} Event Description: {Description} Event Place: {Place} Event Date: {Date} ";
        }*/

    }
}
