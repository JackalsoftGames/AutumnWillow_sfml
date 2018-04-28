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
    [Flags]
    public enum PlayerInventory :
        ushort
    {
        NONE = 0,

        KEY_RED = 0x0001,
        KEY_YELLOW = 0x0002,
        KEY_GREEN = 0x0004,
        KEY_BLUE = 0x0008,

        PASS_FIRE = 0x0010,
        PASS_WATER = 0x0020,
        PASS_ICE = 0x0040,
        PASS_MOTION = 0x0080,

        IMMUNE_BOMB = 0x0100,
        IMMUNE_LASER = 0x0200,
        IMMUNE_MOSNTER = 0x0400,
        IMMUNE_BUMP = 0x0800,

        MISC_MAGNET = 0x1000,
        MISC_CURSE = 0x2000,
        MISC_FAST = 0x4000,
        MISC_SLOW = 0x8000,
    }
}