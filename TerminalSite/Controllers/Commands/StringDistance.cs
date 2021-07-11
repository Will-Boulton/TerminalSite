using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalSite.Controllers
{
    public static class StringDistanceUtils
    {
        /// <summary>
        /// Find the closest string to <paramref name="target"/> from <paramref name="options"/>
        /// </summary>
        /// <param name="target">String which we want to find the closest match for</param>
        /// <param name="options">List of options int which the closest match will be searched for</param>
        /// <returns>Closest match to target from the input list</returns>
        public static string ClosestMatch(string target, IEnumerable<string> options)
        {
            Dictionary<int,string> distances = new Dictionary<int, string>();

            int longestPrefix = 0;

            foreach (var item in options)
            {
                int prefixLen = CommonPrefixLength(item, target);
                distances[prefixLen] = item ;

                longestPrefix = Math.Max(longestPrefix, prefixLen);
            }
            
            if(longestPrefix > 0)
                return distances[longestPrefix];

            return target;
        }


        public static int CommonPrefixLength(string source, string target)
        {
            int i = 0;
            while(i < source.Length && i < target.Length && source[i] == target[i]) i++;
            return i;
        }
    }
}
