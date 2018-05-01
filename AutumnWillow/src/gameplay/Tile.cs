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
using AutumnWillow;
using AutumnWillow.Gameplay;

namespace AutumnWillow.Gameplay
{
    public struct Tile
    {
        #region fields

        public ushort Sprite;
        public ushort Behavior;

        public Delta3<Position> Position;
        public Delta3<Direction> Direction;
        public Delta2<ushort> Timer;

        public ushort State;

        #endregion
        #region methods

        public float GetPercent()
        {
            if (Timer.Value <= 0.00f)
                return 0.00f;

            if (Timer.Value >= Timer.Other)
                return 1.00f;

            return Timer.Value / (float)Timer.Other;
        }

        #endregion
    }
}