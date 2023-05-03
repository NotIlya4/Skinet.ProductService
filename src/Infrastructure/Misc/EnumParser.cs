namespace Infrastructure.Misc;

public class EnumParser
{
    public static T Parse<T>(string e) where T : struct
    {
        return Enum.Parse<T>(e, true);
    }
}