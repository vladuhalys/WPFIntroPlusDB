using Core.Abstractions;
using DatabaseService.Abstractions;

namespace Core.Entity;

public class Student : IEntity, IModelToEntity
{
    public IEntity ToEntity(IModel model)
    {
        throw new NotImplementedException();
    }
}