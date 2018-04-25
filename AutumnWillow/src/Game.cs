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
    public class Game :
        Squish.Game
    {
        #region constructors

        public Game() :
            base(640, 640, "Autumn Willow", Styles.Default, new ContextSettings())
        {
        }

        #endregion

        // fields
        Text text;
        PlayerAction input;

        Content content;

        GameState state;
        ActorController cActor;

        QuadBatch qb;

        #region initialize

        public override void InitializePre()
        {
            // check settings
            Window.SetIcon(32, 32, new Image("res/icon.png").Pixels);
        }

        public override void Initialize()
        {
            content = new Content();
            {
                foreach (var ITEM in System.IO.Directory.GetFiles(
                    "res/image/", "*.png", System.IO.SearchOption.AllDirectories))
                {
                    content.Textures.Load(new Asset<Texture>(
                        content.Textures.ByIndex.Count,
                        System.IO.Path.GetFileNameWithoutExtension(ITEM),
                        new Texture(ITEM)));
                }
            }

            qb = new QuadBatch(1024);
            qb.States.Texture = new Texture("res/image/tile.png");

            state = new GameState(16, 16);

            cActor = new ActorController(state);
        }

        public override void InitializePost()
        {
            // perform cleanup
            text = new Text("", new Font("res/font/old_wizard.ttf"));
            text.Font.GetTexture(text.CharacterSize).Smooth = false;
            
            Random r = new Random();
            for (int i = 0; i < state.Tiles.Length; i++)
                if (r.Next(0, 3) == 0)
                    state.Tiles[i] = 1;

            state.ActorCount = 1;
        }

        #endregion
        #region update

        public override void UpdatePre(Time time)
        {
            input = PlayerAction.NONE;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) input |= PlayerAction.LEFT;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) input |= PlayerAction.RIGHT;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) input |= PlayerAction.UP;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) input |= PlayerAction.DOWN;
        }

        public override void Update(Time time)
        {
            if ((input & PlayerAction.LEFT) > 0)
                cActor.MoveLeft(ref state.Actors[0], 30);

            if ((input & PlayerAction.RIGHT) > 0)
                cActor.MoveRight(ref state.Actors[0], 30);

            cActor.Update(time);
        }

        public override void UpdatePost(Time time)
        {
        }

        #endregion
        #region draw

        public override void DrawPre(Time time)
        {
        }

        public override void Draw(Time time)
        {
            Window.Clear(Color.Black);
            {
                qb.Clear();
                for(int y = 0; y < state.Height; y++)
                    for (int x = 0; x < state.Width; x++)
                    {
                        if (state.Tiles[y * state.Width + x] == 0)
                            continue;
                        qb.Add(new Vector2f(x * 32, y * 32), new IntRect(0, 0, 32, 32));
                    }

                for (int i = 0; i < state.ActorCount; i++)
                {
                    Actor actor = state.Actors[i];
                    qb.Add(
                        new Vector2f(actor.Position.Current.X * 32, actor.Position.Current.Y * 32),
                        new IntRect(288, 96, 32, 32));
                }

                Window.Draw(qb, qb.States);
            }
            Window.Display();
        }

        public override void DrawPost(Time time)
        {
        }

        #endregion

        #region unsorted

        public static IntRect[] CreateFrames(
            int count, int stride,
            Vector2i position,
            Vector2i size,
            Vector2i step)
        {
            if (count < 0) count = 0;
            if (stride < 1) stride = 1;

            IntRect[] result = new IntRect[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = new IntRect(
                    (i % stride) * step.X + position.X,
                    (i / stride) * step.Y + position.Y,
                    size.X,
                    size.Y);
            }

            return result;
        }

        #endregion
    }
}