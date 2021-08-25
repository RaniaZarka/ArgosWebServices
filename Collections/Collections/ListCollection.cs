
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
   public class ListCollection
    {
        private string _name;
        private int _age;

        public ListCollection(string name, int age)
        {
            name = _name;
            age = _age;
        }

        public string Name { get; set; }

        public string Age { get; set; }

        public List<ListCollection> myList { get; set; } = new List<ListCollection>();
           /* { new ListCollection ( "Rania", 44),
              new ListCollection("Lucas", 7)
            };*/


      



        

    }
 }
