using AutoMapper;
using Xayah.Application.ViewModels.Response;
using Xayah.Domain.Entities;

namespace Xayah.Application.AutoMapper
{
    public class DomainToViewModel : Profile
    {
        public DomainToViewModel()
        {
            CreateMap<Transaction, TransactionViewModelResponse>()
                .ForMember(dest => dest.Id, member => member.MapFrom(src=> src.Id))
                .ForMember(dest => dest.BankId, member => member.MapFrom(src=> src.BankId))
                .ForMember(dest => dest.AccountId, member => member.MapFrom(src=> src.AccountId))
                .ForMember(dest => dest.Ammount, member => member.MapFrom(src=> src.TransactionAmmount))
                .ForMember(dest => dest.Currency, member => member.MapFrom(src=> src.TransactionCurrency))
                .ForMember(dest => dest.Description, member => member.MapFrom(src=> src.TransactionDescription))
                .ForMember(dest => dest.Type, member => member.MapFrom(src=> src.TransactionType))
                .ForMember(dest => dest.DateTime, member => member.MapFrom(src=> src.TranscationDateTime));
        }
    }
}
