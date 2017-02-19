using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChar
{
    public static class CharExtensions
    {
        public static int ToInt(this char character)
        {
            try
            {

                return int.Parse(new string(new[] { character }));
            }
            catch (InvalidCastException castException)
            {
                Console.WriteLine(castException.Message);
                throw new Exception("La conversion n'est pas valide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
