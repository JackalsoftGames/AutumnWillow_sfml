#region license
/* Project: Squish Framework
 * Author: Jackalsoft Games (http://www.jackalsoft.net/)
 * Date: April 2018
 * 
 * Code and assets are copyright Jackalsoft Games, or their respective
 * owners. No warranty (express or implied) is granted.
 * The Squish Framework is released under the GPLv3 license.
 */
#endregion
#region using
using System;
using System.Collections.Generic;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using Squish;
using Squish.Extensions;
#endregion

namespace Squish.Extensions
{
    public static class CSharpExtensions
    {
        #region Random.NextFloat

        public static float NextFloat(this Random obj)
        {
            return (float)obj.NextDouble();
        }

        #endregion
        #region Random.NextVector2f

        public static Vector2f NextVector2f(this Random obj)
        {
            return new Vector2f(
                (float)obj.NextDouble(),
                (float)obj.NextDouble());
        }

        #endregion
        #region Random.NextVector3f

        public static Vector3f NextVector3f(this Random obj)
        {
            return new Vector3f(
                (float)obj.NextDouble(),
                (float)obj.NextDouble(),
                (float)obj.NextDouble());
        }

        #endregion

        #region Random.NextPointInUnitCircle

        public static Vector2f NextPointInUnitCircle(this Random obj)
        {
            const double TWO_PI = Math.PI * 2.00d;

            double u = Math.Sqrt(obj.NextDouble());
            double v = obj.NextDouble() * TWO_PI;

            return new Vector2f(
                (float)(u * Math.Cos(v)),
                (float)(u * Math.Sin(v)));
        }

        #endregion
        #region Random.NextPointOnUnitCircle

        public static Vector2f NextPointOnUnitCircle(this Random obj)
        {
            const double TWO_PI = Math.PI * 2.00d;

            double angle = obj.NextDouble() * TWO_PI;

            return new Vector2f(
                (float)Math.Cos(angle),
                (float)Math.Sin(angle));
        }

        #endregion

        #region Random.NextPointInUnitSquare

        public static Vector2f NextPointInUnitSquare(this Random obj)
        {
            return new Vector2f(
                (float)obj.NextDouble(),
                (float)obj.NextDouble());
        }

        #endregion
        #region Random.NextPointOnUnitSquare

        public static Vector2f NextPointOnUnitSquare(this Random obj)
        {
            switch (obj.Next(0, 4))
            {
                case (0): return new Vector2f(obj.NextFloat(), 0.00f);
                case (1): return new Vector2f(obj.NextFloat(), 1.00f);
                case (2): return new Vector2f(0.00f, obj.NextFloat());
                case (3): return new Vector2f(1.00f, obj.NextFloat());
            }

            return new Vector2f();
        }

        #endregion

        #region Random.NextTriangle

        public static void NextTriangle(this Random obj,
            ref Vector3f a, ref Vector3f b, ref Vector3f c,
            out Vector3f result)
        {
            float u, v;
            u = obj.NextFloat();
            v = obj.NextFloat();

            if (u + v >= 1.00f)
            {
                u = 1 - u;
                v = 1 - v;
            }

            result.X = u * (b.X - a.X) + v * (c.X - a.X) + a.X;
            result.Y = u * (b.Y - a.Y) + v * (c.Y - a.Y) + a.Y;
            result.Z = u * (b.Y - a.Y) + v * (c.Y - a.Y) + a.Y;
        }

        public static Vector3f NextTriangle(this Random obj,
            Vector3f a, Vector3f b, Vector3f c)
        {
            Vector3f result;
            obj.NextTriangle(ref a, ref b, ref c, out result);
            return result;
        }

        public static void NextTriangle(this Random obj,
            ref Vector2f a, ref Vector2f b, ref Vector2f c,
            out Vector2f result)
        {
            float u, v;
            u = obj.NextFloat();
            v = obj.NextFloat();

            if (u + v >= 1.00f)
            {
                u = 1 - u;
                v = 1 - v;
            }

            result.X = u * (b.X - a.X) + v * (c.X - a.X) + a.X;
            result.Y = u * (b.Y - a.Y) + v * (c.Y - a.Y) + a.Y;
        }

        public static Vector2f NextTriangle(this Random obj,
            Vector2f a, Vector2f b, Vector2f c)
        {
            Vector2f result;
            obj.NextTriangle(ref a, ref b, ref c, out result);
            return result;
        }

        #endregion
    }
}