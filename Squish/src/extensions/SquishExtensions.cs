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

namespace Squish.Extensions
{
    public static class SquishExtensions
    {
        #region ITreeNode.Add

        public static void Add<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return;

            if (obj.IsAncestorOf(other))
                throw new Exception();

            if (other.Parent != null)
                other.Parent.Children.Remove(obj);

            obj.Children.Add(other);
            other.Parent = obj;
        }

        #endregion
        #region ITreeNode.Remove

        public static bool Remove<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (obj.Children.Contains(other))
            {
                if (other != null)
                    other.Parent = default(T);

                return obj.Children.Remove(other);
            }

            return false;
        }

        public static void Remove<T>(this T obj)
            where T : ITreeNode<T>
        {
            if (obj.Parent != null)
                obj.Parent.Children.Remove(obj);

            obj.Parent = default(T);
        }

        #endregion
        #region ITreeNode.Clear

        public static void Clear<T>(this T obj)
            where T : ITreeNode<T>
        {
            foreach (var ITEM in obj.Children)
                ITEM.Parent = default(T);

            obj.Children.Clear();
        }

        #endregion

        #region ITreeNode.GetRoot

        public static T GetRoot<T>(this T obj)
            where T : ITreeNode<T>
        {
            while (obj.Parent != null)
                obj = obj.Parent;
            
            return obj;
        }

        #endregion

        #region ITreeNode.IsRoot

        public static bool IsRoot<T>(this T obj)
            where T : ITreeNode<T>
        {
            return obj.Parent == null;
        }

        #endregion
        #region ITreeNode.IsBranch

        public static bool IsBranch<T>(this T obj)
            where T: ITreeNode<T>
        {
            return
                obj.Children != null &&
                obj.Children.Count > 0;
        }

        #endregion
        #region ITreeNode.IsLeaf

        public static bool IsLeaf<T>(this T obj)
            where T : ITreeNode<T>
        {
            return
                obj.Children == null ||
                obj.Children.Count == 0;
        }

        #endregion

        #region ITreeNode.IsParentOf

        public static bool IsParentOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return false;

            return other.Parent.Equals(obj);
        }

        #endregion
        #region ITreeNode.IsChildOf

        public static bool IsChildOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return false;

            return obj.Parent.Equals(other);
        }

        #endregion
        #region ITreeNode.IsSiblingOf

        public static bool IsSiblingOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null ||
                other.Parent == null)
                return false;

            return other.Parent.Equals(obj.Parent);
        }

        #endregion

        #region ITreeNode.IsAncestorOf

        public static bool IsAncestorOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return false;

            while (other.Parent != null)
            {
                if (other.Parent.Equals(obj))
                    return true;

                other = other.Parent;
            }

            return false;
        }

        #endregion
        #region ITreeNode.IsDescendantOf

        public static bool IsDescendantOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return false;

            while (obj.Parent != null)
            {
                if (obj.Parent.Equals(other))
                    return true;

                obj = obj.Parent;
            }

            return false;
        }

        #endregion
        #region ITreeNode.IsRelativeOf

        public static bool IsRelativeOf<T>(this T obj, T other)
            where T : ITreeNode<T>
        {
            if (other == null)
                return false;

            return obj.GetRoot().Equals(other.GetRoot());
        }

        #endregion
    }
}