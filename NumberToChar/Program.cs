﻿using System.Linq;

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


        static string ToChar(int number)
        {
            string numberStr = number.Reverse();
            string numberChar = string.Empty;

            if (numberStr.Length == 1)
            {
                return FrenchNumbers.UnityToChar(number);
            }

            for (int i = 0; i < numberStr.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    int unity = numberStr.ElementAt(i - 1).ToInt();
                    int ten = numberStr.ElementAt(i).ToInt();
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
                        numberChar = $"{FrenchNumbers.UnityToChar(hundred)}-cent" + (string.IsNullOrEmpty(numberChar) ? numberChar : $"-{numberChar}");
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
                    return $"{FrenchNumbers.TenToChar(ten)} et {ZeroToTwentyToChar(ten, unity)}";
                }
                if (unity > 7)
                {
                    return $"{FrenchNumbers.TenToChar(ten)}-{ZeroToTwentyToChar(ten, unity)}";
                }
                return $"{FrenchNumbers.TenToChar(ten)} et un";
            }

            if (unity == 0)
            {
                return FrenchNumbers.TenToChar(ten);
            }

            if (ten > 6)
            {
                return $"{FrenchNumbers.TenToChar(ten - (ten % 2 == 0 ? 0 : 1))}-{ZeroToTwentyToChar(ten % 2 == 0 ? 0 : 1, unity)}";
            }
            return $"{FrenchNumbers.TenToChar(ten)}-{FrenchNumbers.UnityToChar(unity)}";
        }

        static string ZeroToTwentyToChar(int ten, int unity)
        {
            if (ten == 0)
            {
                return FrenchNumbers.UnityToChar(unity);
            }

            if (ten == 1)
            {
                if (unity > 6)
                {
                    return $"dix-{FrenchNumbers.UnityToChar(unity)}";
                }
                return FrenchNumbers.TenToFifteenToChar(unity);
            }
            return null;
        }
    }
}
