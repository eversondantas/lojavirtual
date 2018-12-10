using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaVirtualMVC.Models
{
    public class ProdutoModel
    {
        public int ProdutoID { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}