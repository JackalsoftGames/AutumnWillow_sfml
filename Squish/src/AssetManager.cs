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
    public sealed class AssetManager<T>
    {
        #region constructors

        public AssetManager()
        {
            ByIndex = new Dictionary<int, T>();
            ByName = new Dictionary<string, T>();
            ByValue = new Dictionary<T, Asset<T>>();
        }

        #endregion
        #region indexers

        public T this[int index]
        {
            get
            {
                return ByIndex[index];
            }
        }

        public T this[string name]
        {
            get
            {
                return ByName[name];
            }
        }

        public Asset<T> this[T instance]
        {
            get
            {
                return ByValue[instance];
            }
        }

        #endregion
        #region properties

        public IDictionary<int, T> ByIndex
        {
            get;
            private set;
        }

        public IDictionary<string, T> ByName
        {
            get;
            private set;
        }

        public IDictionary<T, Asset<T>> ByValue
        {
            get;
            private set;
        }

        #endregion
        #region methods

        public void Add(Asset<T> asset)
        {
            if (asset == null)
                return;

            ByIndex.Add(asset.Index, asset.Value);
            ByName.Add(asset.Name, asset.Value);
            ByValue.Add(asset.Value, asset);
        }

        public void Remove(Asset<T> asset)
        {
            if (asset == null)
                return;

            ByIndex.Remove(asset.Index);
            ByName.Remove(asset.Name);
            ByValue.Remove(asset.Value);
        }

        public void Clear()
        {
            ByIndex.Clear();
            ByName.Clear();
            ByValue.Clear();
        }

        #endregion
    }
}