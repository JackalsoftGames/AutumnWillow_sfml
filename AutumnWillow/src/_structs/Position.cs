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
#endregion

namespace AutumnWillow
{
    public struct Position
    {
        #region constructors

        public Position(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        #endregion

        // Fields
        public byte X;
        public byte Y;

        // Methods

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        
        public override int GetHashCode()
        {
            return (Y * 256 + X);
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}