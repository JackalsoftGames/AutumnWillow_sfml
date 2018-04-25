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
using Squish.Mathematics;
#endregion

namespace Squish
{
    public sealed class Asset<T> :
        IDisposable
    {
        #region static fields

        private static bool IsDisposable = typeof(IDisposable).IsAssignableFrom(typeof(T));

        #endregion

        #region constructors

        public Asset(int index, string name, T instance)
        {
            Index = index;
            Name = name;
            Instance = instance;
        }

        public Asset(int index, T instance)
        {
            Index = index;
            Name = String.Empty;
            Instance = instance;
        }

        #endregion
        #region fields

        public int Index;
        public string Name;
        public T Instance;

        #endregion
        #region methods

        public void Dispose()
        {
            Index = 0;
            Name = String.Empty;

            if (Instance != null)
            {
                if (IsDisposable)
                    ((IDisposable)Instance).Dispose();
                Instance = default(T);
            }
        }
        
        #endregion
    }
}