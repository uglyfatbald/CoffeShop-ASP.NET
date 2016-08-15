using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace es.bimaxpro.coffeshop.api.models
{
    public partial class PedidoEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string bebida { get; set; }
    }
}
