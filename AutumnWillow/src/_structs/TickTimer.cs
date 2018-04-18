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
#endregion

namespace AutumnWillow
{
    // TODO:
    // - GetPercent should return 0 when maximum == 0
    // - ITimer? (Start, stop, pause, restart, reset)
    // - Repeat? Pause?
    // - Debugger display / tostring

    public struct TickTimer
    {
        #region constructors

        public TickTimer(ushort current, ushort maximum)
        {
            Current = current;
            Maximum = maximum;
        }

        public TickTimer(ushort value)
        {
            Current = value;
            Maximum = value;
        }

        #endregion

        // Public        
        #region fields

        public ushort Current;
        public ushort Maximum;

        #endregion
        #region properties

        public bool IsElapsed
        {
            get
            {
                return
                    Maximum == 0 ||
                    Current >= Maximum;
            }
        }

        public bool IsRunning
        {
            get
            {
                return
                    Maximum > 0 &&
                    Current >= Maximum;
            }
        }

        #endregion
        #region methods

        public float GetPercent()
        {
            if (Current >= Maximum) return 1.00f;
            if (Current <= 0) return 0.00f;

            return Current / (float)Maximum;
        }

        public void Update(float time)
        {

        }

        #endregion
    }
}