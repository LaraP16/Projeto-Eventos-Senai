using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_eventos.Models
{
    public class Ingresso
    {
        [Column("idingresso")]
        public int idIngresso { get; set; }
 
        [Column("codigo_qr")]
        public string? CodigoQr { get; set; }
 
         [Column("valor")]
        public double? Valor { get; set; }
 
         [Column("status")]
        public string? Status { get; set; }
 
         [Column("tipo")]
        public string? Tipo { get; set; }
 
        [Column("data_utilizacao")]
        public DateTime DataUtilizacao { get; set; }
 
        [Column("pedido_idpedido")]
        public int? IdPedido { get; set; }

        [Column("pedido_usuario_idusuario")]
        public int? IdUsuario { get; set; }

        [Column("lote_idlote")]
        public int? IdLote { get; set; }

        [Column("evento_idevento")]
        public int? IdEvento { get; set; }
    }
}