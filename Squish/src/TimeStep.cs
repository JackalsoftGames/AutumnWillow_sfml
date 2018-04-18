#region license
/* Project: Squish Framework
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

namespace Squish
{
    public sealed class TimeStep :
        IUpdateable
    {
        #region constructors

        public TimeStep(int capacity)
        {
            Values = new Queue<Time>(capacity);
            Capacity = capacity;
        }

        public TimeStep() :
            this(300)
        {
        }

        #endregion

        #region fields

        public Queue<Time> Values;
        public int Capacity;

        public Time Sum;
        public Time Average;

        #endregion

        #region properties

        #endregion

        public void Update(Time time)
        {
            Values.Enqueue(time);
            Sum += time;

            if (Values.Count > Capacity)
            {
                time = Values.Dequeue();
                Sum -= time;
            }

            Average = (Values.Count > 0)
                ? Sum / Values.Count
                : Time.Zero;
        }

    }
}