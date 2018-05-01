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
    public class InventoryController :
        Controller<GameState>
    {
        #region constructors

        public InventoryController(GameState state) :
            base(state)
        {
        }

        #endregion
        #region methods

        public bool Contains(PlayerIndex player, PlayerInventory value)
        {
            return ((Target.Inventory[(int)player] & value) > 0);
        }

        public void Add(PlayerIndex player, PlayerInventory value)
        {
            Target.Inventory[(int)player] |= value;
        }

        public void Remove(PlayerIndex player, PlayerInventory value)
        {
            Target.Inventory[(int)player] &= ~value;
        }

        public void Clear(PlayerIndex player)
        {
            Target.Inventory[(int)player] = PlayerInventory.NONE;
        }

        #endregion
    }
}