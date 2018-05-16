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
    public sealed class MapInformation
    {
        public string Title;
        public string Author;
        public string[] Tags;

        public IntRect Bounds;
        public Tile[][] Tiles;

        public ushort Time;

        public ushort GemQuotaEasy;
        public ushort GemQuotaHard;
    }
}