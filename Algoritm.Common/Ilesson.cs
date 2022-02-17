using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm
{
    public interface Ilesson
    {
        public int id { get; }
        public string Descprition { get; }

        public void RUN();
    }
}
