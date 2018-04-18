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
#endregion

namespace Squish
{
    public class GameComponent :
        IUpdateable
    {
        public TimeStep Timing;

        public Time TimeMin;
        public Time TimeMax;

        public bool IsRunningSlowly { get; set; }
        public bool IsRunningQuickly { get; set; }

        public virtual void Update(Time time)
        {
            // add time to timestep
            // check if fast/slow
            // call or drop an update until it sorts itself out
        }
    }
}