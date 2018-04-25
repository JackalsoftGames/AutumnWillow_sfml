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
    public class GameState
    {
        public GameState(int width, int height)
        {
            Width = width;
            Height = height;

            Actors = new Actor[2048];
            ActorCount = 0;
            ActorLimit = 2048;

            Occupied = new bool[Width * Height];
            Tiles = new int[Width * Height];
        }

        public int Width;
        public int Height;

        public Actor[] Actors;
        public int ActorCount;
        public int ActorLimit;
        
        public int[] Tiles;
        public bool[] Occupied;
    }

    public class ActorController :
        StateController<GameState>
    {
        #region constructors

        public ActorController(GameState state) :
            base(state)
        {
        }

        #endregion
        #region methods

        public void Occupy(ushort position)
        {
            if (position < State.Occupied.Length)
                State.Occupied[position] = true;
        }

        public void Unoccupy(ushort position)
        {
            if (position < State.Occupied.Length)
                State.Occupied[position] = false;
        }

        public bool IsOccupied(ushort position)
        {
            return (position < State.Occupied.Length)
                ? State.Occupied[position]
                : false;
        }

        #endregion

        public override void Update(Time time)
        {
            for (int i = 0; i < State.ActorCount; i++)
                Tick(ref State.Actors[i]);
        }

        public void Tick(ref Actor actor)
        {
            if (actor.Timer.Other > 0)
            {
                actor.Timer.Value++;

                if (actor.Timer.Value >= actor.Timer.Other)
                {
                    actor.Position.Previous = actor.Position.Current;
                    actor.Position.Current = actor.Position.Next;

                    actor.Direction.Previous = actor.Direction.Current;
                    actor.Direction.Current = actor.Direction.Next;

                    actor.Timer.Value = 0;
                    actor.Timer.Other = 0;
                }
            }
        }

        public void Create()
        {
            if (State.ActorCount >= State.ActorLimit)
                return;

            State.ActorCount++;
        }

        public void Destroy()
        {
        }

        public void Remove()
        {
        }

        public void Move(ref Actor actor, Position position, Direction direction, ushort time)
        {
            if (actor.IsMoving)
                return;

            actor.Position.Next = position;
            actor.Direction.Next = direction;
            actor.Timer.Value = 0;
            actor.Timer.Other = time;
        }

        public void MoveLeft(ref Actor actor, ushort time)
        {
            Move(ref actor, actor.Position.Current.Left, Direction.LEFT, time);
        }

        public void MoveRight(ref Actor actor, ushort time)
        {
            Move(ref actor, actor.Position.Current.Right, Direction.RIGHT, time);
        }

        public void MoveUp(ref Actor actor, ushort time)
        {
            Move(ref actor, actor.Position.Current.Left, Direction.UP, time);
        }

        public void MoveDown(ref Actor actor, ushort time)
        {
            Move(ref actor, actor.Position.Current.Left, Direction.DOWN, time);
        }
        
        public void MoveForward() { }
        public void MoveBackward() { }
        public void MoveWait() { }
        public void MoveCancel() { }
    }
}