using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Models
{
    public class PlanoContaModel
    {
        public int? Id { get; set; }

        public required string Descricao { get; set; }

        [Required]
        public required string Tipo { get; set; }
    }
}