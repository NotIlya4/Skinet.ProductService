using Api.Extensions;

namespace Api.Properties;

public class ParametersProvider
{
    private readonly IConfiguration _config;

    public ParametersProvider(IConfiguration config)
    {
        _config = config;
    }
    
    public string SqlServer => _config.GetSqlServerConnectionString("SqlServer");

    public bool AutoMigrate => _config.GetRequiredValue<bool>("AutoMigrate");

    public bool AutoSeed => _config.GetRequiredValue<bool>("AutoSeed");

    public string Seq => _config.GetRequiredValue("SeqUrl");
}