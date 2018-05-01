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

namespace AutumnWillow
{
    public class Controllers :
        Controller<GameState>
    {
        #region constructors

        public Controllers(GameState state) :
            base(state)
        {
            Actors = new ActorController(state);
            Audio = new AudioController(state);
            Inventory = new InventoryController(state);
            Input = new InputController(state);
            Map = new MapController(state);
        }

        #endregion
        #region fields

        public ActorController Actors;
        public AudioController Audio;
        public InventoryController Inventory;
        public InputController Input;
        public MapController Map;

        #endregion
        #region methods

        public override void Update(Time time)
        {
            Input.Update(time);
            Actors.Update(time);
            Map.Update(time);
            Inventory.Update(time);
            Audio.Update(time);
        }

        #endregion
    }
}