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
        #region constants

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

        // min, max, clamp, lerp, etc

        public static float Lerp(float value, float other, float percent)
        {
            return percent * (other - value) + value;
        }

        public static Vector2f Lerp(Vector2f value, Vector2f other, float percent)
        {
            return new Vector2f(
                Lerp(value.X, other.X, percent),
                Lerp(value.Y, other.Y, percent));
        }

        public static Vector3f Lerp(Vector3f value, Vector3f other, float percent)
        {
            return new Vector3f(
                Lerp(value.X, other.X, percent),
                Lerp(value.Y, other.Y, percent),
                Lerp(value.Z, other.Z, percent));
        }
    }

    public static class Interpolation
    {
        // TODO (return float)
        // For animations and interpolation
        public static void Linear() { }
        public static void InSine() { }
        public static void OutSine() { }
        public static void InOutSine() { }
        public static void InQuadratic() { }
        public static void OutQuadratic() { }
        public static void InOutQuadratic() { }
        public static void InCubic() { }
        public static void OutCubic() { }
        public static void InOutCubic() { }
        public static void InQuartic() { }
        public static void OutQuartic() { }
        public static void InOutQuartic() { }
        public static void InQuintic() { }
        public static void OutQuintic() { }
        public static void InOutQuintic() { }
        public static void InExponent() { }
        public static void OutExponent() { }
        public static void InOutExponent() { }
        public static void InCircle() { }
        public static void OutCircle() { }
        public static void InOutCircle() { }
        public static void InBack() { }
        public static void OutBack() { }
        public static void InOutBack() { }
        public static void InElastic() { }
        public static void OutElastic() { }
        public static void InOutElastic() { }
        public static void InBounce() { }
        public static void OutBounce() { }
        public static void InOutBounce() { }

        // SmoothStep?
        // Etc (from perlin)
    }
}