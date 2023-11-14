using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace myfinance_web_netcore.Models
{
    public class TransacaoModel
    {
        public int? Id { get; set; }

        public string? Descricao { get; set; }

        [Required]
        public double Valor { get; set; }

        public int PlanocontaId { get; set; }
        public string? PlanocontaTipo { get; set; }

        public IEnumerable<PlanoContaModel>? PlanocontaList { get; set; }

        public DateTime Data { get; set; }

        public IEnumerable<SelectListItem>? PlanoContaSelectList { get; set; }

        public string? FormaPagamentoId { get; set; }
        public IEnumerable<SelectListItem>? FormaPagamentoSelectList { get; set; }
    }
}