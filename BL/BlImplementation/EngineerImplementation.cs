using BlApi;
using BO;
using System.Collections.Generic;


namespace BlImplementation;


internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = Factory.Get;
    public TaskInEngineer checkIsExist(DO.Engineer eng)
    {
        var x = _dal.Task.ReadAll().FirstOrDefault(task => task?.engineerId == eng.engineerId);
        if (x == null)
            return null;
        else
        {
            return new TaskInEngineer()
            {
                id = x.taskId,
                alias = _dal.Task.ReadAll().FirstOrDefault(task=>task?.engineerId == eng.engineerId)!.alias
            };
        }
    }
        public int Create(BO.Engineer eng)//A function that create a new Engineer.
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

    public void Delete(int id)//A function that delete an exist Engineer.
    {
        throw new NotImplementedException();
    }

    public BO.Engineer? Read(int id)//A function that  display an exist Engineer with an id
    {
        DO.Engineer? doEngineer= _dal.Engineer.Read(id);
        if (doEngineer==null)
        {
            throw new BO.BlDoesNotExistException($"Student with ID={id} does Not exist");
        }
        return new BO.Engineer()
        {
            engineerId = doEngineer.engineerId,
            name = doEngineer.engineerName,
            email = doEngineer.engineerEmail,
            costPerHour = doEngineer.costPerHour,
            exp = (EngineerExperience)doEngineer.exp,
            task = checkIsExist(doEngineer)
        };
    }

    public IEnumerable<BO.Engineer> ReadAll(Func<Engineer, bool>? filter = null)//display all the list of engineers
    {
        
        IEnumerable<BO.Engineer>engineers= (from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                select new BO.Engineer
                {
                    engineerId = doEngineer.engineerId,
                    name = doEngineer.engineerName,
                    email = doEngineer.engineerEmail,
                    costPerHour = doEngineer.costPerHour,
                    exp = (EngineerExperience)doEngineer.exp,
                    task=checkIsExist(doEngineer)
                });
        if(filter == null)
          return engineers;
        else
            return engineers.Where(filter!);
}
  
    public void Update(Engineer eng) //A function that update an exist Engineer with an id
    {
        DO.Engineer doEngineer = new DO.Engineer(eng.engineerId, eng.name, eng.email, eng.costPerHour, (DO.EngineerExperience)eng.exp);
        try
        {
            _dal.Engineer.Update(doEngineer);
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            //throw bl exception
            throw new Exception();
        }
    }
}
