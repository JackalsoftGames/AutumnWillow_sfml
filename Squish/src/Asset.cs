﻿#region license
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
    public sealed class Asset<T> :
        IDisposable
    {
        #region static fields

        private static readonly bool s_IsDisposable =
            typeof(IDisposable).IsAssignableFrom(typeof(T));

        #endregion

        #region constructors

        public Asset(int index, string name, T value)
        {
            Index = index;
            Name = name;
            Value = value;
        }

        #endregion
        #region fields

        public int Index;
        public string Name;
        public T Value;

        #endregion
        #region methods

        public void Dispose()
        {
            if (Value != null)
            {
                if (s_IsDisposable)
                    ((IDisposable)Value).Dispose();
            }
        }

        #endregion
    }
}