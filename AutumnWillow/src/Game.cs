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
            base(480, 480, "Autumn Willow", Styles.Default, new ContextSettings())
        {
        }

        #endregion

        // fields
        Text text;
        PlayerAction input;

        Content content;

        GameState state;
        ActorController state_actorController;

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

            state = new GameState(256, 256);
            {
                state_actorController = new ActorController(state);
                state.Controllers.Add(state_actorController);
            }
        }

        public override void InitializePost()
        {
            // perform cleanup
            text = new Text("", new Font("res/font/old_wizard.ttf"));
            text.Font.GetTexture(text.CharacterSize).Smooth = false;
            text.CharacterSize = 18;

            Random r = new Random();

            for (int y = 0; y < state.Bounds.Height; y++)
                for (int x = 0; x < state.Bounds.Width; x++)
                {
                    if (r.Next(0, 3) == 0)
                        state.Tiles[y][x] = 1;
                }

            state.Actors[0].Direction = new Delta3<Direction>(Direction.DOWN);
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
            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift)) input |= PlayerAction.ACTION_PUSH;
            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl)) input |= PlayerAction.ACTION_ITEM;

            Actor a = state.Actors[0];
            ushort moveTime = 36;

            if (input.HasFlag(PlayerAction.ACTION_PUSH))
                moveTime = 12;

            if (input.HasFlag(PlayerAction.LEFT)) state_actorController.MoveLeft(a, moveTime);
            if (input.HasFlag(PlayerAction.RIGHT)) state_actorController.MoveRight(a, moveTime);
            if (input.HasFlag(PlayerAction.UP)) state_actorController.MoveUp(a, moveTime);
            if (input.HasFlag(PlayerAction.DOWN)) state_actorController.MoveDown(a, moveTime);
        }

        public override void Update(Time time)
        {
            state.Update(time);
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

                int w = 16;
                int h = 16;

                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                    {
                        if (state.Tiles[y][x] == 0)
                            continue;
                        qb.Add(new Vector2f(x * 32, y * 32), new IntRect(0, 0, 32, 32));
                    }

                for (int i = 0; i < state.ActorCount; i++)
                {
                    Actor actor = state.Actors[i];

                    Vector2f p1, p2;
                    float p = (actor.Timer.Other == 0)
                        ? 0.00f
                        : actor.Timer.Value / (float)actor.Timer.Other;
                    {
                        p1 = new Vector2f(
                            actor.Position.Current.X,
                            actor.Position.Current.Y);

                        p2 = new Vector2f(
                            actor.Position.Next.X,
                            actor.Position.Next.Y);
                    }

                    p1 = p * (p2 - p1) + p1;
                    p1 *= 32;

                    qb.Add(p1, new IntRect(288, 96, 32, 32));
                }

                Window.Draw(qb, qb.States);

                text.DisplayedString = GetActorDebug(state.Actors[0]);

                RectangleShape shp = new RectangleShape();
                shp.Size = new Vector2f(6, 6);
                shp.OutlineColor = Color.Black;
                shp.OutlineThickness = 2;

                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                    {
                        shp.Position = new Vector2f(x * 32, y * 32);
                        shp.FillColor = (state.Occupied[y][x])
                            ? Color.Red
                            : Color.Green;
                        Window.Draw(shp);
                    }

                Window.Draw(text);
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

        public static string GetActorDebug(Actor actor)
        {
            return String.Format(
                "Position\nP {0}\nC {1}\nN {2}\n" +
                "Direction\nP {3}\nC {4}\nN {5}\n" +
                "Movement\n{6} / {7}",
                    actor.Position.Previous,
                    actor.Position.Current,
                    actor.Position.Next,
                    actor.Direction.Previous,
                    actor.Direction.Current,
                    actor.Direction.Next,
                    actor.Timer.Value,
                    actor.Timer.Other);
        }

        #endregion
    }
}