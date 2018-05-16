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
    public sealed class GameControllers :
        GameComponentBase<Game>
    {
        public GameControllers(Game game) :
            base(game)
        {
        }
    }

    public sealed class GameOptions
    {
        public ushort VolumeMaster;
        public ushort VolumeMusic;
        public ushort VolumeSound;
        public ushort VolumeMenu;

        public ushort TargetFPS;

        public bool PauseGameWhenLoseFocus;
        public bool PauseAudioWhenLoseFocus;

        public Keyboard.Key ActionLeft = Keyboard.Key.Left;
        public Keyboard.Key ActionRight = Keyboard.Key.Right;
        public Keyboard.Key ActionUp = Keyboard.Key.Up;
        public Keyboard.Key ActionDown = Keyboard.Key.Down;
        public Keyboard.Key ActionItem = Keyboard.Key.LShift;
        public Keyboard.Key ActionPush = Keyboard.Key.LControl;
    }

    public sealed class BackgroundController :
        GameComponentBase<Game>
    {
        #region constructors

        public BackgroundController(Game game) :
            base(game)
        {
            RenderTexture = new RenderTexture(256, 256);
        }

        #endregion
        #region properties

        public RenderTexture RenderTexture;
        public IntRect TextureRect;

        public Vector2f Position;
        public Vector2f Velocity;

        #endregion
        #region methods

        public override void Update(Time time)
        {
            Position += Velocity;
        }

        #endregion
    }

    public sealed class Game :
        GameBase
    {
        #region constructors

        public Game()
        {
            Window = new RenderWindow(
                new VideoMode(800, 600),
                "Autumn Willow",
                Styles.Default,
                new ContextSettings());

            Content = new GameContent();
            State = new GameState(this, 18, 18);
            Components = new List<IComponent<Game>>();

            DrawBatch = new QuadBatch(1024);
            AudioBatch = new QuadBatch(256);
        }

        #endregion
        #region fields

        public InputController InputController;
        public StatusController StatusController;
        public MapController MapController;
        public BackgroundController BackgroundController;

        #endregion
        #region properties

        public GameOptions Options { get; private set; }

        public GameContent Content
        {
            get;
            private set;
        }

        public GameState State
        {
            get;
            private set;
        }

        public ICollection<IComponent<Game>> Components
        {
            get;
            private set;
        }

        public QuadBatch DrawBatch
        {
            get;
            private set;
        }

        public QuadBatch AudioBatch
        {
            get;
            private set;
        }

        #endregion
        #region methods :: initialize

        protected override void InitializePre()
        {
            Window.SetIcon(32, 32, new Image("res/icon.png").Pixels);
            Window.SetFramerateLimit(60);
            
            Window.Closed += Closed;
            Window.GainedFocus += GainedFocus;
            Window.LostFocus += LostFocus;
        }

        protected override void Initialize()
        {
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
            #region load frames

            Content.Frames.Add(new Asset<SpriteSheet>(1, "player", new SpriteSheet(
                Content.Textures["actor"],
                SpriteSheet.CreateFrames(16, 4, 0, 256, 32, 32, 32, 32))));

            Content.Frames.Add(new Asset<SpriteSheet>(2, "wall", new SpriteSheet(
                Content.Textures["tile"],
                SpriteSheet.CreateFrames(1, 1, 0, 0, 32, 32, 32, 32))));

            Content.Frames.Add(new Asset<SpriteSheet>(3, "rock", new SpriteSheet(
                Content.Textures["actor"],
                SpriteSheet.CreateFrames(1, 1, 128, 384, 32, 32, 32, 32))));

            Content.Frames.Add(new Asset<SpriteSheet>(4, "gem", new SpriteSheet(
                Content.Textures["actor"],
                SpriteSheet.CreateFrames(1, 1, 0, 384, 32, 32, 32, 32))));

            #endregion

            BackgroundController = new BackgroundController(this);
            InputController = new InputController(this);
            StatusController = new StatusController(this);
            MapController = new MapController(this);

            Components.Add(BackgroundController);
            Components.Add(InputController);
            Components.Add(StatusController);
            Components.Add(MapController);

            BackgroundController.Velocity = new Vector2f(10, 4) / 60f;
        }

        protected override void InitializePost()
        {
            ui_frame = new RectangleShape();
            ui_frame.Position = new Vector2f(0, 0);
            ui_frame.Size = new Vector2f(800, 24);
            ui_frame.FillColor = new Color(128, 0, 0);

            ui_text = new Text();
            ui_text.Font = Content.Fonts["old_wizard"];
            ui_text.CharacterSize = 16;

            Random r = new Random();
            for (int y = 0; y < State.Bounds.Height; y++)
                for (int x = 0; x < State.Bounds.Width; x++)
                {
                    State.Tiles[y][x] = r.Next(0, Content.Frames.ByIndex.Count + 1);
                }

            BackgroundController.Velocity = (r.NextVector2f() * 2f - new Vector2f(1, 1)) * 2;

            Vector2f a, b, c, d;
            a = r.NextVector2f() * 400 + new Vector2f(100, 100);
            b = r.NextVector2f() * 400 + new Vector2f(100, 100);
            c = r.NextVector2f() * 400 + new Vector2f(100, 100);
            d = r.NextVector2f() * 400 + new Vector2f(100, 100);

            a = new Vector2f(100, 100);
            b = new Vector2f(200, 100);
            c = new Vector2f(100, 200);
            d = new Vector2f(400, 400);

            float a1, a2;
            MathHelper.TriangleArea(ref a, ref b, ref c, out a1);
            MathHelper.TriangleArea(ref b, ref c, ref d, out a2);

            for (int i = 0; i < pt.Length; i++)
            {
                if (r.NextDouble() * (a1 + a2) < a1)
                    pt[i].Position = r.NextTriangle(a, b, c);
                else
                    pt[i].Position = r.NextTriangle(b, c, d);
                pt[i].Color = Color.White;
            }
        }

        #endregion
        #region methods :: update

        protected override void UpdatePre(Time time)
        {
        }

        protected override void Update(Time time)
        {
            foreach (var ITEM in Components)
                ITEM.Update(time);
        }

        protected override void UpdatePost(Time time)
        {
        }

        #endregion
        #region methods :: draw

        protected override void DrawPre(Time time)
        {
            Window.Clear(Color.Black);
        }

        protected override void Draw(Time time)
        {
            Window.Draw(pt, PrimitiveType.Points);

            // Background
            if(!true)
            {
                BackgroundController.RenderTexture.Clear(Color.Black);

                Sprite spr1 = new Sprite(Content.Textures["background"]);
                spr1.TextureRect = BackgroundController.TextureRect = new IntRect(0, 0, 64, 64);

                RenderStates rs = RenderStates.Default;
                rs.Transform.Translate(
                    BackgroundController.Position.X % 64,
                    BackgroundController.Position.Y % 64);

                for (int y = -1; y <= 4; y++)
                    for (int x = -1; x <= 4; x++)
                    {
                        spr1.Position = new Vector2f(x, y) * 64;
                        BackgroundController.RenderTexture.Draw(spr1, rs);
                    }

                Sprite spr2 = new Sprite(BackgroundController.RenderTexture.Texture);
                spr2.Texture.Repeated = true;
                spr2.TextureRect = new IntRect(0, 0, 800, 600);

                Window.Draw(spr2);
            }

            // Map
            if (true)
            {
                Window.SetView(new View(new FloatRect(0, 0, Window.Size.X, Window.Size.Y)));

                DrawBatch.Clear();

                RenderStates rs = RenderStates.Default;
                rs.Transform.Translate(112, 24);

                Window.Draw(DrawBatch, rs);
            }

            // UI
            {
                Window.Draw(ui_frame);

                ui_text.DisplayedString = String.Format(
                    "TIME: {0}", State.Time);
                ui_text.Position = new Vector2f(0, 1);
                Window.Draw(ui_text);

                ui_text.DisplayedString = String.Format(
                    "SCORE: {0}", State.Score);
                ui_text.Position = new Vector2f(200, 1);
                Window.Draw(ui_text);

                ui_text.DisplayedString = String.Format(
                    "GEMS: {0}", State.Gems);
                ui_text.Position = new Vector2f(400, 1);
                Window.Draw(ui_text);

                ui_text.DisplayedString = String.Format(
                    "INPUT: {0}", State.Input[0]);
                ui_text.Position = new Vector2f(600, 1);
                Window.Draw(ui_text);
            }
        }

        protected override void DrawPost(Time time)
        {
            Window.Display();
        }

        #endregion
        #region methods :: events

        private void Closed(object sender, EventArgs e)
        {
            Window.Close();
            IsRunning = false;
        }

        private void GainedFocus(object sender, EventArgs e)
        {
            // unpause game and sounds
        }

        private void LostFocus(object sender, EventArgs e)
        {
            // pause game and sounds
            // or fade
        }

        #endregion

        RectangleShape ui_frame;
        Text ui_text;

        Vertex[] pt = new Vertex[2048];
    }
}