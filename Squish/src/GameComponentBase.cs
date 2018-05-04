#region license
/* Project: Squish Framework
 * Author: Jackalsoft Games (http://www.jackalsoft.net/)
 * Date: April 2018
 * 
 * Code and assets are copyright Jackalsoft Games, or their respective
 * owners. No warranty (express or implied) is granted.
 * The Squish Framework is released under the GPLv3 license.
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

namespace Squish
{
    public abstract class GameComponentBase<TGame> :
        IGameComponent<TGame>,
        IUpdateable
        where TGame : GameBase
    {
        #region constructors

        public GameComponentBase(TGame game)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            Game = game;
        }

        #endregion
        #region properties

        public TGame Game
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