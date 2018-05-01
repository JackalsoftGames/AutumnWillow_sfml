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
using AutumnWillow;
using AutumnWillow.Gameplay;

namespace AutumnWillow
{
    // TODO / ???
    // Make IUpdateable, and have it update any game controllers attached to it
    // Allow controllers to have an update priority/order

    public class GameState
    {
        public GameState(int width, int height)
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

        public IntRect Bounds;

        public Actor[] Actors;
        public int ActorCount;

        public int[][] Tiles;
        public bool[][] Occupied;

        public PlayerAction[] Input;
        public PlayerInventory[] Inventory;

        public bool Contains(int x, int y)
        {
            return Bounds.Contains(x, y);
        }

        public bool IsOccupied(int x, int y)
        {
            if (Bounds.Contains(x, y))
                return Occupied[y][x];
            return false;
        }

        public void Occupy(int x, int y)
        {
            if (Bounds.Contains(x, y))
                Occupied[y][x] = true;
        }

        public void Unoccupy(int x, int y)
        {
            if (Bounds.Contains(x, y))
                Occupied[y][x] = false;
        }
    }
}