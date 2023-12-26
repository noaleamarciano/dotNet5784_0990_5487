
namespace BlImplementation;
using BlApi;
using BO;
using System.Collections.Generic;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = Factory.Get;
    public int Create(Task task)
    {
        throw new NotImplementedException(); 
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task? Read(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Task> ReadAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Task task)
    {
        throw new NotImplementedException();
    }
}
