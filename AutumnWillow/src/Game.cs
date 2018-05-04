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
    public sealed class Game :
        GameBase
    {
        #region constructors

        public Game()
        {
            Window = new RenderWindow(
                new VideoMode(480, 480),
                "Autumn Willow",
                Styles.Default,
                new ContextSettings());

            Content = new GameContent(this);
            State = new GameState(this, 10, 10);
            Controllers = new GameControllers(this);
        }

        #endregion
        #region properties

        public GameContent Content { get; private set; }
        public GameControllers Controllers { get; private set; }
        public GameState State { get; private set; }

        #endregion
        #region methods :: initialize

        protected override void InitializePre()
        {
        }

        protected override void Initialize()
        {
            Window.SetIcon(32, 32, new Image("res/icon.png").Pixels);

            // TODO: Load from manifest
            #region load content

            foreach (var ITEM in System.IO.Directory.GetFiles(
                "res/image/", "*.png", System.IO.SearchOption.AllDirectories))
            {
                Content.Textures.Add(new Asset<Texture>(
                    Content.Textures.ByIndex.Count,
                    System.IO.Path.GetFileNameWithoutExtension(ITEM),
                    new Texture(ITEM)));
            }

            foreach (var ITEM in System.IO.Directory.GetFiles(
                "res/font/", "*.ttf", System.IO.SearchOption.AllDirectories))
            {
                Content.Fonts.Add(new Asset<Font>(
                    Content.Fonts.ByIndex.Count,
                    System.IO.Path.GetFileNameWithoutExtension(ITEM),
                    new Font(ITEM)));
            }

            foreach (var ITEM in System.IO.Directory.GetFiles(
                "res/music/", "*.ogg", System.IO.SearchOption.AllDirectories))
            {
                Content.Music.Add(new Asset<Music>(
                    Content.Music.ByIndex.Count,
                    System.IO.Path.GetFileNameWithoutExtension(ITEM),
                    new Music(ITEM)));
            }

            foreach (var ITEM in System.IO.Directory.GetFiles(
                "res/sound/", "*.wav", System.IO.SearchOption.AllDirectories))
            {
                Content.Sounds.Add(new Asset<SoundBuffer>(
                    Content.Sounds.ByIndex.Count,
                    System.IO.Path.GetFileNameWithoutExtension(ITEM),
                    new SoundBuffer(ITEM)));
            }

            #endregion

            Window.SetFramerateLimit(60);
            Window.Closed += (sender, e) =>
            {
                Window.Close();
                IsRunning = false;
            };
        }

        protected override void InitializePost()
        {
            State.TimeLimitDelay = new Delta2<ushort>(15);
            State.TimeLimitMaximum = 20;
            State.TimeLimit = 20;
        }

        #endregion
        #region methods :: update

        protected override void UpdatePre(Time time)
        {
            #region input

            PlayerAction input = PlayerAction.NONE;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) ||
                Keyboard.IsKeyPressed(Keyboard.Key.A) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad4))
            {
                input |= PlayerAction.LEFT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) ||
                Keyboard.IsKeyPressed(Keyboard.Key.D) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad6))
            {
                input |= PlayerAction.RIGHT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) ||
                Keyboard.IsKeyPressed(Keyboard.Key.W) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad8))
            {
                input |= PlayerAction.UP;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) ||
                Keyboard.IsKeyPressed(Keyboard.Key.S) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad2))
            {
                input |= PlayerAction.DOWN;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RShift) ||
                Keyboard.IsKeyPressed(Keyboard.Key.X))
            {
                input |= PlayerAction.ACTION_PUSH;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RControl) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                input |= PlayerAction.ACTION_ITEM;
            }

            State.Input[0] = input;
            for (int i = 1; i < State.Input.Length; i++)
                State.Input[i] = PlayerAction.NONE;

            #endregion
        }

        protected override void Update(Time time)
        {
            Controllers.Status.Update(time);
        }

        protected override void UpdatePost(Time time)
        {
        }

        #endregion
        #region methods :: draw

        protected override void DrawPre(Time time)
        {
        }

        protected override void Draw(Time time)
        {
            Window.Clear(Color.Black);
            {
                text.Font = Content.Fonts[0];
                text.DisplayedString = String.Format(
                    "{0}",
                    State.TimeLimit);

                Window.Draw(text);
            }
            Window.Display();
        }

        protected override void DrawPost(Time time)
        {
        }

        #endregion

        Text text = new Text();
    }
}