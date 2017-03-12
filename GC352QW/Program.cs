using System;

namespace GC352QW
{
    public class Program
    {        
        static int k1 = 2;
        static int k2 = 2;

        static string t0 = "";
        static string t1 = "057";
        static string t2 = "47";
        static string t3 = "326";

        static string[] moves = new[] { "000", "104", "101", "013", "102", "114", "102", "101", "010",
                                        "011", "102", "111", "102", "101", "102", "101", "100", "104",
                                        "103", "102", "101", "103", "102", "101", "013", "101", "100", "100" };

        private static void SwitchK1(char v)
        {
            if (v == '1') k1 = k1 == 2 ?  3 : 2;
        }

        private static void SwitchK2(char v)
        {
            if (v == '1') k2 = k2 == 2 ? 1 : 2;
        }

        private static void MoveDisconnect(string move, ref string t)
        {
            var s = t0 + t;
            var l = Int32.Parse(move[2].ToString());

            if (l == 0)
            {
                t0 = s;
                t = "";
            }
            else
            {
                t0 = s.Substring(0, l - 1);
                t = s.Substring(l - 1);
            }
        }

        public static void Main(string[] args)
        {
            int i = 1;

            foreach (var move in moves)
            {
                Console.Write($"{i++, 2}: {move} - > ");

                SwitchK1(move[0]);
                SwitchK2(move[1]);

                Console.Write($"k1 = {k1} | k2 = {k2}");

                if (k1 == 3)
                {
                    MoveDisconnect(move, ref t3);
                }
                else
                if (k2 == 2)
                {
                    MoveDisconnect(move, ref t2);
                }
                else
                {
                    MoveDisconnect(move, ref t1);
                }

                Console.WriteLine($" | t0:  {t0, 6} | t1: {t1, 6} | t2: {t2, 6}  | t3: {t3, 6}");
                //Console.ReadKey();
            }

            Console.WriteLine("\nDone! Press any key...");
            Console.ReadKey();
        }
    }
}