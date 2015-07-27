using System;
namespace Exercise.Models
{
    public class Exercise3
    {
        #region Fields
        static int i = 1;
        static int next = 0;
        static bool initializeResult = false;
        static byte[] result;
        #endregion

        #region Properties
        public string PrintInputs { get; set; }
        public string PrintResult { get; set; }
        #endregion
        
        #region Metods
        public AddResult Add_UsingARecursiveAlgorithm_ValuesAreAdded(byte[] f, byte[] s)
        {
            if (f != null && s != null)
            {
                // Arrange
                PrintInputs = Print(f, s);

                // Act
                var result = AddRecursive(f, s);

                PrintResult = Print(result);

                // Assert
                return new AddResult(f, s, result);
            }
            else
                return new AddResult();
        }

        /// <summary>
        /// You can assume inputs f & s are never null, and are always of the same length.
        /// The algorithm should be non destructive to the inputs.
        /// The algorithm should be able to handle large input lengths, of a couple of thousand values, 
        /// but the input will never be large enough to cause a stack overflow.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static byte[] AddRecursive(byte[] x, byte[] y)
        {
            // Both have the same length
            int arrayIndex = x.Length - i;

            // Single initialisation 
            if (initializeResult == false)
            {
                result = new byte[x.Length];
                initializeResult = true;
            }

            // Stop when reach the last element of the array
            if (arrayIndex >= 0)
            {
                i++;

                int sum = x[arrayIndex] + y[arrayIndex];
                int tempSum = sum;

                if (sum > 255)
                {
                    if (next > 0)
                    {
                        sum -= 256;
                        result[arrayIndex] = Convert.ToByte(sum + next);
                    }
                    else
                    {
                        sum -= 256;
                        result[arrayIndex] = Convert.ToByte(sum);
                    }

                    next = tempSum % 255;

                    result[arrayIndex] = Convert.ToByte(sum);
                }
                else
                {
                    if (next > 0)
                    {
                        result[arrayIndex] = Convert.ToByte(sum + next);
                    }
                    else
                    {
                        result[arrayIndex] = Convert.ToByte(sum);
                    }

                    next = 0;
                }

                return AddRecursive(x, y);
            }
            else
            {
                return result;
            }
        }

        public string Print(byte[] result)
        {
            string text = string.Empty;

            for (int i = 0; i < result.Length; i++)
            {
                text += string.Format("{0}, ", result[i]);
            }

            return string.Format("Result: {{ {0} }}", text.Remove(text.Length - 2));
        }

        public string Print(byte[] f, byte[] s)
        {
            string textF = string.Empty;
            string textS = string.Empty;

            for (int i = 0; i < f.Length; i++)
            {
                textF += string.Format("{0}, ", f[i]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                textS += string.Format("{0}, ", s[i]);
            }

            return string.Format("Input: {{ {0} }}, {{ {1} }}", textF.Remove(textF.Length - 2), textS.Remove(textS.Length - 2));
        }
        #endregion
    }

    public class AddResult
    {
        public byte[] F { get; set; }
        public byte[] S { get; set; }
        public byte[] Result { get; set; }

        public AddResult() { }

        public AddResult(byte[] f, byte[] s, byte[] result)
        {
            F = f;
            S = s;
            Result = result;
        }
    }
}