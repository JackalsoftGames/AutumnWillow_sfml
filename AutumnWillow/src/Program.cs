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
    public class Node : ITreeNode<Node>
    {
        public Node(int id)
        {
            ID = id;
            Children = new List<Node>();
        }

        public int ID;

        public Node Parent { get; set; }
        public ICollection<Node> Children { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            Node[] nodes = new Node[12];
            {
                for (int i = 0; i < nodes.Length; i++)
                    nodes[i] = new Node(i);

                Random r = new Random(10);
                for (int j = 0; j < 4; j++)
                    for (int i = 0; i < nodes.Length; i++)
                    {
                        if (r.Next(0, 2) > 0)
                            continue;

                        int n = r.Next(0, nodes.Length);
                        nodes[i].Add(nodes[n]);
                    }
            }

            List<string> text = new List<string>();

            foreach (var ITEM in nodes)
            {
                if (ITEM.Parent != null)
                    text.Add(String.Format("{0} {1}", ITEM.ID, ITEM.Parent.ID));
                else
                    text.Add(String.Format("{0} ", ITEM.ID));

                if (ITEM.Parent != null)
                    Console.WriteLine("{0} :: ({1})", ITEM.ID, ITEM.Parent.ID);
                else
                    Console.WriteLine("{0}", ITEM.ID);
            }

            System.IO.File.WriteAllLines("c:/env/text.txt", text.ToArray());

            var game = new Game();
            game.Main();
        }

        #region benchmark

        public static long Benchmark(int c, int n, Action action)
        {
            if (action == null || c == 0 || n == 0)
                return 0;

            long result = 0;

            var w = new System.Diagnostics.Stopwatch();
            for (int i = 0; i <= c; i++)
            {
                w.Restart();
                for (int j = 0; j < n; j++)
                {
                    action();
                }
                w.Stop();

                if (i > 0)
                    result += w.ElapsedTicks;
            }

            return result / c;
        }

        #endregion
    }
}