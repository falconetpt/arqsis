using System;
using System.Collections.Generic;

namespace Arqsis.Infrastructure.Repositories
{
    public interface IBaseRepository<TEntity, TRead, TWrite>
    {
        IEnumerable<TRead> GetAll();
        TEntity Add(TWrite writeDto);
        TRead GetById(Guid id);
        TEntity GetEntityById(Guid id);
        TRead UpdateElement(Guid id, TWrite writeDto);
        TRead DeleteById(Guid id);
    }
}