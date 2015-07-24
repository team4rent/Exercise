using System.Linq;

namespace Exercise.Models
{
    public class Exercise1
    {

        #region Properties
        /// <summary>
        ///The number of steps in each flight 
        /// </summary>
        public int[] Flight { get; set; }

        /// <summary>
        /// How many continuous steps you climb in each stride
        /// Is between 2 and 5
        /// </summary>
        public int StepsPerStride { get; set; }

        // Two strides to turn around at a landing
        private int stepsToTurnAround = 2;
        public int StepsToTurnAround {
            get {
                return stepsToTurnAround;
            }
        }

        /// <summary>
        /// Each flight of stairs has between 5 and 30 steps
        /// </summary>
        public int FlightOfStairs  { get; set; }

        /// <summary>
        /// The staircase has between 1 and 50 flights of stairs
        /// </summary>
        public int FlightsOfStairs { get; set; }

        public string[] Results { get; set; }
        #endregion

        /// <summary>
        /// Number of steps in one stride. However, after each flight, 
        /// there is a landing which you cannot skip because you need to turn around for the next flight.
        /// You do not need to turn at the top of the staircase.
        /// </summary>
        /// <returns>number of strides</returns>
        public int GetStrides()
        {
            int strides = 0;
            Results = new string[Flight.Count()];

            int flight = 0;

            for(int i = 0; i < Flight.Count(); i++ )
            {
                flight++;
                int flightStrideRemainder = Flight[i] % StepsPerStride;
                int flightStride = (Flight[i] / StepsPerStride) + flightStrideRemainder;
                int stride =  StepsToTurnAround + flightStride;

                if (i == 0)
                {
                    strides += flightStride;
                    Results[i] = string.Format("Flight {0}: {1} steps, {2} strides", flight, Flight[i], flightStride);
                }
                else if ((i > 0) && (flightStrideRemainder > 0))
                {
                    strides += StepsToTurnAround + flightStride;
                    Results[i] = string.Format("Flight {0}: {1} steps, {2} strides", flight, Flight[i], stride);
                }
                else
                {
                    strides += flightStride;
                    Results[i] = string.Format("Flight {0}: {1} steps, {2} strides, no turn around", flight, Flight[i], flightStride);
                }                
            }

            return strides;
        }
    }
}