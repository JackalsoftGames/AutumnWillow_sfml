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
    public class Behavior
    {
        #region events

        public event EventHandler<BehaviorEventArgs> Create;
        public event EventHandler<BehaviorEventArgs> Destroy;

        public event EventHandler<BehaviorEventArgs> Move;
        public event EventHandler<BehaviorEventArgs> Idle;
        public event EventHandler<BehaviorEventArgs> Bump;

        public event EventHandler<BehaviorEventArgs> Collect;
        public event EventHandler<BehaviorEventArgs> Trigger;

        #endregion
        #region methods

        public void OnCreate(BehaviorEventArgs args)
        {
            var h = Create;
            if (h != null)
                h(this, args);
        }

        public void OnDestroy(BehaviorEventArgs args)
        {
            var h = Destroy;
            if (h != null)
                h(this, args);
        }

        public void OnMove(BehaviorEventArgs args)
        {
            var h = Move;
            if (h != null)
                h(this, args);
        }

        public void OnIdle(BehaviorEventArgs args)
        {
            var h = Idle;
            if (h != null)
                h(this, args);
        }

        public void OnBump(BehaviorEventArgs args)
        {
            var h = Bump;
            if (h != null)
                h(this, args);
        }

        public void OnCollect(BehaviorEventArgs args)
        {
            var h = Collect;
            if (h != null)
                h(this, args);
        }

        public void OnTrigger(BehaviorEventArgs args)
        {
            var h = Trigger;
            if (h != null)
                h(this, args);
        }

        #endregion
    }
}