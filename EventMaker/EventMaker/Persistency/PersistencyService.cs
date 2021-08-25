using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using EventMaker.Model;
using Newtonsoft.Json;

namespace EventMaker.Persistency
{
    class PersistencyService
    {
        /*private const string Filename = "Save.Json";

        private static object EventsCollection => EventCatalogSingleton.Instance.Events;
        //private static CreationCollisionOption _options;
        private static readonly StorageFolder StorageFolder = ApplicationData.Current.LocalFolder;
        private static object _folder;

        public PersistencyService()
        {
            //_options = CreationCollisionOption.OpenIfExists;
        }

        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> collection)
        {
            /*var dataFile = await _folder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
            string dataJson = JsonConvert.SerializeObject(collection);
            await FileIO.WriteTextAsync(dataFile, dataJson);*/
        /*string json = JsonConvert.SerializeObject(collection);
        await FileIO.WriteTextAsync(await StorageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting), json);
    }

    public static async Task LoadEventsFromJsonAsync()
    {

        //StorageFile dataFile = await _folder.GetFileAsync(Filename);
         //string dataJson = await FileIO.ReadTextAsync(dataFile);
        //return (ObservableCollection<Event>)(JsonConvert.DeserializeObject(dataJson, typeof(ObservableCollection<Event>)));
        var loadedEvents =
            await FileIO.ReadTextAsync(
                await StorageFolder.CreateFileAsync(Filename, CreationCollisionOption.OpenIfExists));
        //Only loads the contents of the file if it isn't empty, otherwise it would set the collection as null and break the program
        if (loadedEvents != "")
        {
            EventCatalogSingleton.Instance.events =
                JsonConvert.DeserializeObject<ObservableCollection<Event>>(loadedEvents);
        }
        
    }*/
        public static string eventFileName = "Events.dat";
        public static async void SaveEventsAsJsonAsync(ObservableCollection<Event> events)
        {
            string eventsString = JsonConvert.SerializeObject(events);
            SerializeEventsFileAsync(eventsString, eventFileName);
        }


        public static async Task<List<Event>> LoadEventsFromJsonAsync()
        {
            string eventsJsonString = await DeSerializeEventsFileAsync(eventFileName);
            if (eventsJsonString != null)
                return (List<Event>) JsonConvert.DeserializeObject(eventsJsonString, typeof(ObservableCollection<Event>));
            return null;

        }

        public static async void SerializeEventsFileAsync(string eventsString, string fileName)
        {
            StorageFile localFile =
                await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName,
                    CreationCollisionOption.OpenIfExists);
            await FileIO.WriteTextAsync(localFile, eventsString);
        }

        public static async Task<string> DeSerializeEventsFileAsync(String fileName)
        {
            try
            {
                StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return await FileIO.ReadTextAsync(localFile);

            }
            catch (FileNotFoundException ex)
            {
                MessageDialog messageDialog =
                    new MessageDialog("File of Events not found!- Loading for the first time?" , "File not found!");
                await messageDialog.ShowAsync();
                return null;
            }

        }



    }
}
