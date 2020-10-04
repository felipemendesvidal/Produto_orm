using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Senai_Aula6.Domains
{
    public class Produto : BaseDomain
    {
     
        public string Nome { get; set; }
        public float Preco { get; set; }

        [NotMapped] //Não mapeia a propiedade no banco de dados 
        [JsonIgnore] //Ignora propiedade no retorno no Json
        public  IFormFile Imagem { get; set; }

        public string UrlImagem { get; set; }
        public List<ProdutoItem> ProdutoItens { get; set; }
    }
}
