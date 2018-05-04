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
    public abstract class GameControllerBase :
        IUpdateable
    {
        #region constructors

        public GameControllerBase(GameState state)
        {
            if (state == null)
                throw new ArgumentNullException("state");
            State = state;
        }
        
        #endregion
        #region properties

        public GameState State
        {
            get;
            private set;
        }

        #endregion
        #region methods

        public virtual void Update(Time time)
        {
        }

        #endregion
    }
}