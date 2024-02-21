using System.Collections.Generic;
using System.Linq;
using Example;
using NUnit.Framework;
using PsExampleCmdlet.Tests.Helpers;

namespace PsExampleCmdlet.Tests;

public partial class Tests
{
    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Thing_Test()
    {
        var results = ExecuteCmdlet("69");

        Assert.That(results.Count, Is.EqualTo(1));
        Assert.That(results.First(), Is.EqualTo("You passed a thing: 69"));
    }

    [Test]
    public void Terminate_Test()
    {
        Assert.Catch(() => ExecuteCmdlet(string.Empty, true));
    }

    [Test]
    public void WhatIf_Test()
    {
        var results = ExecuteCmdlet("420", false, true);

        Assert.That(results.Count, Is.EqualTo(2));
        Assert.That(results.First(), Is.EqualTo("WhatIf is present."));
    }

    [TearDown]
    public void TearDown()
    {
        
    }

    /// <summary>
    /// Executes InvokeExampleCmdlet.
    /// </summary>
    /// <param name="thing"></param>
    /// <param name="terminate"></param>
    /// <param name="whatIf"></param>
    /// <returns></returns>
    private static List<object> ExecuteCmdlet(string thing, bool terminate = false, bool whatIf = false) =>
        ExecuteCmdlet(new InvokeExampleCmdlet
        {
            Thing = thing,
            Terminate = terminate,
            WhatIf = whatIf
        });

    /// <summary>
    /// Executes InvokeExampleCmdlet.
    /// </summary>
    /// <param name="cmdlet"></param>
    /// <returns></returns>
    private static List<object> ExecuteCmdlet(InvokeExampleCmdlet cmdlet)
    {
        var psEmulator = new PowershellEmulator();

        cmdlet.CommandRuntime = psEmulator;
        cmdlet.ProcessInternal();

        return psEmulator.OutputObjects;
    }
}