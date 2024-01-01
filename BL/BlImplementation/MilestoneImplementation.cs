using BlApi;
using BO;

namespace BlImplementation;

internal class MilestoneImplementation : IMilestone
{
    private DalApi.IDal _dal = Factory.Get;
    public int Create(Milestone mil)
    {

        throw new NotImplementedException();
    }

    public Milestone? Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Milestone mil)
    {
        throw new NotImplementedException();
    }
}
