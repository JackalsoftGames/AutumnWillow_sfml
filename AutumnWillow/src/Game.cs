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
#endregion

namespace AutumnWillow
{
    public class Game :
        Squish.Game
    {
        RectangleShape r;
        Squish.TimeStep t;

        public Game() :
            base(640, 640, "Autumn Willow", Styles.Default, new ContextSettings())
        {
            t = new Squish.TimeStep();
            f = new Font("res/font/old_wizard.ttf");
            
            Window.SetIcon(32, 32, new Image("icon.png").Pixels);
        }

        public override void Initialize()
        {
            r = new RectangleShape();
            r.Texture = new Texture("res/img/actor.png");
            r.TextureRect = new IntRect(0, 384, 32, 32);

            r.Size = new Vector2f(32, 32);
            r.FillColor = Color.White;
        }

        public override void Update(Time time)
        {
            t.Update(time);
        }

        public override void Draw(Time time)
        {
            Window.Clear(Color.Black);
            Window.Draw(r);

            Text text = new Text("", f);

            text.DisplayedString = String.Format(
                "Sum:{0} Avg:{1} Cnt:{2}",
                t.Sum.AsMicroseconds(),
                t.Average.AsMicroseconds(),
                t.Values.Count);
            text.Position = new Vector2f(0, 0);
            text.Draw(Window, RenderStates.Default);

            Window.Display();
        }

        Font f;
    }
}