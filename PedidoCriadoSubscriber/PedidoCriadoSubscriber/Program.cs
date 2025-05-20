using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoCriadoSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            var subscriber = new PedidoCriadoSubscriber();
            subscriber.Iniciar();
        }
    }

}
