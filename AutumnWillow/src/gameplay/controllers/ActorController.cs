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

namespace AutumnWillow.Gameplay
{
    public class ActorController :
        Controller<GameState>
    {
        #region constructors

        public ActorController(GameState state) :
            base(state)
        {
        }

        #endregion
        #region methods

        public override void Update(Time time)
        {
            Actor actor;

            for (int i = 0; i < Target.ActorCount; i++)
            {
                actor = Target.Actors[i];

                if (actor == null)
                    continue;

                if (actor.Timer.Value == 0)
                {
                    if (!actor.Position.Current.Equals(actor.Position.Next))
                        Target.Occupy(actor.Position.Next.X, actor.Position.Next.Y);
                }

                if (actor.Timer.Other > 0)
                {
                    actor.Timer.Value++;

                    if (actor.Timer.Value == actor.Timer.Other / 2)
                    {
                        Target.Unoccupy(actor.Position.Current.X, actor.Position.Current.Y);
                    }

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
        }

        #endregion
        #region methods :: creation

        public bool CanCreate(int x, int y)
        {
            if (Target.ActorCount < Target.Actors.Length)
            {
                if (Target.Contains(x, y))
                    return !Target.Occupied[y][x];
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
        #region methods :: occupy

        public void SetOccupy(int x, int y, bool value)
        {
            if (Target.Bounds.Contains(x, y))
                Target.Occupied[y][x] = value;
        }

        public void Occupy(int x, int y)
        {
            if (Target.Bounds.Contains(x, y))
                Target.Occupied[y][x] = true;
        }

        public void Unoccupy(int x, int y)
        {
            if (Target.Bounds.Contains(x, y))
                Target.Occupied[y][x] = false;
        }

        public bool IsOccupied(int x, int y)
        {
            if (Target.Bounds.Contains(x, y))
                return Target.Occupied[y][x];
            return false;
        }

        #endregion
        #region methods :: movement

        public bool IsMoving(Actor actor)
        {
            return (actor.Timer.Value > 0);
        }

        public bool IsIdle(Actor actor)
        {
            return (actor.Timer.Other == 0);
        }

        public void Move(Actor actor, Position position, Direction direction, ushort time)
        {
            // Only begin movement if it is idling. This guarantees
            // that tile occupancy is updated correctly.
            {
                if (!IsIdle(actor))
                    return;
            }

            // Only check occupancy of target tile if it is a different location
            // eg, an actor always occupies its own tile, so we don't check for
            // occupancy in that case
            {
                if (!actor.Position.Current.Equals(position))
                {
                    if (Target.IsOccupied(position.X, position.Y))
                        return;
                }
            }

            // Do a bounds check
            {
                if (!Target.Contains(position.X, position.Y))
                    return;
            }

            // All global conditions for movement are clear, so we can begin moving.
            // We still need to validate it elsewhere on an object-by-object basis.
            {
                actor.Position.Next = position;
                actor.Direction.Next = direction;

                actor.Timer.Value = 0;
                actor.Timer.Other = time;
            }
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
            Direction direction = actor.Direction.Current.Next(Direction.FORWARD);
            Move(actor, actor.Position.Current.Next(direction), direction, time);
        }

        public void MoveBackward(Actor actor, ushort time)
        {
            Direction direction = actor.Direction.Current.Next(Direction.BACKWARD);
            Move(actor, actor.Position.Current.Next(direction), direction, time);
        }

        public void MoveClockwise(Actor actor, ushort time)
        {
            Direction direction = actor.Direction.Current.Next(Direction.CLOCKWISE);
            Move(actor, actor.Position.Current.Next(direction), direction, time);
        }

        public void MoveCounterClockwise(Actor actor, ushort time)
        {
            Direction direction = actor.Direction.Current.Next(Direction.COUNTERCLOCKWISE);
            Move(actor, actor.Position.Current.Next(direction), direction, time);
        }

        public void MoveWait(Actor actor, ushort time)
        {
            Move(actor, actor.Position.Current, actor.Direction.Current, time);
        }

        #endregion
    }
}