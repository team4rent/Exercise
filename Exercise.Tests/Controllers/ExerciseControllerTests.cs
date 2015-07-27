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

        [TestCategory("Exercise1")]
        [TestMethod()]
        public void Exercise1Test()
        {
            exercise1.Flight = new int[] { 15 };

            exercise1.StepsPerStride = 2;

            Assert.AreEqual(8, exercise1.GetStrides());
        }

        [TestCategory("Exercise1")]
        [TestMethod()]
        public void Exercise1Test1()
        {
            exercise1.Flight = new int[] { 15, 15 };

            exercise1.StepsPerStride = 2;

            Assert.AreEqual(18, exercise1.GetStrides());
        }

        [TestCategory("Exercise1")]
        [TestMethod()]
        public void Exercise1Test2()
        {
            exercise1.Flight = new int[] { 5, 11, 9, 13, 8, 30, 14 };

            exercise1.StepsPerStride = 3;

            Assert.AreEqual(44, exercise1.GetStrides());
        }


        [TestCategory("Exercise3")]
        [TestMethod()]
        public void Exercise3TestNullValues()
        {
            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, null);
        }

        [TestCategory("Exercise3")]
        [TestMethod()]
        public void Exercise3TestNullValue()
        {
            byte[] testInput = { 0, 0, 1 };

            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, testInput);
        }

        
    }
}