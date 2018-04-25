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
    public struct Actor
    {
        public ushort Image;
        public ushort Behavior;

        public Delta3<Position> Position;
        public Delta3<Direction> Direction;
        public Delta2<ushort> Timer;

        public byte State;


        public bool IsIdle
        {
            get
            {
                return
                    Timer.Value == 0 &&
                    Timer.Other == 0;
            }
        }

        public bool IsMoving
        {
            get
            {
                return !IsIdle;
            }
        }

        public bool IsElapsed
        {
            get
            {
                return
                    Timer.Value >= Timer.Other &&
                    Timer.Other > 0;
            }
        }
    }
}