﻿using VAM=VisioAutomationMin;

namespace VisioAutomationMin
{
    public static class Convert
    {
        public static double PointsToInches(double points)
        {
            return points / 72.0;
        }

        public static double InchestoPoints(double inches)
        {
            return inches * 72;
        }

        public static double DegreesToRadians(double degrees)
        {
            return (System.Math.PI / 180) * degrees;
        }

        public static double RadiansToDegrees(double radians)
        {
            return (180 / System.Math.PI) * radians;
        }

        public static short BoolToShort(bool b)
        {
            return b ? ((short)1) : ((short)0);
        }

        public static string BoolToFormula(bool b)
        {
            return b ? "1" : "0";
        }

        public static bool DoubleToBool(double d)
        {
            return d != 0 ? true : false;
        }

        /// <summary>
        /// Converts a short value to bool
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool ShortToBool(short v)
        {
            return (v == 0) ? false : true;
        }

        /// <summary>
        /// Properly quotes a string being used as a formula
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string StringToFormulaString(string s)
        {
            if (s == null)
            {
                throw new System.ArgumentNullException("s");
            }

            const string quote = "\"";
            const string quotequote = "\"\"";
            string result = System.String.Format("\"{0}\"", s.Replace(quote, quotequote));
            return result;
        }

        public static string ColorToFormulaRGB(byte r, byte g, byte b)
        {
            string formula = System.String.Format("RGB({0},{1},{2})", r, g, b);
            return formula;
        }

        public static string ColorToFormulaHSL(byte h, byte s, byte l)
        {
            string formula = System.String.Format("HSL({0},{1},{2})", h, s, l);
            return formula;
        }
    }
}