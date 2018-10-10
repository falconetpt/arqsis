using Arqsis.Model.Finish;

namespace Arqsis.Infrastructure.DAL.DTO.finish
{
    public class FinishAssembler : IBaseAssembler<FinishReadDto, FinishWriteDto, Finish>
    {
        public FinishReadDto ToDto(Finish finish)
        {
            FinishReadDto finishReadDto = new FinishReadDto();
            finishReadDto.Name = finish.Name;
            finishReadDto.Id = finish.FinishId;
            
            return finishReadDto;
        }

        public Finish ToDomainObject(FinishWriteDto dto)
        {
            Finish finish = FinishFactory.Create(dto.Name);
            return finish;
        }
    }
}