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

        #region Random.NextCircle

        public static Vector2f NextCircle(this Random obj)
        {
            float u, v;
            u = (float)Math.Sqrt(obj.NextDouble());
            v = obj.NextFloat() * MathHelper.TwoPi;

            return new Vector2f(
                u * (float)Math.Cos(v),
                u * (float)Math.Sin(v));
        }

        #endregion

        // TODO:
        // - NextPointOnUnit__() [circle, square, triangle, sphere, cube]
        // - NextPointInUnit__() [circle, square, triangle, sphere, cube]
        // - NextTriangle(a,b,c)
        // - NextQuad(a,b,c,d)
    }
}