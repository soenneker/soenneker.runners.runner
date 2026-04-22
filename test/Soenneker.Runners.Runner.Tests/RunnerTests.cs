using Soenneker.Tests.HostedUnit;

namespace Soenneker.Runners.Runner.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class RunnerTests : HostedUnitTest
{
    public RunnerTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
