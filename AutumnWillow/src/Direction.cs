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
    public enum Direction :
        byte
    {
        NONE = 0,

        LEFT = 0x01,
        RIGHT = 0x02,
        UP = 0x04,
        DOWN = 0x08,

        FORWARD = 0x10,
        BACKWARD = 0x20,
        CLOCKWISE = 0x40,
        COUNTERCLOCKWISE = 0x80,
    }
}