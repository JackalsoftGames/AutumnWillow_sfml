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
        IEquatable<Position>
    {
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

        #endregion
    }
}