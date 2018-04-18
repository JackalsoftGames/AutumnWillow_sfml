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
#endregion

namespace Squish.Mathematics
{
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(), nq}")]
    public struct Vector3 :
        IEquatable<Vector3>
    {
        #region static operators

        public static implicit operator Vector3(SFML.System.Vector3f value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }

        public static implicit operator SFML.System.Vector3f(Vector3 value)
        {
            return new SFML.System.Vector3f(value.X, value.Y, value.Z);
        }

        public static Vector3 operator -(Vector3 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            value.Z = -value.Z;

            return value;
        }

        public static bool operator ==(Vector3 value, Vector3 other)
        {
            return
                value.X == other.X &&
                value.Y == other.Y &&
                value.Z == other.Z;
        }

        public static bool operator !=(Vector3 value, Vector3 other)
        {
            return !(
                value.X == other.X &&
                value.Y == other.Y &&
                value.Z == other.Z);
        }

        public static Vector3 operator +(Vector3 value, Vector3 other)
        {
            value.X = value.X + other.X;
            value.Y = value.Y + other.Y;
            value.Z = value.Z + other.Z;

            return value;
        }

        public static Vector3 operator +(Vector3 value, float other)
        {
            value.X = value.X + other;
            value.Y = value.Y + other;
            value.Z = value.Z + other;

            return value;
        }

        public static Vector3 operator +(float value, Vector3 other)
        {
            other.X = value + other.X;
            other.Y = value + other.Y;
            other.Z = value + other.Z;

            return other;
        }

        public static Vector3 operator -(Vector3 value, Vector3 other)
        {
            value.X = value.X - other.X;
            value.Y = value.Y - other.Y;
            value.Z = value.Z - other.Z;

            return value;
        }

        public static Vector3 operator -(Vector3 value, float other)
        {
            value.X = value.X - other;
            value.Y = value.Y - other;
            value.Z = value.Z - other;

            return value;
        }

        public static Vector3 operator -(float value, Vector3 other)
        {
            other.X = value - other.X;
            other.Y = value - other.Y;
            other.Z = value - other.Z;

            return other;
        }

        public static Vector3 operator *(Vector3 value, Vector3 other)
        {
            value.X = value.X * other.X;
            value.Y = value.Y * other.Y;
            value.Z = value.Z * other.Z;

            return value;
        }

        public static Vector3 operator *(Vector3 value, float other)
        {
            value.X = value.X * other;
            value.Y = value.Y * other;
            value.Z = value.Z * other;

            return value;
        }

        public static Vector3 operator *(float value, Vector3 other)
        {
            other.X = value * other.X;
            other.Y = value * other.Y;
            other.Z = value * other.Z;

            return other;
        }

        public static Vector3 operator /(Vector3 value, Vector3 other)
        {
            value.X = value.X / other.X;
            value.Y = value.Y / other.Y;
            value.Z = value.Z / other.Z;

            return value;
        }

        public static Vector3 operator /(Vector3 value, float other)
        {
            float scale = 1f / other;

            value.X = value.X * other;
            value.Y = value.Y * other;
            value.Z = value.Z * other;

            return value;
        }

        public static Vector3 operator /(float value, Vector3 other)
        {
            other.X = value / other.X;
            other.Y = value / other.Y;
            other.Z = value / other.Z;

            return other;
        }

        #endregion
        #region static fields

        private static Vector3 m_Zero = new Vector3(0f, 0f, 0f);
        private static Vector3 m_One = new Vector3(1f, 1f, 1f);

        private static Vector3 m_UnitX = new Vector3(1f, 0f, 0f);
        private static Vector3 m_UnitY = new Vector3(0f, 1f, 0f);
        private static Vector3 m_UnitZ = new Vector3(0f, 0f, 1f);

        private static Vector3 m_Left = new Vector3(-1f, 0f, 0f);
        private static Vector3 m_Right = new Vector3(1f, 0f, 0f);
        private static Vector3 m_Up = new Vector3(0f, 1f, 0f);
        private static Vector3 m_Down = new Vector3(0f, -1f, 0f);
        private static Vector3 m_Forward = new Vector3(0f, 0f, -1f);
        private static Vector3 m_Backward = new Vector3(0f, 0f, 1f);

        #endregion
        #region static properties

        public static Vector3 Zero { get { return m_Zero; } }
        public static Vector3 One { get { return m_One; } }

        public static Vector3 UnitX { get { return m_UnitX; } }
        public static Vector3 UnitY { get { return m_UnitY; } }
        public static Vector3 UnitZ { get { return m_UnitZ; } }

        public static Vector3 Left { get { return m_Left; } }
        public static Vector3 Right { get { return m_Right; } }
        public static Vector3 Up { get { return m_Up; } }
        public static Vector3 Down { get { return m_Down; } }
        public static Vector3 Forward { get { return m_Forward; } }
        public static Vector3 Backward { get { return m_Backward; } }

        #endregion

        #region constructors

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(float value)
        {
            X = value;
            Y = value;
            Z = value;
        }

        public Vector3(Vector2 value, float z)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
        }

        #endregion

        #region fields

        public float X;
        public float Y;
        public float Z;

        #endregion
        #region properties

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(
                    X * X +
                    Y * Y +
                    Z * Z);
            }
        }

        public float LengthSquared
        {
            get
            {
                return 
                    X * X +
                    Y * Y +
                    Z * Z;
            }
        }

        public float LengthInverse
        {
            get
            {
                return 1f / (float)Math.Sqrt(
                    X * X +
                    Y * Y +
                    Z * Z);
            }
        }

        #endregion
        #region methods

        public bool Equals(Vector3 other)
        {
            return
                this.X == other.X &&
                this.Y == other.Y &&
                this.Z == other.Z;
        }

        public override bool Equals(object other)
        {
            return
                (other is Vector3) &&
                this.Equals((Vector3)other);
        }

        public override int GetHashCode()
        {
            return
                X.GetHashCode() +
                Y.GetHashCode() +
                Z.GetHashCode();
        }
        
        public override string ToString()
        {
            return String.Format("X:{0} Y:{1} Z:{2}", X, Y, Z);
        }

        #endregion
    }
}