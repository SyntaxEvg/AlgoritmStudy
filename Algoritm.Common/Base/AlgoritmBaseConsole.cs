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
    }
}
