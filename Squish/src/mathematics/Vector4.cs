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
    public struct Vector4 :
        IEquatable<Vector4>
    {
        #region static operators

        public static Vector4 operator -(Vector4 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            value.Z = -value.Z;
            value.W = -value.W;

            return value;
        }

        public static bool operator ==(Vector4 value, Vector4 other)
        {
            return
                value.X == other.X &&
                value.Y == other.Y &&
                value.Z == other.Z &&
                value.W == other.W;
        }

        public static bool operator !=(Vector4 value, Vector4 other)
        {
            return !(
                value.X == other.X &&
                value.Y == other.Y &&
                value.Z == other.Z &&
                value.W == other.W);
        }

        public static Vector4 operator +(Vector4 value, Vector4 other)
        {
            value.X = value.X + other.X;
            value.Y = value.Y + other.Y;
            value.Z = value.Z + other.Z;
            value.W = value.W + other.W;

            return value;
        }

        public static Vector4 operator +(Vector4 value, float other)
        {
            value.X = value.X + other;
            value.Y = value.Y + other;
            value.Z = value.Z + other;
            value.W = value.W + other;

            return value;
        }

        public static Vector4 operator +(float value, Vector4 other)
        {
            other.X = value + other.X;
            other.Y = value + other.Y;
            other.Z = value + other.Z;
            other.W = value + other.W;

            return other;
        }

        public static Vector4 operator -(Vector4 value, Vector4 other)
        {
            value.X = value.X - other.X;
            value.Y = value.Y - other.Y;
            value.Z = value.Z - other.Z;
            value.W = value.W - other.W;

            return value;
        }

        public static Vector4 operator -(Vector4 value, float other)
        {
            value.X = value.X - other;
            value.Y = value.Y - other;
            value.Z = value.Z - other;
            value.W = value.W - other;

            return value;
        }

        public static Vector4 operator -(float value, Vector4 other)
        {
            other.X = value - other.X;
            other.Y = value - other.Y;
            other.Z = value - other.Z;
            other.W = value - other.W;

            return other;
        }

        public static Vector4 operator *(Vector4 value, Vector4 other)
        {
            value.X = value.X * other.X;
            value.Y = value.Y * other.Y;
            value.Z = value.Z * other.Z;
            value.W = value.W * other.W;

            return value;
        }

        public static Vector4 operator *(Vector4 value, float other)
        {
            value.X = value.X * other;
            value.Y = value.Y * other;
            value.Z = value.Z * other;
            value.W = value.W * other;

            return value;
        }

        public static Vector4 operator *(float value, Vector4 other)
        {
            other.X = value * other.X;
            other.Y = value * other.Y;
            other.Z = value * other.Z;
            other.W = value * other.W;

            return other;
        }

        public static Vector4 operator /(Vector4 value, Vector4 other)
        {
            value.X = value.X / other.X;
            value.Y = value.Y / other.Y;
            value.Z = value.Z / other.Z;
            value.W = value.W / other.W;

            return value;
        }

        public static Vector4 operator /(Vector4 value, float other)
        {
            float scale = 1f / other;

            value.X = value.X * other;
            value.Y = value.Y * other;
            value.Z = value.Z * other;
            value.W = value.W * other;

            return value;
        }

        public static Vector4 operator /(float value, Vector4 other)
        {
            other.X = value / other.X;
            other.Y = value / other.Y;
            other.Z = value / other.Z;
            other.W = value / other.W;

            return other;
        }

        #endregion
        #region static fields

        private static Vector4 m_Zero = new Vector4(0f, 0f, 0f, 0f);
        private static Vector4 m_One = new Vector4(1f, 1f, 1f, 1f);

        private static Vector4 m_UnitX = new Vector4(1f, 0f, 0f, 0f);
        private static Vector4 m_UnitY = new Vector4(0f, 1f, 0f, 0f);
        private static Vector4 m_UnitZ = new Vector4(0f, 0f, 1f, 0f);
        private static Vector4 m_UnitW = new Vector4(0f, 0f, 0f, 1f);

        #endregion
        #region static properties

        public static Vector4 Zero { get { return m_Zero; } }
        public static Vector4 One { get { return m_One; } }

        public static Vector4 UnitX { get { return m_UnitX; } }
        public static Vector4 UnitY { get { return m_UnitY; } }
        public static Vector4 UnitZ { get { return m_UnitZ; } }
        public static Vector4 UnitW { get { return m_UnitW; } }

        #endregion

        #region constructors

        public Vector4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public Vector4(float value)
        {
            X = value;
            Y = value;
            Z = value;
            W = value;
        }

        public Vector4(Vector2 value, float z, float w)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
            W = w;
        }

        public Vector4(Vector3 value, float w)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            W = w;
        }

        #endregion

        #region fields

        public float X;
        public float Y;
        public float Z;
        public float W;

        #endregion
        #region properties

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(
                    X * X +
                    Y * Y +
                    Z * Z +
                    W * W);
            }
        }

        public float LengthSquared
        {
            get
            {
                return 
                    X * X +
                    Y * Y +
                    Z * Z +
                    W * W;
            }
        }

        public float LengthInverse
        {
            get
            {
                return 1f / (float)Math.Sqrt(
                    X * X +
                    Y * Y +
                    Z * Z +
                    W * W);
            }
        }

        #endregion
        #region methods

        public bool Equals(Vector4 other)
        {
            return
                this.X == other.X &&
                this.Y == other.Y &&
                this.Z == other.Z &&
                this.W == other.W;
        }

        public override bool Equals(object other)
        {
            return
                (other is Vector4) &&
                this.Equals((Vector4)other);
        }

        public override int GetHashCode()
        {
            return
                X.GetHashCode() +
                Y.GetHashCode() +
                Z.GetHashCode() +
                W.GetHashCode();
        }
        
        public override string ToString()
        {
            return String.Format("X:{0} Y:{1} Z:{2} W:{3}", X, Y, Z, W);
        }

        #endregion
    }
}