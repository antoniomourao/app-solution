using Microsoft.Extensions.Logging;

namespace AppShared.Domain;

public interface IDomainModuleServices {
    IEnumerable<IDomainModule> DomainModules { get; }
}


public class DomainModuleServices: IDomainModuleServices {

private readonly ILogger<DomainModuleServices> _logger;
    public DomainModuleServices(
        IEnumerable<IDomainModule> domainModules,
        ILogger<DomainModuleServices> logger) {
        DomainModules = domainModules;
        _logger = logger;

        _logger.LogInformation("Loaded  {0} DomainModuleServices.", DomainModules.Count());
    }

    public IEnumerable<IDomainModule> DomainModules { get; }
}