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
    public sealed class GameContent :
        GameComponentBase<Game>
    {
        #region constructors

        public GameContent(Game game) :
            base(game)
        {
            Textures = new AssetManager<Texture>();
            Fonts = new AssetManager<Font>();
            Sounds = new AssetManager<SoundBuffer>();
            Music = new AssetManager<Music>();

            Frames = new AssetManager<SpriteSheet>();
            Behaviors = new AssetManager<Behavior>();
        }

        #endregion
        #region properties

        public AssetManager<Texture> Textures { get; private set; }
        public AssetManager<Font> Fonts { get; private set; }
        public AssetManager<SoundBuffer> Sounds { get; private set; }
        public AssetManager<Music> Music { get; private set; }

        public AssetManager<SpriteSheet> Frames { get; private set; }
        public AssetManager<Behavior> Behaviors { get; private set; }

        #endregion
        #region methods

        public override void Update(Time time)
        {
        }

        #endregion
    }
}