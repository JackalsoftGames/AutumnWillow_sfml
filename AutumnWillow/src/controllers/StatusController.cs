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
        GameComponentBase<Game>
    {
        #region constructors

        public StatusController(Game game) :
            base(game)
        {
        }

        #endregion
        #region methods

        public override void Update(Time time)
        {
            Game.State.Tick++;

            if (Game.State.Time > 0)
            {
                if (Game.State.TickRate.Value-- == 0)
                {
                    Game.State.TickRate.Value = Game.State.TickRate.Other;
                    Game.State.Time--;
                }
            }
        }

        #endregion
        #region methods :: time

        public void SetTime(short value, bool relative)
        {
            if (relative)
                Game.State.Time = (short)MathHelper.Clamp(
                    Game.State.Time + value, Int16.MinValue, Int16.MaxValue);
            else
                Game.State.Time = value;
        }

        public void SetTime()
        {
            Game.State.Time = 0;
        }

        #endregion
        #region methods :: score

        public void SetScore(short value, bool relative)
        {
            if (relative)
                Game.State.Score = (short)MathHelper.Clamp(
                    Game.State.Score + value, Int16.MinValue, Int16.MaxValue);
            else
                Game.State.Score = value;                
        }

        public void SetScore()
        {
            Game.State.Score = 0;
        }

        #endregion
        #region methods :: gems

        public void SetGems(short value, bool relative)
        {
            if (relative)
                Game.State.Gems = (short)MathHelper.Clamp(
                    Game.State.Gems + value, Int16.MinValue, Int16.MaxValue);
            else
                Game.State.Gems = value;
        }

        public void SetGems()
        {
            Game.State.Gems = 0;
        }

        #endregion
        #region methods :: inventory

        public bool HasItem(PlayerIndex player, PlayerInventory value)
        {
            return ((Game.State.Inventory[(int)player] & value) > 0);
        }

        public void AddItem(PlayerIndex player, PlayerInventory value)
        {
            Game.State.Inventory[(int)player] |= value;
        }

        public void RemoveItem(PlayerIndex player, PlayerInventory value)
        {
            Game.State.Inventory[(int)player] &= ~value;
        }

        public void RemoveItems(PlayerIndex player)
        {
            Game.State.Inventory[(int)player] = PlayerInventory.NONE;
        }

        #endregion
    }
}