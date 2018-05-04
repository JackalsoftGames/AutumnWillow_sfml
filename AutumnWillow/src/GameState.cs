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
    public sealed class GameState :
        GameComponentBase<Game>
    {
        #region constructors

        public GameState(Game game, int width, int height) :
            base(game)
        {
            if (width < 0) width = 0;
            if (height < 0) height = 0;

            Bounds = new IntRect(0, 0, width, height);

            Actors = new Actor[2048];
            ActorCount = 0;
            {
                for (int i = 0; i < Actors.Length; i++)
                    Actors[i] = new Actor();
            }

            Tiles = new int[Bounds.Height][];
            Occupied = new bool[Bounds.Height][];

            for (int i = 0; i < Bounds.Height; i++)
            {
                Tiles[i] = new int[Bounds.Width];
                Occupied[i] = new bool[Bounds.Width];
            }

            Input = new PlayerAction[4];
            Inventory = new PlayerInventory[4];
        }

        #endregion
        #region fields

        public IntRect Bounds;

        public Actor[] Actors;
        public int ActorCount;

        public int[][] Tiles;
        public bool[][] Occupied;

        public PlayerAction[] Input;
        public PlayerInventory[] Inventory;

        public ushort TimeLimitMaximum;
        public ushort TimeLimit;
        public Delta2<ushort> TimeLimitDelay;

        // TODO:
        // queue for remove, bump, push signals, explosion, etc

        #endregion
        #region methods

        public override void Update(Time time)
        {
            Actor actor;

            for (int i = 0; i < ActorCount; i++)
            {
                actor = Actors[i];
                if (actor == null)
                    continue;

                // Check if actor is in the middle of something
                if (actor.Timer.Other == 0)
                    continue;


                // Actor is in first frame of movement, validate it
                if (actor.Timer.Value == 0)
                {
                }

                actor.Timer.Value++;

                // Actor is at the halfway point of movement
                if (actor.Timer.Value == actor.Timer.Other / 2)
                {
                }

                // Actor has finished movement
                if (actor.Timer.Value >= actor.Timer.Other)
                {
                }
            }
        }

        #endregion

        #region methods :: occupancy

        public bool TileExists(int x, int y)
        {
            return Bounds.Contains(x, y);
        }

        public void Occupy(int x, int y, bool value)
        {
            if (TileExists(x, y))
                Occupied[y][x] = value;
        }

        public bool IsOccupied(int x, int y)
        {
            if (TileExists(x, y))
                return Occupied[y][x];
            return false;
        }

        #endregion
    }
}