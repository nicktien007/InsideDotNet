using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nick.Test.String
{
    /// <summary>
    /// 對應p343 練習
    /// </summary>
    class Program
    {
        public const string s1 = "abc";

        static void Main(string[] args)
        {
            //string s1 = "abc";
            //string s2 = "ab";

            //s2 += "c";
            //string s3 = "ab";

            //Console.WriteLine(string.IsInterned(s1) ?? "null");
            //Console.WriteLine(string.IsInterned(s2) ?? "null");
            //Console.WriteLine(string.IsInterned(s3) ?? "null");

            //===============分隔線========================//

            //string s1 = "abc";
            //string s2 = "ab";
            //string s3 = s2 + "c";

            //Console.WriteLine(string.IsInterned(s3) ?? "null");

            //===============分隔線========================//

            //string s2 = "ab";

            //s2 += "c";

            //Console.WriteLine(string.IsInterned(s2) ?? "null");
            //string s1 = "abc";

            //===============分隔線========================//
            //string s2 = "ab";
            //s2 += "c";

            //Console.WriteLine(string.IsInterned(s2) ?? "null");
            //string s1 = GetStr();
            //===============分隔線========================//

            string s2 = "ab";
            s2 += "c";
            Console.WriteLine(string.IsInterned(s1) ?? "null");
            Console.WriteLine(string.IsInterned(s2) ?? "null");
            
        }

        //private static string GetStr()
        //{
        //    return "abc";
        //}
    }
}
