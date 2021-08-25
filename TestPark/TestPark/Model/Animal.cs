using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPark.Model
{
    class Animal
    {
        private int _aId;
        private string _name;
        private DateTime _dateOfBirth;
        


  public Animal( int aid, string name, DateTime dateOfBirth )
        {
            _aId = aid;
            _name = name;
            _dateOfBirth = dateOfBirth;
            
        }
        public int AId
        {
            get { return _aId; }
            set { _aId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        
        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }


        public override string ToString()
        {
            return $" ID: {AId} Name: {Name} Date of birth: {DateOfBirth} ";
        }

    }
}
