using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_eventos.Models
{
    public class Lote
    {
         [Column("idlote")]
        public int idlote { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

         [Column("valor_unitario")]
        public double? ValorUnitario { get; set; }

         [Column("quantidade_total")]
        public int? QuantidadeTotal { get; set; }

         [Column("saldo")]
        public int? Saldo { get; set; }

        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("evento_idevento")]
        public int? IdEvento { get; set; }

       

        

         
    }
}