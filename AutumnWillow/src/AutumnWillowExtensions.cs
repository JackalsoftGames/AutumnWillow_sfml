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
    public static class AutumnWillowExtensions
    {
        #region Direction.Next

        public static Direction Next(this Direction value)
        {
            switch (value)
            {
                case (Direction.FORWARD | Direction.LEFT): return Direction.LEFT;
                case (Direction.FORWARD | Direction.RIGHT): return Direction.RIGHT;
                case (Direction.FORWARD | Direction.UP): return Direction.UP;
                case (Direction.FORWARD | Direction.DOWN): return Direction.DOWN;

                case (Direction.BACKWARD | Direction.LEFT): return Direction.RIGHT;
                case (Direction.BACKWARD | Direction.RIGHT): return Direction.LEFT;
                case (Direction.BACKWARD | Direction.UP): return Direction.DOWN;
                case (Direction.BACKWARD | Direction.DOWN): return Direction.UP;

                case (Direction.CLOCKWISE | Direction.LEFT): return Direction.UP;
                case (Direction.CLOCKWISE | Direction.RIGHT): return Direction.DOWN;
                case (Direction.CLOCKWISE | Direction.UP): return Direction.RIGHT;
                case (Direction.CLOCKWISE | Direction.DOWN): return Direction.LEFT;

                case (Direction.COUNTERCLOCKWISE | Direction.LEFT): return Direction.DOWN;
                case (Direction.COUNTERCLOCKWISE | Direction.RIGHT): return Direction.UP;
                case (Direction.COUNTERCLOCKWISE | Direction.UP): return Direction.LEFT;
                case (Direction.COUNTERCLOCKWISE | Direction.DOWN): return Direction.RIGHT;

                case (Direction.LEFT): return Direction.LEFT;
                case (Direction.RIGHT): return Direction.RIGHT;
                case (Direction.UP): return Direction.UP;
                case (Direction.DOWN): return Direction.DOWN;

                default: return value;
            }
        }

        public static Direction Next(this Direction value, Direction other)
        {
            switch (value | other)
            {
                case (Direction.FORWARD | Direction.LEFT): return Direction.LEFT;
                case (Direction.FORWARD | Direction.RIGHT): return Direction.RIGHT;
                case (Direction.FORWARD | Direction.UP): return Direction.UP;
                case (Direction.FORWARD | Direction.DOWN): return Direction.DOWN;

                case (Direction.BACKWARD | Direction.LEFT): return Direction.RIGHT;
                case (Direction.BACKWARD | Direction.RIGHT): return Direction.LEFT;
                case (Direction.BACKWARD | Direction.UP): return Direction.DOWN;
                case (Direction.BACKWARD | Direction.DOWN): return Direction.UP;

                case (Direction.CLOCKWISE | Direction.LEFT): return Direction.UP;
                case (Direction.CLOCKWISE | Direction.RIGHT): return Direction.DOWN;
                case (Direction.CLOCKWISE | Direction.UP): return Direction.RIGHT;
                case (Direction.CLOCKWISE | Direction.DOWN): return Direction.LEFT;

                case (Direction.COUNTERCLOCKWISE | Direction.LEFT): return Direction.DOWN;
                case (Direction.COUNTERCLOCKWISE | Direction.RIGHT): return Direction.UP;
                case (Direction.COUNTERCLOCKWISE | Direction.UP): return Direction.LEFT;
                case (Direction.COUNTERCLOCKWISE | Direction.DOWN): return Direction.RIGHT;

                case (Direction.LEFT): return Direction.LEFT;
                case (Direction.RIGHT): return Direction.RIGHT;
                case (Direction.UP): return Direction.UP;
                case (Direction.DOWN): return Direction.DOWN;

                default: return (value | other);
            }
        }

        #endregion
        #region Position.Next

        public static Position Next(this Position obj, Direction value)
        {
            switch (value.Next())
            {
                case (Direction.LEFT): return obj.Left;
                case (Direction.RIGHT): return obj.Right;
                case (Direction.UP): return obj.Up;
                case (Direction.DOWN): return obj.Down;
            }

            return obj;
        }

        #endregion
    }
}