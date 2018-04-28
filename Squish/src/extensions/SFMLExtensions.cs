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
    public static class SFMLExtensions
    {
        // TODO:
        // Either here or inplace or static, whatever, we need:
        // Dot, Cross, Reflect
        // Ops applied on an array? V2f/V3f in either case
        // Math ops (add, subtract, etc)

        #region Vector2f.Normalize

        public static Vector2f Normalize(this Vector2f obj)
        {
            float scale = 1f / (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y);
            
            return new Vector2f(
                obj.X * scale,
                obj.Y * scale);
        }

        #endregion
        #region Vector2f.Length

        public static float Length(this Vector2f obj)
        {
            return (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y);
        }

        #endregion
        #region Vector2f.LengthSquared

        public static float LengthSquared(this Vector2f obj)
        {
            return (
                obj.X * obj.X +
                obj.Y * obj.Y);
        }

        #endregion
        #region Vector2f.LengthInverse

        public static float LengthInverse(this Vector2f obj)
        {
            return 1f / (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y);
        }

        #endregion

        #region Vector3f.Normalize

        public static Vector3f Normalize(this Vector3f obj)
        {
            float scale = 1f / (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y +
                obj.Z * obj.Z);

            return new Vector3f(
                obj.X * scale,
                obj.Y * scale,
                obj.Z * scale);
        }

        #endregion
        #region Vector3f.Length

        public static float Length(this Vector3f obj)
        {
            return (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y +
                obj.Z * obj.Z);
        }

        #endregion
        #region Vector3f.LengthSquared

        public static float LengthSquared(this Vector3f obj)
        {
            return (
                obj.X * obj.X +
                obj.Y * obj.Y +
                obj.Z * obj.Z);
        }

        #endregion
        #region Vector3f.LengthInverse

        public static float LengthInverse(this Vector3f obj)
        {
            return 1f / (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y +
                obj.Z * obj.Z);
        }

        #endregion
    }
}