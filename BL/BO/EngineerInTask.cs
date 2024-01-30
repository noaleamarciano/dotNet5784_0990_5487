///<summary>
///Represents an engineer handling some task
///</summary>
/// <param name="engineerId">personal unique id for the  engineer</param>
/// <param name="name">the name of the engineer</param>
namespace BO;

public class EngineerInTask
{
    public int engineerId { get; init; }
    public string? name { get; set; }
    public override string? ToString() => this.GenericToString();

}
