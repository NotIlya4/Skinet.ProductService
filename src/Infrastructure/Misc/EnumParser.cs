namespace Infrastructure.Misc;

public static class EnumParser
{
    public static T Parse<T>(string e) where T : struct
    {
        return Enum.Parse<T>(e, true);
    }
}