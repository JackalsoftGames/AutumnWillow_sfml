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
    public sealed class QuadBatch :
        Drawable
    {
        #region static fields

        private static Vector2f s_Position = new Vector2f(0, 0);
        private static Transform s_Transform = Transform.Identity;
        private static IntRect s_TextureRect = new IntRect(0, 0, 1, 1);
        private static Color s_Color = Color.White;

        #endregion

        #region constructors

        public QuadBatch(uint capacity)
        {
            Vertices = new Vertex[capacity * 4];
            Start = 0;
            Count = 0;
            PrimitiveType = PrimitiveType.Quads;
            States = RenderStates.Default;
        }

        #endregion
        #region fields

        public Vertex[] Vertices;
        public uint Start;
        public uint Count;
        public PrimitiveType PrimitiveType;
        public RenderStates States;

        #endregion
        #region methods

        public void Add(ref Vector2f position, ref Transform transform, ref IntRect textureRect, ref Color color)
        {
            Vertices[Count + 0] = new Vertex(
                position + transform.TransformPoint(0, 0),
                color,
                new Vector2f(textureRect.Left, textureRect.Top));

            Vertices[Count + 1] = new Vertex(
                position + transform.TransformPoint(0, textureRect.Height),
                color,
                new Vector2f(textureRect.Left, textureRect.Top + textureRect.Height));

            Vertices[Count + 2] = new Vertex(
                position + transform.TransformPoint(textureRect.Width, textureRect.Height),
                color,
                new Vector2f(textureRect.Left + textureRect.Width, textureRect.Top + textureRect.Height));

            Vertices[Count + 3] = new Vertex(
                position + transform.TransformPoint(textureRect.Width, 0),
                color,
                new Vector2f(textureRect.Left + textureRect.Width, textureRect.Top));

            Count += 4;
        }

        public void Add(Vector2f position, Transform transform, IntRect textureRect, Color color)
        {
            Add(ref position, ref transform, ref textureRect, ref color);
        }

        public void Add(Vector2f position, Transform transform, IntRect textureRect)
        {
            Add(ref position, ref transform, ref textureRect, ref s_Color);
        }

        public void Add(Vector2f position, IntRect textureRect, Color color)
        {
            Add(ref position, ref s_Transform, ref textureRect, ref color);
        }

        public void Add(Vector2f position, IntRect textureRect)
        {
            Add(ref position, ref s_Transform, ref textureRect, ref s_Color);
        }

        public void Add(ref Vertex p0, ref Vertex p1, ref Vertex p2, ref Vertex p3)
        {
            Vertices[Count + 0] = p0;
            Vertices[Count + 1] = p1;
            Vertices[Count + 2] = p2;
            Vertices[Count + 3] = p3;
            Count += 4;
        }

        public void Add(Vertex p0, Vertex p1, Vertex p2, Vertex p3)
        {
            Add(ref p0, ref p1, ref p2, ref p3);
        }

        public void Clear()
        {
            Start = 0;
            Count = 0;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(Vertices, Start, Count, PrimitiveType, states);
        }

        #endregion
    }
}