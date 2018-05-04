#region license
/* Project: Autumn Willow
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

using Squish;
using Squish.Extensions;
#endregion

namespace AutumnWillow
{
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(), nq}")]
    public struct Position :
        IEquatable<Position>,
        IComparable<Position>
    {
        #region static fields

        private static readonly Position m_Zero = new Position(0, 0);

        #endregion
        #region static properties

        public static Position Zero
        {
            get
            {
                return m_Zero;
            }
        }

        #endregion
        #region static methods

        public static Direction GetNext(Direction value)
        {
            switch (value)
            {
                case (Direction.FORWARD | Direction.LEFT): return Direction.LEFT;
                case (Direction.FORWARD | Direction.RIGHT): return Direction.RIGHT;
                case (Direction.FORWARD | Direction.UP): return Direction.UP;
                case (Direction.FORWARD | Direction.DOWN): return Direction.DOWN;

                case (Direction.BACKWARD | Direction.LEFT): return Direction.RIGHT;
                case (Direction.BACKWARD | Direction.RIGHT): return Direction.LEFT;
                case (Direction.BACKWARD | Direction.UP): return Direction.DOWN;
                case (Direction.BACKWARD | Direction.DOWN): return Direction.UP;

                case (Direction.CLOCKWISE | Direction.LEFT): return Direction.UP;
                case (Direction.CLOCKWISE | Direction.RIGHT): return Direction.DOWN;
                case (Direction.CLOCKWISE | Direction.UP): return Direction.RIGHT;
                case (Direction.CLOCKWISE | Direction.DOWN): return Direction.LEFT;

                case (Direction.COUNTERCLOCKWISE | Direction.LEFT): return Direction.DOWN;
                case (Direction.COUNTERCLOCKWISE | Direction.RIGHT): return Direction.UP;
                case (Direction.COUNTERCLOCKWISE | Direction.UP): return Direction.LEFT;
                case (Direction.COUNTERCLOCKWISE | Direction.DOWN): return Direction.RIGHT;

                case (Direction.LEFT): return Direction.LEFT;
                case (Direction.RIGHT): return Direction.RIGHT;
                case (Direction.UP): return Direction.UP;
                case (Direction.DOWN): return Direction.DOWN;

                default: return value;
            }
        }

        public static Direction GetNext(Direction value, Direction other)
        {
            switch (value | other)
            {
                case (Direction.FORWARD | Direction.LEFT): return Direction.LEFT;
                case (Direction.FORWARD | Direction.RIGHT): return Direction.RIGHT;
                case (Direction.FORWARD | Direction.UP): return Direction.UP;
                case (Direction.FORWARD | Direction.DOWN): return Direction.DOWN;

                case (Direction.BACKWARD | Direction.LEFT): return Direction.RIGHT;
                case (Direction.BACKWARD | Direction.RIGHT): return Direction.LEFT;
                case (Direction.BACKWARD | Direction.UP): return Direction.DOWN;
                case (Direction.BACKWARD | Direction.DOWN): return Direction.UP;

                case (Direction.CLOCKWISE | Direction.LEFT): return Direction.UP;
                case (Direction.CLOCKWISE | Direction.RIGHT): return Direction.DOWN;
                case (Direction.CLOCKWISE | Direction.UP): return Direction.RIGHT;
                case (Direction.CLOCKWISE | Direction.DOWN): return Direction.LEFT;

                case (Direction.COUNTERCLOCKWISE | Direction.LEFT): return Direction.DOWN;
                case (Direction.COUNTERCLOCKWISE | Direction.RIGHT): return Direction.UP;
                case (Direction.COUNTERCLOCKWISE | Direction.UP): return Direction.LEFT;
                case (Direction.COUNTERCLOCKWISE | Direction.DOWN): return Direction.RIGHT;

                case (Direction.LEFT): return Direction.LEFT;
                case (Direction.RIGHT): return Direction.RIGHT;
                case (Direction.UP): return Direction.UP;
                case (Direction.DOWN): return Direction.DOWN;

                default: return (value | other);
            }
        }

        public static Position GetNext(Position value, Direction other)
        {
            switch (GetNext(other))
            {
                case (Direction.LEFT): return value.Left;
                case (Direction.RIGHT): return value.Right;
                case (Direction.UP): return value.Up;
                case (Direction.DOWN): return value.Down;
            }

            return value;
        }

        #endregion

        #region constructors

        public Position(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        #endregion
        #region fields

        public byte X;
        public byte Y;

        #endregion
        #region properties

        public Position Left
        {
            get
            {
                return new Position((byte)(X - 1), Y);
            }
        }

        public Position Right
        {
            get
            {
                return new Position((byte)(X + 1), Y);
            }
        }

        public Position Up
        {
            get
            {
                return new Position(X, (byte)(Y - 1));
            }
        }

        public Position Down
        {
            get
            {
                return new Position(X, (byte)(Y + 1));
            }
        }

        #endregion
        #region methods

        public bool Equals(Position other)
        {
            return
                this.X == other.X &&
                this.Y == other.Y;
        }

        public override bool Equals(object other)
        {
            return
                (other is Position) &&
                this.Equals((Position)other);
        }
        
        public override int GetHashCode()
        {
            return 
                X.GetHashCode() +
                Y.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("X:{0} Y:{1}",
                X, Y);
        }

        public int CompareTo(Position other)
        {
            if (this.Y > other.Y) return 1;
            if (this.Y < other.Y) return -1;

            if (this.X > other.X) return 1;
            if (this.X < other.X) return -1;

            return 0;
        }

        #endregion
    }
}