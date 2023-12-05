namespace DO; 
/// <summary>
/// Engineer entity represents an engineer with all its propreties.
/// </summary>
/// <param name="engineerId">personal unique id for the  engineer</param>
/// <param name="engineerName">the name of the engineer</param>
/// <param name="engineerEmail">the email of the engineer</param>
/// <param name="costPerHour">cost per hour for the engineer</param>
public record Engineer
(

    int engineerId,
    string? engineerName,
    string? engineerEmail,
    int? costPerHour,
    EngineerExperience exp,
    bool isActive = true
);
