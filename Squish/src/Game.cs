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
    public class Game :
        IUpdateable
    {
        #region constructors

        public Game(uint width, uint height, string title, Styles style, ContextSettings settings)
        {
            Window = new RenderWindow(
                new VideoMode(width, height),
                title,
                style,
                settings);
        }

        #endregion
        #region fields

        public RenderWindow Window
        {
            get;
            private set;
        }

        #endregion
        #region methods

        public void Main()
        {
            Window.SetFramerateLimit(60); // FIXME (should be a default value or toggleable / component level)
            Window.Closed += (sender, e) =>
            {
                Window.Close();
            };

            try
            {
                // Initialize
                InitializePre();
                Initialize();
                InitializePost();

                Clock clock = new Clock();
                Time time = Time.Zero;

                while (Window.IsOpen)
                {
                    time = clock.Restart();
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