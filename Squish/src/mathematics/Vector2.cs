#region license
/* Project: Squish Framework
 * Author: Jackalsoft Games (http://www.jackalsoft.net/)
 * Date: April 2018
 * 
 * Code and assets are copyright Jackalsoft Games, or their respective
 * owners. No warranty (express or implied) is granted. See README for
 * full license terms.
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
#endregion

namespace Squish.Mathematics
{
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(), nq}")]
    public struct Vector2 :
        IEquatable<Vector2>
    {
        #region static operators

        public static implicit operator Vector2(SFML.System.Vector2f value)
        {
            return new Vector2(value.X, value.Y);
        }

        public static implicit operator SFML.System.Vector2f(Vector2 value)
        {
            return new SFML.System.Vector2f(value.X, value.Y);
        }

        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;

            return value;
        }

        public static bool operator ==(Vector2 value, Vector2 other)
        {
            return
                value.X == other.X &&
                value.Y == other.Y;
        }

        public static bool operator !=(Vector2 value, Vector2 other)
        {
            return !(
                value.X == other.X &&
                value.Y == other.Y);
        }

        public static Vector2 operator +(Vector2 value, Vector2 other)
        {
            value.X = value.X + other.X;
            value.Y = value.Y + other.Y;

            return value;
        }

        public static Vector2 operator +(Vector2 value, float other)
        {
            value.X = value.X + other;
            value.Y = value.Y + other;

            return value;
        }

        public static Vector2 operator +(float value, Vector2 other)
        {
            other.X = value + other.X;
            other.Y = value + other.Y;

            return other;
        }

        public static Vector2 operator -(Vector2 value, Vector2 other)
        {
            value.X = value.X - other.X;
            value.Y = value.Y - other.Y;

            return value;
        }

        public static Vector2 operator -(Vector2 value, float other)
        {
            value.X = value.X - other;
            value.Y = value.Y - other;

            return value;
        }

        public static Vector2 operator -(float value, Vector2 other)
        {
            other.X = value - other.X;
            other.Y = value - other.Y;

            return other;
        }

        public static Vector2 operator *(Vector2 value, Vector2 other)
        {
            value.X = value.X * other.X;
            value.Y = value.Y * other.Y;

            return value;
        }

        public static Vector2 operator *(Vector2 value, float other)
        {
            value.X = value.X * other;
            value.Y = value.Y * other;

            return value;
        }

        public static Vector2 operator *(float value, Vector2 other)
        {
            other.X = value * other.X;
            other.Y = value * other.Y;

            return other;
        }

        public static Vector2 operator /(Vector2 value, Vector2 other)
        {
            value.X = value.X / other.X;
            value.Y = value.Y / other.Y;

            return value;
        }

        public static Vector2 operator /(Vector2 value, float other)
        {
            float scale = 1f / other;

            value.X = value.X * other;
            value.Y = value.Y * other;

            return value;
        }

        public static Vector2 operator /(float value, Vector2 other)
        {
            other.X = value / other.X;
            other.Y = value / other.Y;

            return other;
        }

        #endregion
        #region static fields

        private static Vector2 m_Zero = new Vector2(0f, 0f);
        private static Vector2 m_One = new Vector2(1f, 1f);

        private static Vector2 m_UnitX = new Vector2(1f, 0f);
        private static Vector2 m_UnitY = new Vector2(0f, 1f);

        #endregion
        #region static properties

        public static Vector2 Zero { get { return m_Zero; } }
        public static Vector2 One { get { return m_One; } }

        public static Vector2 UnitX { get { return m_UnitX; } }
        public static Vector2 UnitY { get { return m_UnitY; } }

        #endregion

        #region constructors

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2(float value)
        {
            X = value;
            Y = value;
        }

        #endregion

        #region fields

        public float X;
        public float Y;

        #endregion
        #region properties

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(
                    X * X +
                    Y * Y);
            }
        }

        public float LengthSquared
        {
            get
            {
                return
                    X * X +
                    Y * Y;
            }
        }

        public float LengthInverse
        {
            get
            {
                return 1f / (float)Math.Sqrt(
                    X * X +
                    Y * Y);
            }
        }

        #endregion
        #region methods

        public bool Equals(Vector2 other)
        {
            return
                this.X == other.X &&
                this.Y == other.Y;
        }

        public override bool Equals(object other)
        {
            return
                (other is Vector2) &&
                this.Equals((Vector2)other);
        }

        public override int GetHashCode()
        {
            return
                X.GetHashCode() +
                Y.GetHashCode();
        }
        
        public override string ToString()
        {
            return String.Format("X:{0} Y:{1}", X, Y);
        }

        #endregion
    }
}