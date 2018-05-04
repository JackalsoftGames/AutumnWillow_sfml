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
    public sealed class GameControllers :
        GameComponentBase<Game>
    {
        #region constructors

        public GameControllers(Game game) :
            base(game)
        {
            Map = new MapController(game.State);
            Status = new StatusController(game.State);
        }

        #endregion
        #region properties

        public MapController Map { get; private set; }
        public StatusController Status { get; private set; }

        #endregion
    }
}