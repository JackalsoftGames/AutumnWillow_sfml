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
    // TODO:
    // - Track SFX and music instances currently playing 
    // - Pause them if loses focus (if global game option is set)
    // - Volume controls

    public class AudioController :
        Controller<GameState>
    {
        #region constructors

        public AudioController(GameState state) :
            base(state)
        {
        }

        #endregion
        #region methods

        public override void Update(Time time)
        {
        }

        #endregion
    }
}