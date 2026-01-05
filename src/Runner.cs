using Soenneker.Runners.Runner.Abstract;
using System;
using Microsoft.Extensions.Logging;
using Soenneker.MsTeams.Util.Abstract;
using Soenneker.Utils.BackgroundQueue.Abstract;

namespace Soenneker.Runners.Runner;

/// <inheritdoc cref="IRunner"/>
public abstract class Runner : IRunner
{
    protected IMsTeamsUtil MsTeamsUtil { get; }

    protected IBackgroundQueue BackgroundQueue { get; }

    protected ILogger<Runner> Logger { get; }

    protected readonly bool Log = true;

    /// <summary>
    /// Is set within ctor
    /// </summary>
    protected DateTimeOffset UtcNow { get; }

    protected Runner(ILogger<Runner> logger, IMsTeamsUtil msTeamsUtil, IBackgroundQueue backgroundQueue)
    {
        Logger = logger;
        MsTeamsUtil = msTeamsUtil;
        BackgroundQueue = backgroundQueue;

        UtcNow = DateTimeOffset.UtcNow;
    }
}