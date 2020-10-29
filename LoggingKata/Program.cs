using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        public static void Main(string[] args)
        {
            try
            {
                // TODO:  Find the two Taco Bells that are the furthest from one another.
                // HINT:  You'll need two nested forloops ---------------------------

                logger.LogInfo("Log initialized");

                // use File.ReadAllLines(path) to grab all the lines from your csv file
                // Log an error if you get 0 lines and a warning if you get 1 line
                var lines = File.ReadAllLines(csvPath);

                if (lines.Length == 0)
                {
                    logger.LogError("csv is either corrupt or non-existent", new IndexOutOfRangeException());
                }
                else if (lines.Length == 1)
                {
                    logger.LogWarning("Hey!! There's just one line in this file\nThere has to be two or more locations for this program to work");
                    
                }
                else
                {
                    // Create a new instance of your TacoParser class
                    var parser = new TacoParser();

                    // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
                    var locations = lines.Select(parser.Parse).ToArray();

                    // DON'T FORGET TO LOG YOUR STEPS

                    // Now that your Parse method is completed, START BELOW ----------

                    // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
                    // Create a `double` variable to store the distance


                    // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
                    ITrackable trackableOne = null;
                    ITrackable trackableTwo = null;
                    double distance = 0;
                    double controlDistance = 0;
                    string maxLocationA = "", maxLocationB = "";

                    //HINT NESTED LOOPS SECTION---------------------
                    // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                    for (int i = 0; i < locations.Length; i++)
                    {
                        trackableOne = locations[i];
                        GeoCoordinate locA = new GeoCoordinate(trackableOne.Location.Latitude, trackableOne.Location.Longitude);
                        for (int j = 1; j < locations.Length; j++)
                        {
                            trackableTwo = locations[j];
                            GeoCoordinate locB = new GeoCoordinate(trackableTwo.Location.Latitude, trackableTwo.Location.Longitude);
                            distance = locA.GetDistanceTo(locB);

                            if (distance >= controlDistance)
                            {
                                controlDistance = distance;
                                maxLocationA = trackableOne.Name;
                                maxLocationB = trackableTwo.Name;

                            }
                        }
                    }

                    // Create a new corA Coordinate with your locA's lat and long

                    // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

                    // Create a new Coordinate with your locB's lat and long

                    // Now, compare the two using `.GetDistanceTo()`, which returns a double
                    // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

                    // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.

                    Console.WriteLine($"The Farthest Distance is from {maxLocationA} to {maxLocationB} {ConvertToMiles(controlDistance)} miles");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Environment.Exit(1);
            }
        }
        public static double ConvertToMiles(double meters)
        {
            return Math.Round((meters / 1609.34), 2);
        }
    }
}
