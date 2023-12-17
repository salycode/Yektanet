using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Yektanet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var MountainInput = Convert.ToInt32(Console.ReadLine());
            var MountainsHeights = Console.ReadLine().Split(" ").ToList().Select(X => Convert.ToInt32(X)).ToList();
            var QuestionsNum = Convert.ToInt32(Console.ReadLine());
            var Bunderies = new Boundery[QuestionsNum];
            for (long i = 0; i < QuestionsNum; i++)
            {
                var input = Console.ReadLine().Split(" ").ToList().Select(X => Convert.ToInt32(X)).ToList();
                Bunderies[i] = new Boundery();
                Bunderies[i].LeftIndex = input[0];
                Bunderies[i].RightIndex = input[1];
            }
            int[] TotalAnswers = new int[QuestionsNum];
            for (long bounderyIndex = 0; bounderyIndex < QuestionsNum; bounderyIndex++)
            {
                int Longest = 0;
                for (int i = Bunderies[bounderyIndex].LeftIndex - 1; i < Bunderies[bounderyIndex].RightIndex; i++)
                {
                    if (i == Bunderies[bounderyIndex].LeftIndex - 1 || i == Bunderies[bounderyIndex].RightIndex -1)
                    {
                        Longest++;
                        continue;
                    };
                    if (
                        (MountainsHeights[i] > MountainsHeights[i + 1] && MountainsHeights[i] > MountainsHeights[i - 1]) ||
                        (MountainsHeights[i] < MountainsHeights[i + 1] && MountainsHeights[i] < MountainsHeights[i - 1])
                        ) Longest++;
                }
                TotalAnswers[bounderyIndex] = Longest;
            }
            foreach (var item in TotalAnswers)
            {
                Console.WriteLine(item);
            }

        }

    }
    public class Boundery
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }
    }

}