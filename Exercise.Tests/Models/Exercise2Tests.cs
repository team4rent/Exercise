using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Models.Tests
{
    [TestClass()]
    public class Exercise2Tests
    {
        [TestMethod()]
        public void StartTestCaseTest()
        {
            var exercise2 = new Models.Exercise2();
            exercise2.T = 50;
            exercise2.N = 2;

            Space space = new Space(500, 125, 500);

            List<TestCase> testCaseList = new List<TestCase>();
            Exercise2.PositionValue = Exercise2.GetValue(space.Height, space.Width, space.Depth);

            int nTemp = 0;
            for (var i = 1; i <= exercise2.T; i++)
            {
                List<Bomb> bombs = new List<Bomb>();
                nTemp = exercise2.N;

                for (var j = 1; j <= exercise2.N; j++)
                {
                    Position myPosition = new Position(200);
                    bombs.Add(new Bomb(j, 500, 125, 500, myPosition));
                }

                testCaseList.Add(new TestCase(i, bombs));

                exercise2.N = nTemp;
            }

            foreach (var testCase in testCaseList)
            {
                foreach (var bomb in testCase.bombList)
                {
                    exercise2.BombValue = Exercise2.GetValue(bomb.Height, bomb.Width, bomb.Depth);

                    // Find the nearest bomb with the longest distance
                    Exercise2.Compare(exercise2.BombValue, bomb.Position.Distance, bomb.Number);
                }
                Assert.AreEqual(2, Exercise2.BombNumber);
            }
        }
    }
}