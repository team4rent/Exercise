using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise.Models
{
    public class Exercise2
    {
        #region Fields
        private static int resultTemp = 3000;
        private static int nearest = 0;
        #endregion

        #region Properties
        /// <summary>
        /// Number of test cases
        /// </summary>
        private int T { get; set; }

        /// <summary>
        /// Number of bombs
        /// </summary>
        public int N { get; set; }

        public int BombValue { get; set; }
        public static int PositionValue { get; set; }
        public static int BombNumber { get; set; }
        public StringBuilder PrintCase { get; set; }
        #endregion

        #region Methods
        public void StartTestCase()
        {
            T = 50;

            Random rnd = new Random();
            //N = rnd.Next(1, 200); /* Too much time to load in internet browser*/
            N = rnd.Next(1, 20);

            Space space = new Space(rnd.Next(0, 1000), rnd.Next(0, 1000), rnd.Next(0, 1000));
            
            List<TestCase> testCaseList = new List<TestCase>();
            PositionValue = GetValue(space.Height, space.Width, space.Depth);

            int nTemp = 0;
            for (var i = 1; i <= T; i++)
            {
                List<Bomb> bombs = new List<Bomb>();
                nTemp = N;

                for (var j = 1; j <= N; j++)
                {
                    Position myPosition = new Position(rnd.Next(10, 100));
                    bombs.Add(new Bomb(j, rnd.Next(0, 1000), rnd.Next(0, 1000), rnd.Next(0, 1000), myPosition));
                }

                testCaseList.Add(new TestCase(i, bombs));
                
                N = nTemp;
            }

            StringBuilder sb = new StringBuilder();

            foreach (var testCase in testCaseList)
            {
                resultTemp = 3000;
                nearest = 0;
                sb.AppendFormat("<b>Test case number {0}</b><br />", testCase.ID);

                foreach (var bomb in testCase.bombList)
                {
                    BombValue = GetValue(bomb.Height, bomb.Width, bomb.Depth);

                    // Find the nearest bomb with the longest distance
                    Compare(BombValue, bomb.Position.Distance, bomb.Number);

                    sb.Append(bomb.Print());
                }
                sb.AppendFormat("<b>Nearest bomb number {0}</b><br /><br />", BombNumber);                
            }

            PrintCase = sb;
        }

        /// <summary>
        /// Get number values from list
        /// </summary>
        /// <param name="inputs">list of numbers</param>
        /// <returns>number</returns>
        private static int GetValue(params int[] input)
        {
            int total = 0;

            for (int i = 0; i < input.Length; i++)
            {
                total += input[i];
            }

            return total;
        }

       /// <summary>
       /// Compare bomb position with distance
       /// </summary>
       /// <param name="value">bomb position</param>
       /// <param name="distence">distance</param>
       /// <param name="bombNumber">nearest bomb</param>
        private static void Compare(int value, int distance, int bombNumber)
        {
            int result = PositionValue - value;

            if (result < 0)
            {
                result = -1 * result;
            }

            if (result <= resultTemp)
            {
                if (distance >= nearest)
                {
                    resultTemp = result;
                    nearest = distance;
                    BombNumber = bombNumber;
                }
                else
                {
                    resultTemp = result;
                    nearest = distance;
                    BombNumber = bombNumber;
                }
            }
        }
        #endregion
    }

    public class Space
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public Space(int height, int width, int depth)
        {
            Height = height;
            Width = width;
            Depth = depth;
        }
    }

    public class Bomb
    {
        public int Number { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public Position Position { get; set; }

        public Bomb(int number, int height, int width, int depth, Position position)
        {
            Number = number;
            Height = height;
            Width = width;
            Depth = depth;
            Position = position;
        }

        public string Print()
        {
            return string.Format("Bomb number {0}, position H={1}, W={2}, D={3}, distance from bomb {4} m<br />",
                    Number, Height, Width, Depth, Position.Distance);
        }
    }

    public class Position
    {
        public int Distance { get; set; }

        public Position(int distance)
        {
            Distance = distance;
        }
    }

    public class TestCase
    {
        public int ID { get; set; }

        public List<Bomb> bombList { get; set; } 

        public TestCase(int id, List<Bomb> bombs)
        {
            ID = id;
            bombList = new List<Bomb>(bombs);
        }
    }
}