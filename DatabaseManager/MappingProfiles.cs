using AutoMapper;
using DatabaseManager.Models;
using System.Collections.Generic;

namespace DatabaseManager
{
    public class CandleStickMappingProfile : Profile
    {
        public CandleStickMappingProfile()
        {
            CreateMap<Dictionary<string, string>, Candlestick>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OpenTime, opt => opt.MapFrom(src => src["OpenTime"]))
                .ForMember(dest => dest.Open, opt => opt.MapFrom(src => src["Open"]))
                .ForMember(dest => dest.High, opt => opt.MapFrom(src => src["High"]))
                .ForMember(dest => dest.Low, opt => opt.MapFrom(src => src["Low"]))
                .ForMember(dest => dest.Close, opt => opt.MapFrom(src => src["Close"]))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src["Volume"]))
                .ForMember(dest => dest.CloseTime, opt => opt.MapFrom(src => src["CloseTime"]))
                .ForMember(dest => dest.QuoteVolume, opt => opt.MapFrom(src => src["QuoteVolume"]))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src["Count"]))
                .ForMember(dest => dest.TakerBuyVolume, opt => opt.MapFrom(src => src["TakerBuyVolume"]))
                .ForMember(dest => dest.TakerBuyQuoteVolume, opt => opt.MapFrom(src => src["TakerBuyQuoteVolume"]))
                .ForMember(dest => dest.Ignore, opt => opt.MapFrom(src => src["Ignore"]));
        }
    }
}
