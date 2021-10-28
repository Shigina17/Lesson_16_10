using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_16_10
{
    class Convert
    {
        public byte CheckTheByteNumber()
        {
            string strUserNumber = Console.ReadLine();
            byte userNumber = 0;
            while(!byte.TryParse(strUserNumber, out userNumber))
            {
                Console.WriteLine("Введите число, а не строку!");
                strUserNumber = Console.ReadLine();
            }
            return userNumber;
        }
        public int CheckTheIntNumber()
        {
            string strUserNumber = Console.ReadLine();
            int userNumber = 0;
            while(!int.TryParse(strUserNumber, out userNumber))
            {
                Console.WriteLine("Введите число, а не строку!");
                strUserNumber = Console.ReadLine();
            }
            return userNumber;
        }
    }
}
