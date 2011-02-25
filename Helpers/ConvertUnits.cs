using Microsoft.Xna.Framework;

namespace FarseerPhysicsWP7Framework.Helpers
{
    /// <summary>
    /// Convert units between display and simulation units.
    /// </summary>
    public static class ConvertUnits
    {
        static ConvertUnits()
        {
            DisplayUnitsToSimUnitsRatio = 100;
        }

        public static float DisplayUnitsToSimUnitsRatio{ get; set;}
        public static float SimUnitsToDisplayUnitsRatio
        {
            get
            {
                return 1 / DisplayUnitsToSimUnitsRatio;
            }
        }

        public static float ToDisplayUnits(float simUnits)
        {
            return simUnits * DisplayUnitsToSimUnitsRatio;
        }

        public static float ToSimUnits(float displayUnits)
        {
            return displayUnits * SimUnitsToDisplayUnitsRatio;
        }

        public static float ToSimUnits(double displayUnits)
        {
            return (float)displayUnits * SimUnitsToDisplayUnitsRatio;
        }

        public static float ToDisplayUnits(int simUnits)
        {
            return simUnits * DisplayUnitsToSimUnitsRatio;
        }

        public static float ToSimUnits(int displayUnits)
        {
            return displayUnits * SimUnitsToDisplayUnitsRatio;
        }

        public static Vector2 ToDisplayUnits(Vector2 simUnits)
        {
            return DisplayUnitsToSimUnitsRatio * simUnits;
        }

        public static void ToDisplayUnits(ref Vector2 simUnits, out Vector2 displayUnits)
        {
            Vector2.Multiply(ref simUnits, DisplayUnitsToSimUnitsRatio, out displayUnits);
        }

        public static Vector2 ToDisplayUnits(float x, float y)
        {
            return DisplayUnitsToSimUnitsRatio * new Vector2(x, y);
        }

        public static void ToDisplayUnits(float x, float y, out Vector2 displayUnits)
        {
            displayUnits = Vector2.Zero;
            displayUnits.X = x * DisplayUnitsToSimUnitsRatio;
            displayUnits.Y = y * DisplayUnitsToSimUnitsRatio;
        }

        public static Vector2 ToSimUnits(Vector2 displayUnits)
        {
            return SimUnitsToDisplayUnitsRatio * displayUnits;
        }

        public static void ToSimUnits(ref Vector2 displayUnits, out Vector2 simUnits)
        {
            Vector2.Multiply(ref displayUnits, SimUnitsToDisplayUnitsRatio, out simUnits);
        }

        public static Vector2 ToSimUnits(float x, float y)
        {
            return SimUnitsToDisplayUnitsRatio * new Vector2(x, y);
        }

        public static Vector2 ToSimUnits(double x, double y)
        {
            return SimUnitsToDisplayUnitsRatio * new Vector2((float)x, (float)y);
        }

        public static void ToSimUnits(float x, float y, out Vector2 simUnits)
        {
            simUnits = Vector2.Zero;
            simUnits.X = x * SimUnitsToDisplayUnitsRatio;
            simUnits.Y = y * SimUnitsToDisplayUnitsRatio;
        }
    }
}