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
    [Serializable]
    [System.Diagnostics.DebuggerDisplay("{ToString(), nq}")]
    public struct Delta2<TValue>
        where TValue : struct
    {
        #region constructors

        public Delta2(TValue value, TValue other)
        {
            Value = value;
            Other = other;
        }

        public Delta2(TValue value)
        {
            Value = value;
            Other = value;
        }

        #endregion
        #region fields

        public TValue Value;
        public TValue Other;

        #endregion
        #region methods

        public bool Equals(Delta2<TValue> other)
        {
            return
                this.Value.Equals(other.Value) &&
                this.Other.Equals(other.Other);
        }

        public override bool Equals(object other)
        {
            return
                (other is Delta2<TValue>) &&
                this.Equals((Delta2<TValue>)other);
        }

        public override int GetHashCode()
        {
            return
                Value.GetHashCode() +
                Other.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Value:{0} Other:{1}", Value, Other);
        }

        #endregion
    }
}