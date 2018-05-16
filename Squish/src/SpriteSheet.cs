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
    public sealed class SpriteSheet
    {
        #region static methods

        public static IntRect[] CreateFrames(
            int count, int stride,
            int x, int y,
            int width, int height,
            int hstep, int vstep)
        {
            if (count < 0) count = 0;
            if (stride < 1) stride = 1;

            IntRect[] result = new IntRect[count];

            for (int i = 0; i < count; i++)
            {
                result[i] = new IntRect(
                    (i % stride) * hstep + x,
                    (i / stride) * vstep + y,
                    width, height);
            }

            return result;
        }

        public static IntRect GetFrame(IntRect[] frames, int[] index, float percent)
        {
            if (frames == null || frames.Length == 0)
                return new IntRect();

            if (frames.Length == 1)
                return frames[0];

            if (index == null || index.Length == 0)
            {
                if (percent <= 0.00f)
                    return frames[0];

                else if (percent >= 1.00f)
                    return frames[frames.Length - 1];

                else
                    return frames[(int)(percent * frames.Length)];
            }

            int frameIndex;
            {
                if (percent <= 0.00f)
                    frameIndex = index[0];

                else if (percent >= 1.00f)
                    frameIndex = index[index.Length - 1];

                else
                    frameIndex = index[(int)(percent * index.Length)];
            }

            return frames[frameIndex % frames.Length];
        }

        public static IntRect GetFrame(IntRect[] frames, int[] index, float current, float maximum)
        {
            return (maximum == 0.00f)
                ? SpriteSheet.GetFrame(frames, index, 0.00f)
                : SpriteSheet.GetFrame(frames, index, current / maximum % 1);
        }

        public static IntRect GetFrame(IntRect[] frames, float percent)
        {
            return SpriteSheet.GetFrame(frames, null, percent);
        }

        public static IntRect GetFrame(IntRect[] frames, float current, float maximum)
        {
            return (maximum == 0.00f)
                ? SpriteSheet.GetFrame(frames, null, 0.00f)
                : SpriteSheet.GetFrame(frames, null, current / maximum % 1);
        }

        #endregion

        #region constructors

        public SpriteSheet(Texture texture, IntRect[] frames)
        {
            Texture = texture;
            Frames = frames;
        }

        public SpriteSheet(Texture texture) :
            this(texture, null)
        {
        }

        public SpriteSheet(IntRect[] frames) :
            this(null, frames)
        {
        }

        public SpriteSheet() :
            this(null, null)
        {
        }

        #endregion

        #region fields

        public Texture Texture;
        public IntRect[] Frames;

        #endregion
        #region methods

        public IntRect GetFrame(int[] index, float percent)
        {
            return SpriteSheet.GetFrame(Frames, index, percent);
        }

        public IntRect GetFrame(int[] index, float current, float maximum)
        {
            return (maximum == 0.00f)
                ? SpriteSheet.GetFrame(Frames, null, 0.00f)
                : SpriteSheet.GetFrame(Frames, null, current / maximum % 1);
        }

        public IntRect GetFrame(float percent)
        {
            return SpriteSheet.GetFrame(Frames, null, percent);
        }

        public IntRect GetFrame(float current, float maximum)
        {
            return (maximum == 0.00f)
                ? SpriteSheet.GetFrame(Frames, null, 0.00f)
                : SpriteSheet.GetFrame(Frames, null, current / maximum % 1);
        }

        #endregion
    }
}