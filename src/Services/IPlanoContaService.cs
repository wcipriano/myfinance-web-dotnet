using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface IPlanoContaService
    {
        IEnumerable<PlanoContaModel> Listar();
        PlanoContaModel RetornarRegistro(int id);
        void Salvar(PlanoContaModel model);
        void Excluir(int id);
    }
}