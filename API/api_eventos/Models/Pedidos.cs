using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api_eventos.Models
{
    public class Pedidos
    {
        [Column("id_pedidos")]
        public int IdPedido { get; set; }

        [Column("usuario_idusuario")]
        public int IdUsuario { get; set; }

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("total")]
        public Double Total { get; set; }

        [Column("quantidade")]
        public int Quantidade { get; set; }

        [Column("forma_pagamento")]
        public string? FormaPagamento { get; set; }

         [Column("ativo")]
        public string? Status { get; set; }

        [Column("validacao_idusuario")]
        public  int? ValidacaoIdUsuario { get; set;}
    }
}