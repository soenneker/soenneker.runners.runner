using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Runners.Runner.Tests;

[Collection("Collection")]
public class RunnerTests : FixturedUnitTest
{
    public RunnerTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
