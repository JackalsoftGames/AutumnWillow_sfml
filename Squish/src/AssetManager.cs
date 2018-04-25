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
    // TODO: ICollection?
    public sealed class AssetManager<T>
    {
        #region constructors

        public AssetManager()
        {
            ByIndex = new Dictionary<int, T>();
            ByName = new Dictionary<string, T>();
            ByInstance = new Dictionary<T, Asset<T>>();
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
                return ByInstance[instance];
            }
        }

        #endregion
        #region fields

        public IDictionary<int, T> ByIndex;
        public IDictionary<string, T> ByName;
        public IDictionary<T, Asset<T>> ByInstance;

        #endregion
        #region methods

        public void Load(Asset<T> asset)
        {
            if (asset == null)
                return;

            ByIndex.Add(asset.Index, asset.Instance);
            ByName.Add(asset.Name, asset.Instance);
            ByInstance.Add(asset.Instance, asset);
        }

        public void Unload(Asset<T> asset)
        {
            if (asset == null)
                return;

            if (ByIndex.ContainsKey(asset.Index)) ByIndex.Remove(asset.Index);
            if (ByName.ContainsKey(asset.Name)) ByName.Remove(asset.Name);
            if (ByInstance.ContainsKey(asset.Instance)) ByInstance.Remove(asset.Instance);
        }

        #endregion
    }
}