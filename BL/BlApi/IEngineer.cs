using BO;
namespace BlApi;

public interface IEngineer //statements for the crud functions
{
    public int Create(BO.Engineer eng);
    public void Delete(int id);
    public void Update(BO.Engineer eng);
    public BO.Engineer? Read(int id);
    public IEnumerable<BO.Engineer> ReadAll(Func<Engineer, bool>? filter = null);
}
