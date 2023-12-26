

namespace BlImplementation;
using BlApi;
using BO;
using System.Collections.Generic;

internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = Factory.Get;
    public int Create(BO.Engineer eng)
    {
        DO.Engineer doEngineer= new DO.Engineer(eng.engineerId,eng.name,eng.email,eng.costPerHour,(DO.EngineerExperience)eng.exp);
        try
        {
            int idEng = _dal.Engineer.Create(doEngineer);
            return idEng;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            //throw bl exception
            throw new Exception();
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Engineer? Read(int id)
    {
        DO.Engineer? doEngineer= _dal.Engineer.Read(id);
        if (doEngineer==null)
        {
            //throw bl exception
            throw new Exception();
        }
        return new BO.Engineer()
        {
            engineerId = doEngineer.engineerId,
            name = doEngineer.engineerName,
            email = doEngineer.engineerEmail,
            costPerHour = doEngineer.costPerHour,
            exp = (EngineerExperience)doEngineer.exp
        };
    }

    public IEnumerable<BO.Engineer> ReadAll()
    {
        
    }

    public void Update(Engineer eng)
    {
        throw new NotImplementedException();
    }
}
