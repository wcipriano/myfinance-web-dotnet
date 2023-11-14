using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Models
{
    public class FormaPagamentoModel
    {
        public FormaPagamentoModel(string id, string desc)
        {
            Id = id;
            Descricao = desc;
        }
        public string Id { get; set; }

        public string Descricao { get; set; }
    }
}