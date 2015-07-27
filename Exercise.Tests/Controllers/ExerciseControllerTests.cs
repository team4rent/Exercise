using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Controllers.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        private Models.Exercise1 exercise1;
        private Models.Exercise3 exercise3;

        [TestInitialize]
        public void TestInitialize()
        {
            exercise1 = new Models.Exercise1();
            exercise3 = new Models.Exercise3();

        }

        [TestMethod()]
        public void Exercise1Test()
        {
            exercise1.Flight = new int[] { 5 };

            for (var i = 0; i < exercise1.FlightsOfStairs; i++)
            {
                exercise1.FlightOfStairs = 4;
                exercise1.Flight[i] = exercise1.FlightOfStairs;
            }

            exercise1.StepsPerStride = 3;

            Assert.AreEqual(3, exercise1.GetStrides());
        }

        [TestMethod()]
        public void Exercise3TestNullValues()
        {
            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, null);
        }

        [TestMethod()]
        public void Exercise3TestNullValue()
        {
            byte[] testInput = { 0, 0, 1 };

            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, testInput);
        }

        
    }
}