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

namespace Squish
{
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(), nq}")]
    public struct Delta3<TValue>
        where TValue : struct
    {
        #region constructors

        public Delta3(TValue current, TValue previous, TValue next)
        {
            Current = current;
            Previous = previous;
            Next = next;
        }

        public Delta3(TValue value)
        {
            Current = value;
            Previous = value;
            Next = value;
        }

        #endregion
        #region fields

        public TValue Current;
        public TValue Previous;
        public TValue Next;

        #endregion
        #region methods

        public bool Equals(Delta3<TValue> other)
        {
            return
                this.Current.Equals(other.Current) &&
                this.Previous.Equals(other.Previous) &&
                this.Next.Equals(other.Next);
        }

        public override bool Equals(object other)
        {
            return
                (other is Delta3<TValue>) &&
                this.Equals((Delta3<TValue>)other);
        }

        public override int GetHashCode()
        {
            return
                Current.GetHashCode() +
                Previous.GetHashCode() +
                Next.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Current:{0} Previous:{1} Next:{2}", Current, Previous, Next);
        }

        #endregion
    }
}