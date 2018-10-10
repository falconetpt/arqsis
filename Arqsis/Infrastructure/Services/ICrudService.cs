using System;
using System.Collections.Generic;
using Arqsis.Infrastructure.DAL.DTO.finish;
using Arqsis.Infrastructure.Results;

namespace Arqsis.Infrastructure.Services
{
    public interface ICrudService<TEntity, TReadObject, TWriteObject>
    {
        IEnumerable<TReadObject> FindAll();
        ResultWrapper<TReadObject> AddElement(TWriteObject finishWriteDto);
        ResultWrapper<TReadObject> FindOne(Guid id);
        TEntity GetOriginalEntity(Guid id);
        ResultWrapper<TReadObject> UpdateElement(Guid id, TWriteObject finishWriteDto);
        ResultWrapper<TReadObject> DeleteById(Guid id);

    }

    
}