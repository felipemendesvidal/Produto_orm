using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Domains
{
    public class Pedido : BaseDomain
    {
        
       
        public string Status { get; set; }
        public DateTime OrderData { get; set; }
        public List<ProdutoItem> ProdutoItens { get; set; }
    }
}
