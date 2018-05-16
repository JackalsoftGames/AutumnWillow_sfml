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
    public sealed class GameState
    {
        #region constructors

        public GameState(Game game, int width, int height)
        {
            if (width < 0) width = 0;
            if (height < 0) height = 0;

            Bounds = new IntRect(0, 0, width, height);

            Actors = new Actor[2048];
            ActorsByPosition = new SortedList<Position, Actor>(2048);
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

            Time = 200;
            Tick = 0;
            TickRate = new Delta2<ushort>(90);
        }

        #endregion
        #region fields

        public IntRect Bounds;

        public Actor[] Actors;
        public ushort ActorCount;
        public SortedList<Position, Actor> ActorsByPosition;

        public int[][] Tiles;
        public bool[][] Occupied;

        public PlayerAction[] Input;
        public PlayerInventory[] Inventory;

        public short Time;
        public short Score;
        public short Gems;

        public short GemQuotaEasy;
        public short GemQuotaHard;

        public ushort Tick;
        public Delta2<ushort> TickRate;

        // TODO:
        // queue for remove, bump, push signals, explosion, etc

        #endregion
    }
}