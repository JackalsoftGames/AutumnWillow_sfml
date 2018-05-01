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
    // TODO:
    // - Limit of 256 sound/music instances (252 sounds / 4 music?)
    // - Store as arrays
    // - Manage them so they pause when app gain/loses focus (if settings allow)

    public sealed class Content
    {
        #region constructors

        public Content(Game game)
        {
            if (game == null)
                throw new ArgumentNullException("game");
            Game = game;

            Textures = new AssetManager<Texture>();
            Fonts = new AssetManager<Font>();
            Sounds = new AssetManager<SoundBuffer>();
            Music = new AssetManager<Music>();
        }

        #endregion
        #region properties

        public Game Game { get; private set; }

        public AssetManager<Texture> Textures { get; private set; }
        public AssetManager<Font> Fonts { get; private set; }
        public AssetManager<SoundBuffer> Sounds { get; private set; }
        public AssetManager<Music> Music { get; private set; }

        #endregion
    }
}