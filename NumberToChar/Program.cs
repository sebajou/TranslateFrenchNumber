using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChar
{
    class Program
    {
        static void Main(string[] args)
        {
            string test1 = ToChar(110);
            string test2 = ToChar(0);
            string test3 = ToChar(1);
            string test4 = ToChar(10);
            string test5 = ToChar(9);
            string test6 = ToChar(100);
            string test7 = ToChar(101);
            string test8 = ToChar(999);
            string test9 = ToChar(342);
            string test10 = ToChar(700);
            string test11 = ToChar(90);
            string test12 = ToChar(340);
            string test13 = ToChar(931);
        }

        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }



        static string ToChar(int number)
        { 
            string numberStr = Reverse(number.ToString());
            string numberChar = string.Empty;

            if (numberStr.Length == 1)
            {
                return UnityToChar(number);
            }

            for (int i = 0; i < numberStr.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    int unity = int.Parse(new string(new[] { numberStr.ElementAt(i - 1) }));
                    int ten = int.Parse(new string(new[] { numberStr.ElementAt(i) }));
                    numberChar = TenUnityToChar(ten, unity) + numberChar;
                }

                if ((i + 1) % 3 == 0)
                {
                    int hundred = int.Parse(new string(new[] { numberStr.ElementAt(i) }));

                    if (hundred == 1)
                    {
                        numberChar = "cent" + (string.IsNullOrEmpty(numberChar) ? numberChar : $" {numberChar}");
                    }
                    else
                    {
                        numberChar = $"{UnityToChar(hundred)}-cent" + (string.IsNullOrEmpty(numberChar) ? numberChar : $"-{numberChar}");
                    }
                }
            }

            return numberChar;
        }
        
        static string TenUnityToChar(int ten, int unity)
        {
            if (unity == 0 && ten == 0)
            {
                return string.Empty;
            }

            string result = ZeroToTwentyToChar(ten, unity);

            if (!string.IsNullOrEmpty(result))
            {
                return result;
            }

            if (unity == 1)
            {
                if (unity == 7)
                {
                    return $"{TenToChar(ten)} et {ZeroToTwentyToChar(ten, unity)}";
                }
                if (unity > 7)
                {
                    return $"{TenToChar(ten)}-{ZeroToTwentyToChar(ten, unity)}";
                }
                return $"{TenToChar(ten)} et un";
            }

            if (unity == 0)
            {
                return TenToChar(ten);
            }

            if (ten > 6)
            {
                return $"{TenToChar(ten - (ten % 2 == 0 ? 0 : 1))}-{ZeroToTwentyToChar(ten % 2 == 0 ? 0 : 1, unity)}";
            }
            return $"{TenToChar(ten)}-{UnityToChar(unity)}";
        }

        static string ZeroToTwentyToChar(int ten, int unity)
        {
            if (ten == 0)
            {
                return UnityToChar(unity);
            }

            if (ten == 1)
            {
                if (unity > 6)
                {
                    return $"dix-{UnityToChar(unity)}";
                }
                return TenToFifteenToChar(unity);
            }
            return null;
        }

        static string TenToFifteenToChar(int unity)
        {
            switch (unity)
            {
                case 0:
                    return "dix";
                case 1:
                    return "onze";
                case 2:
                    return "douze";
                case 3:
                    return "treize";
                case 4:
                    return "quatorze";
                case 5:
                    return "quinze";
                case 6:
                    return "seize";
                default:
                    return "ERROR";
            }
        }

        static string TenToChar(int ten)
        {
            switch (ten)
            {
                case 0:
                    return "zero";
                case 1:
                    return "dix";
                case 2:
                    return "vingt";
                case 3:
                    return "trente";
                case 4:
                    return "quarante";
                case 5:
                    return "cinquante";
                case 6:
                    return "soixante";
                case 7:
                    return "soixante-dix";
                case 8:
                    return "quatre-vingt";
                case 9:
                    return "quatre-vingt-dix";
                default:
                    return "ERROR";
            }
        }

        static string UnityToChar(int unity)
        {
            switch (unity)
            {
                case 0:
                    return "zero";
                case 1:
                    return "un";
                case 2:
                    return "deux";
                case 3:
                    return "trois";
                case 4:
                    return "quatre";
                case 5:
                    return "cinq";
                case 6:
                    return "six";
                case 7:
                    return "sept";
                case 8:
                    return "huit";
                case 9:
                    return "neuf";
                default:
                    return "ERROR";
            }
        }

    }
}
