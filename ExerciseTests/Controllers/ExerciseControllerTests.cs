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
        [TestMethod()]
        public void Exercise3Test()
        {
            Exercise.Models.Exercise3 exercise3 = new Models.Exercise3();

            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, null);
        }

        [TestMethod()]
        public void Exercise3Test2()
        {
            Exercise.Models.Exercise3 exercise3 = new Models.Exercise3();

            byte[] testInput = { 0, 0, 1 };

            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(null, testInput);
        }
    }
}