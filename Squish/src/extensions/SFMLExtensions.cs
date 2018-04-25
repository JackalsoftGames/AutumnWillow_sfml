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

namespace Squish.Extensions
{
    public static class SFMLExtensions
    {
        public static Vector2f GetNormalized(this Vector2f obj)
        {
            float scale = GetLengthInverse(obj);
            
            return new Vector2f(
                obj.X * scale,
                obj.Y * scale);
        }

        public static float GetLength(this Vector2f obj)
        {
            return (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y);
        }

        public static float GetLengthSquared(this Vector2f obj)
        {
            return (
                obj.X * obj.X +
                obj.Y * obj.Y);
        }

        public static float GetLengthInverse(this Vector2f obj)
        {
            return 1f / (float)Math.Sqrt(
                obj.X * obj.X +
                obj.Y * obj.Y);
        }
    }
}