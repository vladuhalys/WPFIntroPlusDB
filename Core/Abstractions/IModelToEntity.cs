using Core.Entity;
using DatabaseService.Abstractions;

namespace Core.Abstractions;

public interface IModelToEntity
{
    public IEntity ToEntity(IModel model);
}