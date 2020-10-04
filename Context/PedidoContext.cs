using Microsoft.EntityFrameworkCore;
using Senai_Aula6.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Aula6.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<ProdutoItem> ProdutoItem { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=VINICIUS\SQLEXPRESS;Initial Catalog=loja;User ID=sa;Password=sa132");
            
        }
    }
}
