using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm.Common
{
    public class AlgoritmBaseConsole : IConsole_ReadLine
    {
        public virtual string ConsoleReadLine()
        {
           return Console.ReadLine();
        }

        public virtual int TryParseCR()
        {
            var temp = String.Intern(Console.ReadLine());
            int count = 0;
            int.TryParse(temp, out count);
            if (count != 0)
            {
                return count;
            }
            return 0;
        }
    }
}
