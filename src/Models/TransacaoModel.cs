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

        public DateTime Data { get; set; }

        public IEnumerable<SelectListItem>? PlanoContaList { get; set; }
    }
}