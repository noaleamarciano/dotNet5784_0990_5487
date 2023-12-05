

using DalApi;
using DO;

namespace Dal;

internal class DependenceImplementation : IDependence
{
    public int Create(Dependence item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(Func<Dependence, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Dependence item)
    {
        throw new NotImplementedException();
    }
}
