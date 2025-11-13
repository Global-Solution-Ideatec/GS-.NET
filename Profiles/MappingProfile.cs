using AutoMapper;
using IdeaTecAPI.DTOs;
using IdeaTecAPI.Models;

namespace IdeaTecAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioCreateDTO, Usuario>();

            // Tarefa
            CreateMap<Tarefa, DTOs.TarefaDTO>().ReverseMap();
            CreateMap<DTOs.TarefaCreateDTO, Tarefa>();

            // Checkin
            CreateMap<CheckinBemEstar, DTOs.CheckinDTO>().ReverseMap();
            CreateMap<DTOs.CheckinCreateDTO, CheckinBemEstar>();

            // Recomendacao
            CreateMap<RecomendacaoIA, DTOs.RecomendacaoDTO>().ReverseMap();
            CreateMap<DTOs.RecomendacaoCreateDTO, RecomendacaoIA>();

            // Habilidade
            CreateMap<Habilidade, DTOs.HabilidadeDTO>().ReverseMap();
            CreateMap<DTOs.HabilidadeCreateDTO, Habilidade>();
        }
    }
}
