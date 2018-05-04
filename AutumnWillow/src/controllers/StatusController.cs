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
    public class StatusController :
        GameControllerBase
    {
        #region constructors

        public StatusController(GameState state) :
            base(state)
        {
        }
        
        #endregion
        #region methods

        public override void Update(Time time)
        {
            if (State.TimeLimit > 0)
            {
                if (State.TimeLimitDelay.Value > 0)
                    State.TimeLimitDelay.Value--;
                else
                {
                    State.TimeLimitDelay.Value = State.TimeLimitDelay.Other;
                    State.TimeLimit--;
                }
            }
        }

        #endregion
        #region methods :: time

        public void AddTime(ushort value)
        {
            if (State.TimeLimit + value >= State.TimeLimitMaximum)
                State.TimeLimit = State.TimeLimitMaximum;
            else
                State.TimeLimit += value;
        }

        public void RemoveTime(ushort value)
        {
            if (State.TimeLimit - value <= 0)
                State.TimeLimit = 0;
            else
                State.TimeLimit -= value;
        }

        public void SetTime(ushort value)
        {
            State.TimeLimit = value;
        }

        #endregion
        #region methods :: score

        public void AddScore(ushort value)
        {
        }

        public void RemoveScore(ushort value)
        {
        }

        public void SetScore(ushort value)
        {
        }

        #endregion
        #region methods :: gems

        public void AddGems(ushort value)
        {
        }

        public void RemoveGems(ushort value)
        {
        }

        public void SetGems(ushort value)
        {
        }

        #endregion
        #region methods :: inventory

        public bool HasItem(PlayerIndex player, PlayerInventory value)
        {
            return ((State.Inventory[(int)player] & value) > 0);
        }

        public void AddItem(PlayerIndex player, PlayerInventory value)
        {
            State.Inventory[(int)player] |= value;
        }

        public void RemoveItem(PlayerIndex player, PlayerInventory value)
        {
            State.Inventory[(int)player] &= ~value;
        }

        public void RemoveItems(PlayerIndex player)
        {
            State.Inventory[(int)player] = PlayerInventory.NONE;
        }

        #endregion
    }
}