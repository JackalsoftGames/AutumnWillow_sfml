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

        public Game()
        {
            Window = new RenderWindow(
                new VideoMode(480, 480),
                "Autumn Willow",
                Styles.Default,
                new ContextSettings());

            Content = new Content(this);
            State = new GameState(10, 10);
            Controllers = new Controllers(State);
        }

        #endregion
        #region fields

        // Mostly debug stuff here
        Text text;
        QuadBatch qb;

        #endregion
        #region properties

        public Content Content { get; private set; }
        public GameState State { get; private set; }
        public Controllers Controllers { get; private set; }

        #endregion
        #region methods :: initialize

        public override void InitializePre()
        {
            // check settings
            Window.SetIcon(32, 32, new Image("res/icon.png").Pixels);
        }

        public override void Initialize()
        {
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

            qb = new QuadBatch(1024);
            qb.States.Texture = Content.Textures["tile"];
        }

        public override void InitializePost()
        {
            // perform cleanup
            text = new Text("", Content.Fonts[0]);
            text.Font.GetTexture(text.CharacterSize).Smooth = false;
            text.CharacterSize = 18;

            Random r = new Random();

            for (int y = 0; y < State.Bounds.Height; y++)
                for (int x = 0; x < State.Bounds.Width; x++)
                {
                    if (r.Next(0, 3) == 0)
                        State.Tiles[y][x] = 1;
                }

            State.Actors[0].Direction = new Delta3<Direction>(Direction.DOWN);
            State.ActorCount = 1;

            Music m = Content.Music[0];
            m.Play();
            m.RelativeToListener = true;
        }

        #endregion
        #region methods :: update

        public override void UpdatePre(Time time)
        {
        }

        public override void Update(Time time)
        {
            Controllers.Update(time);

            // Debug
            PlayerAction input = State.Input[0];

            var actor = State.Actors[0];
            ushort moveTime = (input.HasFlag(PlayerAction.ACTION_PUSH))
                ? (ushort)36
                : (ushort)12;

            if (input.HasFlag(PlayerAction.LEFT)) Controllers.Actors.MoveLeft(actor, moveTime);
            if (input.HasFlag(PlayerAction.RIGHT)) Controllers.Actors.MoveRight(actor, moveTime);
            if (input.HasFlag(PlayerAction.UP)) Controllers.Actors.MoveUp(actor, moveTime);
            if (input.HasFlag(PlayerAction.DOWN)) Controllers.Actors.MoveDown(actor, moveTime);
        }

        public override void UpdatePost(Time time)
        {
        }

        #endregion
        #region methods :: draw

        public override void DrawPre(Time time)
        {
        }

        public override void Draw(Time time)
        {
            Window.Clear(Color.Black);
            {
                qb.Clear();

                int w = State.Bounds.Width;
                int h = State.Bounds.Height;

                if (w > 16) w = 16;
                if (h > 16) h = 16;

                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                    {
                        if (State.Tiles[y][x] == 0)
                            continue;
                        qb.Add(new Vector2f(x * 32, y * 32), new IntRect(0, 0, 32, 32));
                    }

                for (int i = 0; i < State.ActorCount; i++)
                {
                    var actor = State.Actors[i];

                    Vector2f p1, p2;
                    float p = actor.GetPercent();
                    {
                        p1 = new Vector2f(
                            actor.Position.Current.X,
                            actor.Position.Current.Y);

                        p2 = new Vector2f(
                            actor.Position.Next.X,
                            actor.Position.Next.Y);
                    }

                    p1 = p * (p2 - p1) + p1;

                    qb.Add(p1 * 32, new IntRect(192, 192, 32, 32), Color.Blue);
                }
                Window.Draw(qb, qb.States);

                text.Position = new Vector2f(384-32, 0);
                text.DisplayedString = GetActorDebug(State.Actors[0]);

                RectangleShape shp = new RectangleShape();
                shp.Size = new Vector2f(6, 6);
                shp.OutlineColor = Color.Black;
                shp.OutlineThickness = 2;

                // FIXME (slow)
                // Draw calls are slow, needs batching

                for (int y = 0; y < h; y++)
                    for (int x = 0; x < w; x++)
                    {
                        shp.Position = new Vector2f(x * 32, y * 32);
                        shp.FillColor = (State.Occupied[y][x])
                            ? Color.Red
                            : Color.Green;
                        //Window.Draw(shp);
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

        public static string GetActorDebug(AutumnWillow.Gameplay.Actor actor)
        {
            return String.Format(
                "Position\nP {0}\nC {1}\nN {2}\n\n" +
                "Direction\nP {3}\nC {4}\nN {5}\n\n" +
                "Movement\n{6} / {7}\n\n",
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