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

using Squish;
using Squish.Extensions;
#endregion

namespace Squish
{
    public abstract class Game :
        IUpdateable
    {
        #region constructors

        public Game()
        {
            IsRunning = true;
        }

        #endregion
        #region properties

        public RenderWindow Window
        {
            get;
            protected set;
        }

        public bool IsRunning
        {
            get;
            protected set;
        }

        #endregion
        #region methods

        public void Main()
        {
            try
            {
                // Initialize
                InitializePre();
                Initialize();
                InitializePost();

                Clock clock = new Clock();
                Time time = Time.Zero;

                while (IsRunning)
                {
                    time = clock.Restart();

                    if (Window != null)
                        Window.DispatchEvents();

                    // Update
                    UpdatePre(time);
                    Update(time);
                    UpdatePost(time);

                    // Draw
                    DrawPre(time);
                    Draw(time);
                    DrawPost(time);
                }
            }
            finally
            {
                if (Window != null)
                    Window.Dispose();
            }
        }

        public virtual void Initialize() { }
        public virtual void InitializePre() { }
        public virtual void InitializePost() { }

        public virtual void Update(Time time) { }
        public virtual void UpdatePre(Time time) { }
        public virtual void UpdatePost(Time time) { }

        public virtual void Draw(Time time) { }
        public virtual void DrawPre(Time time) { }
        public virtual void DrawPost(Time time) { }

        #endregion
    }
}