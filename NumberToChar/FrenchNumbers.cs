using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChar
{
    static class FrenchNumbers
    {
        public const string ZERO = "zero";
        public const string VINGT = "vingt";
        public const string TRENTE = "trente";
        public const string QUARANTE = "quarante";
        public const string CINQUANTE = "cinquante";
        public const string SOIXANTE = "soixante";
        public const string SOIXANTE_DIX = "soixante-dix";
        public const string QUATRE_VINGT = "quatre-vingt";
        public const string QUATRE_VINGT_DIX = "quatre-vingt-dix";
        public const string DIX = "dix";
        public const string ONZE = "onze";
        public const string DOUZE = "douze";
        public const string TREIZE = "treize";
        public const string QUATORZE = "quatorze";
        public const string QUINZE = "quinze";
        public const string SEIZE = "seize";
        public const string UN = "un";
        public const string DEUX = "deux";
        public const string TROIS = "trois";
        public const string QUATRE = "quatre";
        public const string CINQ = "cinq";
        public const string SIX = "six";
        public const string SEPT = "sept";
        public const string HUIT = "huit";
        public const string NEUF = "neuf";


        public static string TenToFifteenToChar(int unity)
        {
            switch (unity)
            {
                case 0:
                    return DIX;
                case 1:
                    return ONZE;
                case 2:
                    return DOUZE;
                case 3:
                    return TREIZE;
                case 4:
                    return QUATORZE;
                case 5:
                    return QUINZE;
                case 6:
                    return SEIZE;
                default:
                    return "ERROR";
            }
        }

        public static string TenToChar(int ten)
        {
            switch (ten)
            {
                case 0:
                    return ZERO;
                case 1:
                    return DIX;
                case 2:
                    return VINGT;
                case 3:
                    return TRENTE;
                case 4:
                    return QUARANTE;
                case 5:
                    return CINQUANTE;
                case 6:
                    return SOIXANTE;
                case 7:
                    return SOIXANTE_DIX;
                case 8:
                    return QUATRE_VINGT;
                case 9:
                    return QUATRE_VINGT_DIX;
                default:
                    return "ERROR";
            }
        }

        public static string UnityToChar(int unity)
        {
            switch (unity)
            {
                case 0:
                    return ZERO;
                case 1:
                    return UN;
                case 2:
                    return DEUX;
                case 3:
                    return TROIS;
                case 4:
                    return QUATRE;
                case 5:
                    return CINQ;
                case 6:
                    return SIX;
                case 7:
                    return SEPT;
                case 8:
                    return HUIT;
                case 9:
                    return NEUF;
                default:
                    return "ERROR";
            }
        }

    }
}
