using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace api.Models
{
    public class Evento
    {
        [Column("idevento")]
        public int IdEvento { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("total_ingresso")]
        public decimal TotalIngresso { get; set; }

        [Column("data_evento")]
        public DateTime DataEvento { get; set; }

        // Propriedades e navegações adicionais conforme necessário
    }
}
