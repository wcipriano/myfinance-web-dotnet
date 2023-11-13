using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;

        public TransacaoService(MyFinanceDbContext myFinanceDbContext,
                                 IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public IEnumerable<TransacaoModel> Listar()
        {
            var list = _myFinanceDbContext.Transacao.Join(_myFinanceDbContext.PlanoConta,
                        t => t.PlanocontaId, pc => pc.Id,
                        (t, pc) => new TransacaoModel()
                        {
                            Id = t.Id,
                            Descricao = t.Descricao,
                            Valor = t.Valor,
                            Data = t.Data,
                            PlanocontaId = t.PlanocontaId,
                            PlanocontaTipo = pc.Tipo
                        }).ToList();
            return list;
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(item => item.Id == id).First();
            return _mapper.Map<TransacaoModel>(item);
        }

        void ITransacaoService.Salvar(TransacaoModel model)
        {
            var item = _mapper.Map<Transacao>(model);
            if (item.Id == null)
            {
                _myFinanceDbContext.Transacao.Add(item);
            }
            else
            {
                _myFinanceDbContext.Transacao.Attach(item);
                _myFinanceDbContext.Entry(item).State = EntityState.Modified;
            }
            _myFinanceDbContext.SaveChanges();
        }

        void ITransacaoService.Excluir(int id)
        {
            var item = _myFinanceDbContext.Transacao.Where(item => item.Id == id).First();
            _myFinanceDbContext.Remove(item);
            _myFinanceDbContext.SaveChanges();
        }
    }
}