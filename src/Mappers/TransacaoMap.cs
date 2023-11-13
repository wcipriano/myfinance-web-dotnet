using AutoMapper;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Mappers
{
    public class TransacaoMap : Profile
    {
        public TransacaoMap()
        {
            CreateMap<Transacao, TransacaoModel>().ReverseMap();
        }
    }
}