using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    public class ExitClass : Ilesson
    {
        public int id => 9;

        public string Descprition => "Exit";

        public void RUN()
        {
            Environment.Exit(0);
        }
    }
}
