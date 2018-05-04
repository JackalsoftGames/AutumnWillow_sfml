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
    public class BehaviorEventArgs :
        EventArgs,
        IGameComponent<Game>
    {
        #region constructors

        public BehaviorEventArgs(Game game)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            Game = game;
        }

        #endregion
        #region fields

        public Actor Actor;
        public Actor Other;

        public Position Source;
        public Position Target;

        #endregion
        #region properties

        public Game Game
        {
            get;
            private set;
        }

        #endregion
        #region methods

        public void Clear()
        {
            Actor = null;
            Other = null;

            Source = Position.Zero;
            Target = Position.Zero;
        }

        public void SetValues(Actor actor, Actor other, Position source, Position target)
        {
            Actor = actor;
            Other = other;

            Source = source;
            Target = target;
        }

        public void SetValues(Actor actor, Actor other, Position source)
        {
            SetValues(actor, other, source, Position.Zero);
        }

        public void SetValues(Actor actor, Actor other)
        {
            SetValues(actor, other, Position.Zero, Position.Zero);
        }

        public void SetValues(Actor actor, Position source, Position target)
        {
            SetValues(actor, null, source, target);
        }

        public void SetValues(Actor actor, Position source)
        {
            SetValues(actor, null, source, Position.Zero);
        }

        public void SetValues(Actor actor)
        {
            SetValues(actor, null, Position.Zero, Position.Zero);
        }

        #endregion
    }
}