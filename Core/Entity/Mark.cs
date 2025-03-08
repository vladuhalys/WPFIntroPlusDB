using Core.Abstractions;
using DatabaseService.Abstractions;

namespace Core.Entity;

public class Mark : IEntity, IModelToEntity
{
    public IEntity ToEntity(IModel model)
    {
        throw new NotImplementedException();
    }
}