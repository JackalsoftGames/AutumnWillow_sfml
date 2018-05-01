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
    // - Allows objects to attach to others
    // - Eg, a GameComponent or a GameStateComponent
    // - Need universal naming convention, eg GetTarget() versus a property
    // - ComponentBase() which implements a private readonly property?

    public interface IComponentOf<T>
    {
        // T GetOwner();
    }
}