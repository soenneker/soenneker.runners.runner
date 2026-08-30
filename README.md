[![](https://img.shields.io/nuget/v/soenneker.runners.runner.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.runner/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.runner/build-and-test.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.runners.runner/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/nuget/dt/soenneker.runners.runner.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.runners.runner/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.runners.runner/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.runners.runner/actions/workflows/codeql.yml)

# Soenneker.Runners.Runner

A base class and marker interface for scheduled or manually invoked application task runners.

## Installation

```bash
dotnet add package Soenneker.Runners.Runner
```

## Usage

Derive a runner to share the Microsoft Teams utility, background queue, logger, and construction timestamp:

```csharp
using Microsoft.Extensions.Logging;
using Soenneker.MsTeams.Util.Abstract;
using Soenneker.Runners.Runner;
using Soenneker.Utils.BackgroundQueue.Abstract;

public sealed class CleanupRunner : Runner
{
    public CleanupRunner(
        ILogger<Runner> logger,
        IMsTeamsUtil msTeamsUtil,
        IBackgroundQueue backgroundQueue)
        : base(logger, msTeamsUtil, backgroundQueue)
    {
    }

    public Task Run(CancellationToken cancellationToken)
    {
        Logger.LogInformation("Cleanup runner started at {UtcNow}", UtcNow);
        return Task.CompletedTask;
    }
}
```

Register the derived class with the lifetime appropriate for its work:

```csharp
services.AddScoped<CleanupRunner>();
```

`IRunner` is a marker interface; it does not define scheduling or execution methods. Each derived runner defines its own operations and is invoked by the application's scheduler, hosted service, or controller.

`UtcNow` is captured once when the runner is constructed. It is not a live clock: a singleton runner retains the same value for its entire lifetime, while a scoped runner receives a new value per scope.
