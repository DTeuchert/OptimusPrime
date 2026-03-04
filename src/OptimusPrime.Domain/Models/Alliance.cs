using OptimusPrime.Domain.Abstractions;
using OptimusPrime.Domain.Exceptions;

namespace OptimusPrime.Domain.Models;

public class Alliance(int id, string name, string description) : Enumeration(id, name, description)
{
    public static readonly Alliance Autobot = new(0, "Autobot", "");
    public static readonly Alliance Decepticon = new(1, "Decepticon", "");
    
    public static IEnumerable<Alliance> List() => [Autobot, Decepticon];

    public static Alliance Get(int id)
    {
        return GetAll<Alliance>().FirstOrDefault(x => x.Id == id) ?? Autobot;
    }

    public static Alliance FromName(string name)
    {
        var type = List().SingleOrDefault(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        if (type is null)
        {
            throw new OptimusPrimeException(
                $"Possible values for alliance: {string.Join(",", List().Select(x => x.Name))}");
        }

        return type;
    }

    public static Alliance From(int id)
    {
        var type = List().SingleOrDefault(x => x.Id == id);
        if (type is null)
        {
            throw new OptimusPrimeException(
                $"Possible values for alliance: {string.Join(",", List().Select(x => x.Name))}");
        }

        return type;
    }
}
