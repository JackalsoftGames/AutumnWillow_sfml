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
    public class MapController :
        GameControllerBase
    {
        #region constructors

        public MapController(GameState state) :
            base(state)
        {
        }
        
        #endregion
        
        #region methods :: creation

        public bool CanCreate(int x, int y)
        {
            if (State.ActorCount < State.Actors.Length)
            {
                if (State.Bounds.Contains(x, y))
                    return !State.Occupied[y][x];
            }
            return false;
        }

        public Actor Create()
        {
            return null;
        }

        public void Destroy()
        {
        }

        public void Remove()
        {
        }

        public void Transform()
        {
        }

        #endregion

        #region methods :: map

        public bool TileExists(int x, int y)
        {
            return State.Bounds.Contains(x, y);
        }

        public bool IsOccupied(int x, int y)
        {
            if (TileExists(x, y))
                return State.Occupied[y][x];
            return false;
        }

        public void Occupy(int x, int y, bool value)
        {
            if (TileExists(x, y))
                State.Occupied[y][x] = value;
        }

        public void Occupy(int x, int y)
        {
            Occupy(x, y, true);
        }

        public void Unoccupy(int x, int y)
        {
            Occupy(x, y, false);
        }

        #endregion

        #region methods :: movement

        public void Move(Actor actor, Position position, Direction direction, ushort time)
        {
            if (actor.Timer.Value > 0)
                return;

            if (!TileExists(position.X, position.Y))
                return;

            if (!position.Equals(actor.Position.Current))
            {
                if (IsOccupied(position.X, position.Y))
                    return;
            }

            actor.Position.Next = position;
            actor.Direction.Next = direction;

            actor.Timer.Value = 0;
            actor.Timer.Other = time;
        }

        public void MoveLeft(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current.Left, Direction.LEFT, time);
        }

        public void MoveRight(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current.Right, Direction.RIGHT, time);
        }

        public void MoveUp(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current.Up, Direction.UP, time);
        }

        public void MoveDown(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current.Down, Direction.DOWN, time);
        }

        public void MoveForward(Actor actor, ushort time)
        {
            Direction direction = Position.GetNext(actor.Direction.Current | Direction.FORWARD);
            Move(actor, Position.GetNext(actor.Position.Current, direction), direction, time);
        }

        public void MoveBackward(Actor actor, ushort time)
        {
            Direction direction = Position.GetNext(actor.Direction.Current | Direction.BACKWARD);
            Move(actor, Position.GetNext(actor.Position.Current, direction), direction, time);
        }

        public void MoveClockwise(Actor actor, ushort time)
        {
            Direction direction = Position.GetNext(actor.Direction.Current | Direction.CLOCKWISE);
            Move(actor, Position.GetNext(actor.Position.Current, direction), direction, time);
        }

        public void MoveCounterClockwise(Actor actor, ushort time)
        {
            Direction direction = Position.GetNext(actor.Direction.Current | Direction.COUNTERCLOCKWISE);
            Move(actor, Position.GetNext(actor.Position.Current, direction), direction, time);
        }

        public void MoveWait(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current, actor.Direction.Current, time);
        }

        #endregion
    }
}