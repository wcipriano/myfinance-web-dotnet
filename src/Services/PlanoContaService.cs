using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;

        public PlanoContaService(MyFinanceDbContext myFinanceDbContext,
                                 IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public IEnumerable<PlanoContaModel> Listar()
        {
            var list = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(list);
            return lista;
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(item => item.Id == id).First();
            return _mapper.Map<PlanoContaModel>(item);
        }

        void IPlanoContaService.Salvar(PlanoContaModel model)
        {
            var item = _mapper.Map<PlanoConta>(model);
            if (item.Id == null)
            {
                _myFinanceDbContext.PlanoConta.Add(item);
            }
            else
            {
                _myFinanceDbContext.PlanoConta.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }

        void IPlanoContaService.Excluir(int id)
        {
            var item = _myFinanceDbContext.PlanoConta.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}