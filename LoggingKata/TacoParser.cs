﻿using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                logger.LogError("You're missing one column in the .csv file", new IndexOutOfRangeException());
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2
            var latitude = cells[0];
            var longitude = cells[1];
            var name = cells[2];


            double doubleLatitude, doubleLongitude;
            var point = new Point();


            try
            {

                // Your going to need to parse your string as a `double`
                // which is similar to parsing a string as an `int`
                doubleLatitude = double.Parse(latitude);
                doubleLongitude = double.Parse(longitude);
                // You'll need to create a TacoBell class
                // that conforms to ITrackable
                // Then, you'll need an instance of the TacoBell class
                // With the name and point set correctly
                point.Latitude = doubleLatitude;
                point.Longitude = doubleLongitude;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }



            TacoBell tacoBell = new TacoBell();
            tacoBell.Name = name;
            tacoBell.Location = point;

            logger.LogInfo("End parsing");


            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            return tacoBell;
        }
    }
}