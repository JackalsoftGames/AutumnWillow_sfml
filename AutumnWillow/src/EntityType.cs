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
    public sealed class EntityType
    {
        public string Name;
        public string Tooltip;

        public Behavior Behavior;
        // public BehaviorFlags BehaviorFlags;

        public ushort Texture;
        public ushort Frames;

        public short GemValue;
        public short ScoreValue;
        public short TimeValue;

        public PlayerInventory AddsItem;
        public PlayerInventory NeedsItem;
        public PlayerInventory RemovesItem;
    }
}