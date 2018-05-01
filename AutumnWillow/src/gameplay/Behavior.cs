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
using AutumnWillow;
using AutumnWillow.Gameplay;

namespace AutumnWillow
{
    public class BehaviorArgs
    {
    }

    public class Behavior
    {
        public event EventHandler<EventArgs> Move;

        public void OnMove(EventArgs args)
        {
            var h = Move;
            if (h != null)
                h(this, args);
        }
    }
}