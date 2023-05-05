using Api.Extensions;

namespace Api.Properties;

public class ParametersProvider
{
    private readonly IConfiguration _config;

    public ParametersProvider(IConfiguration config)
    {
        _config = config;
    }
    
    public string GetSqlServer()
    {
        return _config.GetSqlServerConnectionString("SqlServer");
    }

    public bool AutoMigrate()
    {
        return _config.GetRequiredValue<bool>("AutoMigrate");
    }

    public bool AutoSeed()
    {
        return _config.GetRequiredValue<bool>("AutoSeed");
    }

    public string SeqUrl()
    {
        return _config.GetRequiredValue("SeqUrl");
    }
}