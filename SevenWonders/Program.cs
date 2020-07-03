using System;

namespace SevenWonders
{
    class Program
    {
        static void Main(string[] args)
        {
            // Seven Wonders 
            // https://open.kattis.com/problems/sevenwonders 
            // simple numerical program

            var mySeq = EnterCards();

            var myCards = CalculationEachCards(mySeq);
            
            var myPoints = GetPoints(myCards);
            Console.WriteLine(myPoints);
        }
        private static int GetPoints(int[] points)
        {
            int myMin = Math.Min(Math.Min(points[0], points[1]), points[2]);
            int mySq = points[0] * points[0] + points[1] * points[1] + points[2] * points[2];
            return mySq + myMin * 7;
        }
        private static int[] CalculationEachCards(string points)
        {
            int tablet = 0;
            int gear = 0;
            int compass = 0;

            char pivot;
            for (int p = 0; p < points.Length; p++)
            {
                pivot = points[p];

                if (pivot == 'T')
                    tablet = tablet + 1;
                else if (pivot == 'G')
                    gear = gear + 1;
                else
                    compass = compass + 1;
            }
            return MakeArray3(tablet, compass, gear);
        }
        private static int[] MakeArray3(int num1, int num2, int num3)
        {
            int[] res = new int[3] { 0, 0, 0 };
            res[0] = num1;
            res[1] = num2;
            res[2] = num3;
            return res;
        }
        private static string EnterCards()
        {
            string str = "";
            try
            {
                str = Console.ReadLine();
                if (StringConditions(str) == false)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterCards();
            }
            return str;
        }
        private static bool StringConditions(string str)
        {
            if (str.Length < 1 || str.Length > 50)
                return false;
            else
            {
                char pivot;
                for (int k = 0; k < str.Length; k++)
                {
                    pivot = str[k];

                    if (pivot != 'T' && pivot != 'C' && pivot != 'G')
                        return false;
                }
                return true;
            }
        }
    }
}
