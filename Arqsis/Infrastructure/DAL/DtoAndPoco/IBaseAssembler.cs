namespace Arqsis.Infrastructure.DAL.DTO
{
    public interface IBaseAssembler<TReadDto, TWriteDto, TObject>
    {
        TReadDto ToDto(TObject baseObject);
        TObject ToDomainObject(TWriteDto dto);
    }
}