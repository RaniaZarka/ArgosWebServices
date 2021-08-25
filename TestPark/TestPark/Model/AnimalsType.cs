using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPark.Model
{
    class AnimalsType
    {
        private int _typeId;
        private string _country;
        private string _endangeredLevel;
        private int _mapLocation;
        private string _type;

        public AnimalsType(int typeId, string country, string endangeredLevel, int mapLocation, string type)
        {
            _country = country;
            _endangeredLevel = endangeredLevel;
            _mapLocation = mapLocation;
            _type = type;
        }

        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string EndangeredLevel
        {
            get { return _endangeredLevel; }
            set { _endangeredLevel = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public int MapLocation
        {
            get { return _mapLocation; }
            set { _mapLocation = value; }
        }

        public override string ToString()
        {
            return $" Type Id is {TypeId} Type: {Type} Country: {Country} Endagered Level: {EndangeredLevel} Map location {MapLocation} ";
        }
        
    }
}
