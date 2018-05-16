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
    public class InputController :
        GameComponentBase<Game>
    {
        #region constructors

        public InputController(Game game) :
            base(game)
        {
        }

        #endregion
        #region methods

        public override void Update(Time time)
        {
            PlayerAction input = PlayerAction.NONE;

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) ||
                Keyboard.IsKeyPressed(Keyboard.Key.A) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad4))
            {
                input |= PlayerAction.LEFT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) ||
                Keyboard.IsKeyPressed(Keyboard.Key.D) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad6))
            {
                input |= PlayerAction.RIGHT;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) ||
                Keyboard.IsKeyPressed(Keyboard.Key.W) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad8))
            {
                input |= PlayerAction.UP;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) ||
                Keyboard.IsKeyPressed(Keyboard.Key.S) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Numpad2))
            {
                input |= PlayerAction.DOWN;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LShift) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RShift) ||
                Keyboard.IsKeyPressed(Keyboard.Key.X))
            {
                input |= PlayerAction.ACTION_PUSH;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) ||
                Keyboard.IsKeyPressed(Keyboard.Key.RControl) ||
                Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                input |= PlayerAction.ACTION_ITEM;
            }

            Game.State.Input[0] = input;
            for (int i = 1; i < Game.State.Input.Length; i++)
                Game.State.Input[i] = PlayerAction.NONE;
        }

        #endregion
    }
}