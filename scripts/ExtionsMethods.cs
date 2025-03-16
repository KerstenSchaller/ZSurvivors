using System;
using Godot;

namespace ExtensionMethods
{
    public static class MyExtensions
    {
        public static bool compareAngleTo(this Vector2 thisVector, Vector2 vector)
        {
            return Mathf.Abs(thisVector.Angle() - vector.Angle()) < 0.1f;
        }

        // classify direction of vector into one of 8 directions
        public static string ClassifyDirection(this Vector2 thisVector)
        {   
            if(thisVector == new Vector2())return "S";

            // Normalize angle to [0, 2π)
            var radians = (thisVector.Angle() % (2 * Math.PI) + (2 * Math.PI)) % (2 * Math.PI);

            // Define 8 direction labels
            string[] directions = { "E", "SE", "S", "SW", "W", "NW", "N", "NE" };

            // Find the closest sector (each sector is π/4 radians)
            int index = (int)Math.Round(radians / (Math.PI / 4)) % 8;

            return directions[index];
        }
    }
}