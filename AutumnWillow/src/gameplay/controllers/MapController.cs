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

namespace AutumnWillow.Gameplay
{
    public class MapController :
        Controller<GameState>
    {
        #region constructors

        public MapController(GameState state) :
            base(state)
        {
        }

        #endregion

        public override void Update(Time time)
        {
        }

        public bool Contains(int x, int y)
        {
            return (Target.Bounds.Contains(x, y));
        }

        #region methods :: occupancy

        public bool IsOccupied(int x, int y)
        {
            if (Contains(x, y))
                return Target.Occupied[y][x];
            return false;
        }

        public void Occupy(int x, int y)
        {
            if (Contains(x, y))
                Target.Occupied[y][x] = true;
        }

        public void Unoccupy(int x, int y)
        {
            if (Contains(x, y))
                Target.Occupied[y][x] = false;
        }

        public void SetOccupy(int x, int y, bool value)
        {
            if (Contains(x, y))
                Target.Occupied[y][x] = value;
        }

        #endregion

        public bool IsSolid(int x, int y)
        {
            return false;
        }

        public bool IsType(int x, int y, int value)
        {
            return false;
        }
    }
}