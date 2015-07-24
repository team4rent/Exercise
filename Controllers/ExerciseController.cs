using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercise.Controllers
{
    public class ExerciseController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exercise1()
        {
            Exercise.Models.Exercise1 exercise1 = new Models.Exercise1();

            Random rnd = new Random();
            exercise1.FlightsOfStairs = rnd.Next(1, 50);
            exercise1.Flight = new int[exercise1.FlightsOfStairs];

            //ex1.Flight = new int[] { 5, 11, 9, 13, 8, 30, 14 };

            for (var i = 0; i < exercise1.FlightsOfStairs; i++)
            {
                exercise1.FlightOfStairs = rnd.Next(5, 30);
                exercise1.Flight[i] = exercise1.FlightOfStairs;
            }

            //ex1.StepsPerStride = 3;
            exercise1.StepsPerStride = rnd.Next(2, 5);

            @ViewBag.StepsPerStride = exercise1.GetStrides();

            return View(exercise1);
        }

        public ActionResult Exercise2()
        {
            Exercise.Models.Exercise2 exercise2 = new Models.Exercise2();

            exercise2.StartTestCase();

            return View(exercise2);
        }

        public ActionResult Exercise3()
        {
            Exercise.Models.Exercise3 exercise3 = new Models.Exercise3();

            Random rnd = new Random();

            byte[] testInput1 = { 1, 1, 255 };
            byte[] testInput2 = { 0, 0, 1 };

            exercise3.Add_UsingARecursiveAlgorithm_ValuesAreAdded(testInput1, testInput2);

            return View(exercise3);
        }
    }
}
