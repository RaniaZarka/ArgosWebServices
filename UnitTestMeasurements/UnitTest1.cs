using MeasurementApp.Controllers;
using MeasurementApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestMeasurements
{
    [TestClass]
    public class UnitTest1
    {

        MeasurementController mc = new MeasurementController();
      

        private List<Measurements> GetMeasurements()
        {
            IEnumerable<Measurements> theList = mc.Get();
            List<Measurements> MeasurementList = theList.ToList();

            return MeasurementList;
        }

        [TestMethod]
        public void TestgetAllMethod()
        {
            // Arrange

            var testProducts = GetMeasurements();

            //Act
            var result = mc.Get() as List<Measurements>;

            //Assert
            Assert.AreEqual(testProducts.Count, result.Count);

        }


       


        [TestMethod]
        public void TestPropertyID()
        {
            //Arrange
            Measurements m = new Measurements();

            int id = 1;

            //Act

            m.ID = id;

            // Assert

            Assert.AreEqual(m.ID, id);

        }
        

        [TestMethod]
        public void TestPropertyTemperature()
        {
            //Arrange
            Measurements m = new Measurements();

            decimal temp = 16; ;

            //Act

            m.Temperature = temp;

            // Assert

            Assert.AreEqual(m.Temperature, temp);

        }

        [TestMethod]
        public void TestPropertyPressure()
        {
            //Arrange
            Measurements m = new Measurements();

            decimal pressure = 15;

            //Act

            m.Pressure = pressure;

            // Assert

            Assert.AreEqual(m.Pressure, pressure);

        }

        [TestMethod]
        public void TestPropertyHumidity()
        {
            //Arrange
            Measurements m = new Measurements();

            decimal humidity = 50;

            //Act

            m.Humidity = humidity;

            // Assert

            Assert.AreEqual(m.Humidity, humidity);

        }


    }
}
