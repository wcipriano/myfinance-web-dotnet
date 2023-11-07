using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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

        public IEnumerable<PlanoContaModel> ListarPlanoContas()
        {
            var list = _myFinanceDbContext.PlanoConta.ToList();
            var lista = _mapper.Map<IEnumerable<PlanoContaModel>>(list);
            return lista;
        }
    }
}