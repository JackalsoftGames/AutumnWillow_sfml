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
using Squish.Mathematics;
#endregion

namespace Squish.Mathematics
{
    /*
    public static class Vector
    {
        #region static methods (algebra)

        public static Vector2 Clamp(Vector2 value, float min, float max)
        {
            value.X = (value.X <= min) ? min : (value.X >= max) ? max : value.X;
            value.Y = (value.Y <= min) ? min : (value.Y >= max) ? max : value.Y;

            return value;
        }

        public static void Clamp(ref Vector2 value, ref float min, ref float max, out Vector2 result)
        {
            result.X = (value.X <= min) ? min : (value.X >= max) ? max : value.X;
            result.Y = (value.Y <= min) ? min : (value.Y >= max) ? max : value.Y;
        }

        public static Vector2 Max(Vector2 value, Vector2 other)
        {
            return new Vector2(
                (value.X >= other.X) ? value.X : other.X,
                (value.Y >= other.Y) ? value.Y : other.Y);
        }

        public static void Max(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = (value.X >= other.X) ? value.X : other.X;
            result.Y = (value.Y >= other.Y) ? value.Y : other.Y;
        }

        public static Vector2 Min(Vector2 value, Vector2 other)
        {
            return new Vector2(
                (value.X <= other.X) ? value.X : other.X,
                (value.Y <= other.Y) ? value.Y : other.Y);
        }

        public static void Min(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = (value.X <= other.X) ? value.X : other.X;
            result.Y = (value.Y <= other.Y) ? value.Y : other.Y;
        }

        #endregion
        #region static methods (math ops)

        public static Vector2 Inverse(Vector2 value)
        {
            value.X = 1f / value.X;
            value.Y = 1f / value.Y;

            return value;
        }

        public static void Inverse(ref Vector2 value, out Vector2 result)
        {
            result.X = 1f / value.X;
            result.Y = 1f / value.Y;
        }

        public static Vector2 Negate(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;

            return value;
        }

        public static void Negate(ref Vector2 value, out Vector2 result)
        {
            result.X = -value.X;
            result.Y = -value.Y;
        }

        public static Vector2 Add(Vector2 value, Vector2 other)
        {
            value.X = value.X + other.X;
            value.Y = value.Y + other.Y;

            return value;
        }

        public static void Add(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = value.X + other.X;
            result.Y = value.Y + other.Y;
        }

        public static Vector2 Add(Vector2 value, float other)
        {
            value.X = value.X + other;
            value.Y = value.Y + other;

            return value;
        }

        public static void Add(ref Vector2 value, ref float other, out Vector2 result)
        {
            result.X = value.X + other;
            result.Y = value.Y + other;
        }

        public static Vector2 Subtract(Vector2 value, Vector2 other)
        {
            value.X = value.X - other.X;
            value.Y = value.Y - other.Y;

            return value;
        }

        public static void Subtract(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = value.X - other.X;
            result.Y = value.Y - other.Y;
        }

        public static Vector2 Subtract(Vector2 value, float other)
        {
            value.X = value.X - other;
            value.Y = value.Y - other;

            return value;
        }

        public static void Subtract(ref Vector2 value, ref float other, out Vector2 result)
        {
            result.X = value.X - other;
            result.Y = value.Y - other;
        }

        public static Vector2 Multiply(Vector2 value, Vector2 other)
        {
            value.X = value.X * other.X;
            value.Y = value.Y * other.Y;

            return value;
        }

        public static void Multiply(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = value.X * other.X;
            result.Y = value.Y * other.Y;
        }

        public static Vector2 Multiply(Vector2 value, float other)
        {
            value.X = value.X * other;
            value.Y = value.Y * other;

            return value;
        }

        public static void Multiply(ref Vector2 value, ref float other, out Vector2 result)
        {
            result.X = value.X * other;
            result.Y = value.Y * other;
        }

        public static Vector2 Divide(Vector2 value, Vector2 other)
        {
            value.X = value.X / other.X;
            value.Y = value.Y / other.Y;

            return value;
        }

        public static void Divide(ref Vector2 value, ref Vector2 other, out Vector2 result)
        {
            result.X = value.X / other.X;
            result.Y = value.Y / other.Y;
        }

        public static Vector2 Divide(Vector2 value, float other)
        {
            float scale = 1f / other;

            value.X = value.X * scale;
            value.Y = value.Y * scale;

            return value;
        }

        public static void Divide(ref Vector2 value, ref float other, out Vector2 result)
        {
            float scale = 1f / other;

            result.X = value.X * scale;
            result.Y = value.Y * scale;
        }

        #endregion
        #region static methods (vector)

        public static float Distance(Vector2 value, Vector2 other)
        {
            float x = other.X - value.X;
            float y = other.Y - value.Y;

            return (float)Math.Sqrt(x * x + y * y);
        }

        public static void Distance(ref Vector2 value, ref Vector2 other, out float result)
        {
            float x = other.X - value.X;
            float y = other.Y - value.Y;

            result = (float)Math.Sqrt(x * x + y * y);
        }

        public static float DistanceSquared(Vector2 value, Vector2 other)
        {
            float x = other.X - value.X;
            float y = other.Y - value.Y;

            return (x * x + y * y);
        }

        public static void DistanceSquared(ref Vector2 value, ref Vector2 other, out float result)
        {
            float x = other.X - value.X;
            float y = other.Y - value.Y;

            result = (x * x + y * y);
        }

        public static float Dot(Vector2 value, Vector2 other)
        {
            return
                value.X * other.X +
                value.Y * other.Y;
        }

        public static void Dot(ref Vector2 value, ref Vector2 other, out float result)
        {
            result =
                value.X * other.X +
                value.Y * other.Y;
        }

        public static Vector2 Normalize(Vector2 value)
        {
            float scale = value.LengthInverse;

            value.X = value.X * scale;
            value.Y = value.Y * scale;

            return value;
        }

        public static void Normalize(ref Vector2 value, out Vector2 result)
        {
            float scale = value.LengthInverse;

            result.X = value.X * scale;
            result.Y = value.Y * scale;
        }

        public static Vector2 Reflect(Vector2 value, Vector2 normal)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y);

            value.X = value.X - normal.X * dot;
            value.Y = value.Y - normal.Y * dot;

            return value;
        }

        public static void Reflect(ref Vector2 value, ref Vector2 normal, out Vector2 result)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y);

            result.X = value.X - normal.X * dot;
            result.Y = value.Y - normal.Y * dot;
        }

        #endregion
    }
    */
}