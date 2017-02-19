using System;
using System.Linq;

namespace NumberToChar
{
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Saisisez le nombre entre 0 et 999 à convertir en lettre svp ce serai gentil");
            string saisie = Console.ReadLine();

            int convert;
            if (int.TryParse(saisie, out convert))
            {
                string enLettre = ToChar(convert);
                Console.WriteLine("Nombre en lettre : " + enLettre);
            }
            else
            {
                Console.WriteLine("Vous n'avez pas rentrer un nombre et vous le devriez");
            }

            Main(null);
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
