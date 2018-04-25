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
    public class Content
    {
        #region constructors

        public Content()
        {
            Textures = new AssetManager<Texture>();
            Fonts = new AssetManager<Font>();
            Sounds = new AssetManager<SoundBuffer>();
            Music = new AssetManager<Music>();
        }

        #endregion
        #region fields

        public AssetManager<Texture> Textures;
        public AssetManager<Font> Fonts;
        public AssetManager<SoundBuffer> Sounds;
        public AssetManager<Music> Music;

        #endregion
    }
}