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

namespace Squish
{
    public static class MathHelper
    {
        // CAVEAT:
        // - Ternary functions are more elegant, but are slower than if/else blocks
        // - Writing to individual fields tends to be faster than creating a new instance
        // - For vectors, it is slightly faster to use ref functions rather than extension methods

        #region constants

        // CAVEAT:
        // - Floating-point accuracy makes these constants accurate to only 8 decimal places
        // - Full values are here in case we need to compile to double, decimal, or number

        public const float E = 2.7182818284590452353602874713527f;
        public const float Ln10 = 2.3025850929940456840179914546844f;
        public const float Ln2 = 0.69314718055994530941723212145818f;
        public const float Log10E = 0.43429448190325182765112891891661f;
        public const float Log2E = 1.44269504088896340735992468100189f;
        public const float Sqrt2 = 1.4142135623730950488016887242097f;

        public const float Pi = 3.1415926535897932384626433832795f;
        public const float PiOver2 = 1.5707963267948966192313216916398f;
        public const float PiOver4 = 0.78539816339744830961566084581988f;
        public const float TwoPi = 6.283185307179586476925286766559f;

        #endregion

        // general
        #region static methods :: Min()

        public static void Min(ref Color value, ref Color other, out Color result)
        {
            if (value.R < other.R)
                result.R = value.R;
            else
                result.R = other.R;

            if (value.G < other.G)
                result.G = value.G;
            else
                result.G = other.G;

            if (value.B < other.B)
                result.B = value.B;
            else
                result.B = other.B;

            if (value.A < other.A)
                result.A = value.A;
            else
                result.A = other.A;
        }

        public static void Min(ref Vector3f value, ref Vector3f other, out Vector3f result)
        {
            if (value.X < other.X)
                result.X = value.X;
            else
                result.X = other.X;

            if (value.Y < other.Y)
                result.Y = value.Y;
            else
                result.Y = other.Y;

            if (value.Z < other.Z)
                result.Z = value.Z;
            else
                result.Z = other.Z;
        }

        public static void Min(ref Vector2f value, ref Vector2f other, out Vector2f result)
        {
            if (value.X < other.X)
                result.X = value.X;
            else
                result.X = other.X;

            if (value.Y < other.Y)
                result.Y = value.Y;
            else
                result.Y = other.Y;
        }

        public static void Min(ref float value, ref float other, out float result)
        {
            if (other < value)
                result = other;
            else
                result = value;
        }

        public static Color Min(Color value, Color other)
        {
            if (other.R < value.R) value.R = other.R;
            if (other.G < value.G) value.G = other.G;
            if (other.B < value.B) value.B = other.B;
            if (other.A < value.A) value.A = other.A;

            return value;
        }

        public static Vector3f Min(Vector3f value, Vector3f other)
        {
            if (other.X < value.X) value.X = other.X;
            if (other.Y < value.Y) value.Y = other.Y;
            if (other.Z < value.Z) value.Z = other.Z;

            return value;
        }

        public static Vector2f Min(Vector2f value, Vector2f other)
        {
            if (other.X < value.X) value.X = other.X;
            if (other.Y < value.Y) value.Y = other.Y;

            return value;
        }

        public static float Min(float value, float other)
        {
            if (other < value)
                return other;
            return value;
        }

        #endregion
        #region static methods :: Max()

        public static void Max(ref Color value, ref Color other, out Color result)
        {
            if (value.R > other.R)
                result.R = value.R;
            else
                result.R = other.R;

            if (value.G > other.G)
                result.G = value.G;
            else
                result.G = other.G;

            if (value.B > other.B)
                result.B = value.B;
            else
                result.B = other.B;

            if (value.A > other.A)
                result.A = value.A;
            else
                result.A = other.A;
        }

        public static void Max(ref Vector3f value, ref Vector3f other, out Vector3f result)
        {
            if (value.X > other.X)
                result.X = value.X;
            else
                result.X = other.X;

            if (value.Y > other.Y)
                result.Y = value.Y;
            else
                result.Y = other.Y;

            if (value.Z > other.Z)
                result.Z = value.Z;
            else
                result.Z = other.Z;
        }

        public static void Max(ref Vector2f value, ref Vector2f other, out Vector2f result)
        {
            if (value.X > other.X)
                result.X = value.X;
            else
                result.X = other.X;

            if (value.Y > other.Y)
                result.Y = value.Y;
            else
                result.Y = other.Y;
        }

        public static void Max(ref float value, ref float other, out float result)
        {
            if (other > value)
                result = other;
            else
                result = value;
        }

        public static Color Max(Color value, Color other)
        {
            if (other.R > value.R) value.R = other.R;
            if (other.G > value.G) value.G = other.G;
            if (other.B > value.B) value.B = other.B;
            if (other.A > value.A) value.A = other.A;

            return value;
        }

        public static Vector3f Max(Vector3f value, Vector3f other)
        {
            if (other.X > value.X) value.X = other.X;
            if (other.Y > value.Y) value.Y = other.Y;
            if (other.Z > value.Z) value.Z = other.Z;

            return value;
        }

        public static Vector2f Max(Vector2f value, Vector2f other)
        {
            if (other.X > value.X) value.X = other.X;
            if (other.Y > value.Y) value.Y = other.Y;

            return value;
        }

        public static float Max(float value, float other)
        {
            if (other > value)
                return other;
            return value;
        }

        #endregion
        #region static methods :: Clamp()

        public static void Clamp(ref Color value, ref Color min, ref Color max, out Color result)
        {
            if (value.R < min.R)
                result.R = min.R;
            else if (value.R > max.R)
                result.R = max.R;
            else
                result.R = value.R;

            if (value.G < min.G)
                result.G = min.G;
            else if (value.G > max.G)
                result.G = max.G;
            else
                result.G = value.G;

            if (value.B < min.B)
                result.B = min.B;
            else if (value.B > max.B)
                result.B = max.B;
            else
                result.B = value.B;

            if (value.A < min.A)
                result.A = min.A;
            else if (value.A > max.A)
                result.A = max.A;
            else
                result.A = value.A;
        }

        public static void Clamp(ref Vector3f value, ref Vector3f min, ref Vector3f max, out Vector3f result)
        {
            if (value.X < min.X)
                result.X = min.X;
            else if (value.X > max.X)
                result.X = max.X;
            else
                result.X = value.X;

            if (value.Y < min.Y)
                result.Y = min.Y;
            else if (value.Y > max.Y)
                result.Y = max.Y;
            else
                result.Y = value.Y;

            if (value.Z < min.Z)
                result.Z = min.Z;
            else if (value.Z > max.Z)
                result.Z = max.Z;
            else
                result.Z = value.Z;
        }

        public static void Clamp(ref Vector2f value, ref Vector2f min, ref Vector2f max, out Vector2f result)
        {
            if (value.X < min.X)
                result.X = min.X;
            else if (value.X > max.X)
                result.X = max.X;
            else
                result.X = value.X;

            if (value.Y < min.Y)
                result.Y = min.Y;
            else if (value.Y > max.Y)
                result.Y = max.Y;
            else
                result.Y = value.Y;
        }

        public static void Clamp(ref float value, ref float min, ref float max, out float result)
        {
            if (value < min)
                result = min;
            else if (value > max)
                result = max;
            else
                result = value;
        }

        public static Color Clamp(Color value, Color min, Color max)
        {
            if (value.R < min.R)
                value.R = min.R;
            else if (value.R > max.R)
                value.R = max.R;

            if (value.G < min.G)
                value.G = min.G;
            else if (value.G > max.G)
                value.G = max.G;

            if (value.B < min.B)
                value.B = min.B;
            else if (value.B > max.B)
                value.B = max.B;

            if (value.A < min.A)
                value.A = min.A;
            else if (value.A > max.A)
                value.A = max.A;

            return value;
        }

        public static Vector3f Clamp(Vector3f value, Vector3f min, Vector3f max)
        {
            if (value.X < min.X)
                value.X = min.X;
            else if (value.X > max.X)
                value.X = max.X;

            if (value.Y < min.Y)
                value.Y = min.Y;
            else if (value.Y > max.Y)
                value.Y = max.Y;

            if (value.Z < min.Z)
                value.Z = min.Z;
            else if (value.Z > max.Z)
                value.Z = max.Z;

            return value;
        }

        public static Vector2f Clamp(Vector2f value, Vector2f min, Vector2f max)
        {
            if (value.X < min.X)
                value.X = min.X;
            else if (value.X > max.X)
                value.X = max.X;

            if (value.Y < min.Y)
                value.Y = min.Y;
            else if (value.Y > max.Y)
                value.Y = max.Y;

            return value;
        }

        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
                return min;
            else if (value > max)
                return max;

            return value;
        }

        #endregion
        #region static methods :: Lerp()

        public static void Lerp(ref Color value, ref Color other, ref float percent, out Color result)
        {
            result.R = (byte)(percent * (other.R - value.R) + value.R);
            result.G = (byte)(percent * (other.G - value.G) + value.G);
            result.B = (byte)(percent * (other.B - value.B) + value.B);
            result.A = (byte)(percent * (other.A - value.A) + value.A);
        }

        public static void Lerp(ref Vector3f value, ref Vector3f other, ref float percent, out Vector3f result)
        {
            result.X = percent * (other.X - value.X) + value.X;
            result.Y = percent * (other.Y - value.Y) + value.Y;
            result.Z = percent * (other.Z - value.Z) + value.Z;
        }

        public static void Lerp(ref Vector2f value, ref Vector2f other, ref float percent, out Vector2f result)
        {
            result.X = percent * (other.X - value.X) + value.X;
            result.Y = percent * (other.Y - value.Y) + value.Y;
        }

        public static void Lerp(ref float value, ref float other, ref float percent, out float result)
        {
            result = percent * (other - value) + value;
        }

        public static Color Lerp(Color value, Color other, float percent)
        {
            value.R = (byte)(percent * (other.R - value.R) + value.R);
            value.G = (byte)(percent * (other.G - value.G) + value.G);
            value.B = (byte)(percent * (other.B - value.B) + value.B);
            value.A = (byte)(percent * (other.A - value.A) + value.A);

            return value;
        }

        public static Vector3f Lerp(Vector3f value, Vector3f other, float percent)
        {
            value.X = percent * (other.X - value.X) + value.X;
            value.Y = percent * (other.Y - value.Y) + value.Y;
            value.Z = percent * (other.Z - value.Z) + value.Z;

            return value;
        }

        public static Vector2f Lerp(Vector2f value, Vector2f other, float percent)
        {
            value.X = percent * (other.X - value.X) + value.X;
            value.Y = percent * (other.Y - value.Y) + value.Y;

            return value;
        }

        public static float Lerp(float value, float other, float percent)
        {
            return percent * (other - value) + value;
        }

        #endregion

        #region static methods :: GetPercent()

        // CAVEAT:
        // - Returns a clamped value between [0.00 .. 1.00]
        // - Because of range checking, "other" will never result in N/0

        public static void GetPercent(ref float value, ref float other, out float result)
        {
            if (value <= 0.00f)
                result = 0.00f;
            else if (value >= other)
                result = 1.00f;
            else
                result = value / other;
        }

        public static float GetPercent(float value, float other)
        {
            if (value <= 0.00f)
                return 0.00f;
            else if (value >= other)
                return 1.00f;
            else
                return value / other;
        }

        #endregion

        // vector
        #region static methods :: Length()

        public static void Length(ref Vector3f value, out float result)
        {
            result = (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);
        }

        public static void Length(ref Vector2f value, out float result)
        {
            result = (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y);
        }

        public static float Length(Vector3f value)
        {
            return (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);
        }

        public static float Length(Vector2f value)
        {
            return (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y);
        }

        #endregion
        #region static methods :: LengthSquared()

        public static void LengthSquared(ref Vector3f value, out float result)
        {
            result = 
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z;
        }

        public static void LengthSquared(ref Vector2f value, out float result)
        {
            result =
                value.X * value.X +
                value.Y * value.Y;
        }

        public static float LengthSquared(Vector3f value)
        {
            return 
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z;
        }

        public static float LengthSquared(Vector2f value)
        {
            return
                value.X * value.X +
                value.Y * value.Y;
        }

        #endregion
        #region static methods :: LengthInverse()

        public static void LengthInverse(ref Vector3f value, out float result)
        {
            result = 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);
        }

        public static void LengthInverse(ref Vector2f value, out float result)
        {
            result = 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y);
        }

        public static float LengthInverse(Vector3f value)
        {
            return 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);
        }

        public static float LengthInverse(Vector2f value)
        {
            return 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y);
        }

        #endregion

        #region static methods :: Normalize()

        public static void Normalize(ref Vector3f value, out Vector3f result)
        {
            float scale = 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);

            result.X = value.X * scale;
            result.Y = value.Y * scale;
            result.Z = value.Z * scale;
        }

        public static void Normalize(ref Vector2f value, out Vector2f result)
        {
            float scale = 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y);

            result.X = value.X * scale;
            result.Y = value.Y * scale;
        }

        public static Vector3f Normalize(Vector3f value)
        {
            float scale = 1f / (float)Math.Sqrt(
                value.X * value.X +
                value.Y * value.Y +
                value.Z * value.Z);

            value.X = value.X * scale;
            value.Y = value.Y * scale;
            value.Z = value.Z * scale;

            return value;
        }

        public static Vector2f Normalize(Vector2f value)
        {
            float scale = 1f / (float)Math.Sqrt(
                      value.X * value.X +
                      value.Y * value.Y);

            value.X = value.X * scale;
            value.Y = value.Y * scale;

            return value;
        }

        #endregion
        #region static methods :: Cross()

        // CAVEAT:
        // - We have to use intermediate variables, because in the case where value and result
        //   are the same target, it will overwrite values as we use them

        public static void Cross(ref Vector3f value, ref Vector3f other, out Vector3f result)
        {
            float x = +(value.Y * other.Z - other.Y * value.Z);
            float y = -(value.X * other.Z - other.X * value.Z);
            float z = +(value.X * other.Y - other.X * value.Y);

            result.X = x;
            result.Y = y;
            result.Z = z;
        }

        public static void Cross(ref Vector2f value, ref Vector2f other, out Vector3f result)
        {
            result.X = 0f;
            result.Y = 0f;
            result.Z = (value.X * other.Y - other.X * value.Y);
        }

        public static Vector3f Cross(Vector3f value, Vector3f other)
        {
            return new Vector3f(
                +(value.Y * other.Z - other.Y * value.Z),
                -(value.X * other.Z - other.X * value.Z),
                +(value.X * other.Y - other.X * value.Y));
        }

        public static Vector3f Cross(Vector2f value, Vector2f other)
        {
            return new Vector3f(
                0f,
                0f,
                (value.X * other.Y - other.X * value.Y));
        }

        #endregion
        #region static methods :: Dot()

        public static void Dot(ref Vector3f value, ref Vector3f other, out float result)
        {
            result =
                value.X * other.X +
                value.Y * other.Y +
                value.Z * other.Z;
        }

        public static void Dot(ref Vector2f value, ref Vector2f other, out float result)
        {
            result =
                value.X * other.X +
                value.Y * other.Y;
        }

        public static float Dot(Vector3f value, Vector3f other)
        {
            return
                value.X * other.X +
                value.Y * other.Y +
                value.Z * other.Z;
        }

        public static float Dot(Vector2f value, Vector2f other)
        {
            return
                value.X * other.X +
                value.Y * other.Y;
        }

        #endregion
        #region static methods :: Reflect()

        public static void Reflect(ref Vector3f value, ref Vector3f normal, out Vector3f result)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y +
                value.Z * normal.Z);

            result.X = value.X - (normal.X * dot);
            result.Y = value.Y - (normal.Y * dot);
            result.Z = value.Z - (normal.Z * dot);
        }

        public static void Reflect(ref Vector2f value, ref Vector2f normal, out Vector2f result)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y);

            result.X = value.X - (normal.X * dot);
            result.Y = value.Y - (normal.Y * dot);
        }

        public static Vector3f Reflect(Vector3f value, Vector3f normal)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y +
                value.Z * normal.Z);

            value.X = value.X - (normal.X * dot);
            value.Y = value.Y - (normal.Y * dot);
            value.Z = value.Z - (normal.Z * dot);

            return value;
        }

        public static Vector2f Reflect(Vector2f value, Vector2f normal)
        {
            float dot = 2f * (
                value.X * normal.X +
                value.Y * normal.Y);

            value.X = value.X - (normal.X * dot);
            value.Y = value.Y - (normal.Y * dot);

            return value;
        }

        #endregion
    }
}