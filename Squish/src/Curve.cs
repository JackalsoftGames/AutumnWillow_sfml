#region license
/* Project: Squish Framework
 * Author: Jackalsoft Games (http://www.jackalsoft.net/)
 * Date: April 2018
 * 
 * Code and assets are copyright Jackalsoft Games, or their respective
 * owners. No warranty (express or implied) is granted.
 * The Squish Framework is released under the GPLv3 license.
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

namespace Squish
{
    // TODO:
    // - Lots of implementations!
    // - Rename to static class Curve?
    // - Takes a normalized value 0..1 - does not check for bounds, outputs 0..1
    // - Negatives are okay? It should just return a mirror, maybe.

    // Maybe we should have a delegate to in and out functions as a form of "glue"
    // then we'll only have 1/3 of the funcs to implement..
    // public static void Interpolate(inFunc, outFunc, amount) { }

    public static class Curve
    {
        public static void Linear() { }

        public static void InCatmullRom() { }
        public static void OutCatmullRom() { }
        public static void InOutCatmullRom() { }
        public static void InHermite() { }
        public static void OutHermite() { }
        public static void InOutHermite() { }
        public static void InSmoothStep() { }
        public static void OutSmoothStep() { }
        public static void InOutSmoothStep() { }
        public static void InSmootherStep() { }
        public static void OutSmootherStep() { }
        public static void InOutSmootherStep() { }

        public static void InSine() { }
        public static void OutSine() { }
        public static void InOutSine() { }
        public static void InQuadratic() { }
        public static void OutQuadratic() { }
        public static void InOutQuadratic() { }
        public static void InCubic() { }
        public static void OutCubic() { }
        public static void InOutCubic() { }
        public static void InQuartic() { }
        public static void OutQuartic() { }
        public static void InOutQuartic() { }
        public static void InQuintic() { }
        public static void OutQuintic() { }
        public static void InOutQuintic() { }
        public static void InExponent() { }
        public static void OutExponent() { }
        public static void InOutExponent() { }
        public static void InCircle() { }
        public static void OutCircle() { }
        public static void InOutCircle() { }
        public static void InBack() { }
        public static void OutBack() { }
        public static void InOutBack() { }
        public static void InElastic() { }
        public static void OutElastic() { }
        public static void InOutElastic() { }
        public static void InBounce() { }
        public static void OutBounce() { }
        public static void InOutBounce() { }
    }
}