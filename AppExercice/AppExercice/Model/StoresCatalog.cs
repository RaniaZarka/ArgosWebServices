﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Xaml.Shapes;


namespace AppExercice.Model
{

    public class StoresCatalog
    {
        public static ObservableCollection<Stores> _StoresCollection = new ObservableCollection<Stores>
        {
            new Stores("Bolia","# 30368964", "www.bolia.com","10.00-20.00","Home","..\\Assets\\bolia.jpeg"),
            new Stores("Bounce", "# 78700900","www.bounceinc.dk","10.00-20.00","Entertainment", "..\\Assets\\bounce.jpeg"),
            new Stores("BR", "# 32987630","www.br.dk","10.00-20.00","Kids","..\\Assets\\BR.jpg"),
            new Stores("Dalle Valle", "# 32204200","www.cafedallevalle.dk","10.00-20.00","Restaurant","..\\Assets\\Dalle-Valle.jpeg"),
            new Stores("H&M", "# 70212200","www.hm.com","10.00-20.00","Men- Women- Kids", "..\\Assets\\hm.png"),
            new Stores("Magasin", "# 32470600","www.magasin.dk","10.00-20.00","Men- Women- Kids","..\\Assets\\magasin.png"),
            new Stores("Matas", "# 32626264", "www.matas.dk","10.00-20.00", "Cosmetic- Health", "..\\Assets\\matas.jpeg"),
            new Stores("Burger King","# 32624262", "www.burgerking.dk", "10.00-22.00", "Restaurant", "..\\Assets\\burgerking.jpeg"),
            new Stores("Name it","# 32621242", "www.name-it.com", "10.00-20.00", "kids", "..\\Assets\\nameit.png" ),
            new Stores("Kaufmann", "# 32620034","www.kaufmann.dk","10.00-20.00", "Men", "..\\Assets\\kaufmann.jpeg"),
            new Stores("Bilka", "# 89303333", "www.Bilka.dk", "06.00-24.00", "Food Store","..\\Assets\\bilka.jpeg")


        };

        public ObservableCollection<Stores> Stores => _StoresCollection;


        public void AddStore(Stores s)
        {
            _StoresCollection.Add(s);
        }

        public void Delete(string name)
        {

            var Stores = _StoresCollection.FirstOrDefault(s => s.Name == name);
            _StoresCollection.Remove(Stores);
        }

    }
    /*string path = @"C:\Users\rania\OneDrive\Documents\AppExercice";

        private const string FileName = "storesList.txt";
        readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
        private static ObservableCollection<Stores> _StoreCollection = new ObservableCollection<Stores>();
        private object _store;

        public ObservableCollection<Stores> store => _StoresCollection;

        public object JsonConvert { get; set; }

        

       







    }*/


}
