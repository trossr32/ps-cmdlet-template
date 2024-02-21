using System;
using System.Management.Automation;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PsExampleCmdlet.Tests")]
namespace Example;

/// <summary>
/// <para type="synopsis">An example Powershell Cmdlet.</para>
/// <para type="description">
/// Example description.
/// </para>
/// <example>
///     <para>Example of an example :)  </para>
///     <code>PS C:\> Invoke-Example</code>
/// </example>
/// <example>
///     <para>Example with args</para>
///     <code>PS C:\> Invoke-Example -Thing "420" -WhatIf -Terminate</code>
/// </example>
/// <para type="link" uri="(https://github.com/trossr32/ps-example-cmdlet)">[Github]</para>
/// </summary>
[Cmdlet(VerbsLifecycle.Invoke, "Example", HelpUri = "https://github.com/trossr32/ps-example-cmdlet")]
public class InvokeExampleCmdlet : PSCmdlet
{
    #region Parameters

    /// <summary>
    /// <para type="description">
    /// A thing string.
    /// </para>
    /// </summary>
    [Parameter(Mandatory = false, Position = 0)]
    [Alias("t")]
    public string Thing { get; set; }

    /// <summary>
    /// <para type="description">
    /// A switch parameter.
    /// </para>
    /// </summary>
    [Parameter(Mandatory = false)]
    public SwitchParameter WhatIf { get; set; }

    /// <summary>
    /// <para type="description">
    /// Create error.
    /// </para>
    /// </summary>
    [Parameter(Mandatory = false)]
    public SwitchParameter Terminate { get; set; }

    #endregion

    internal void ProcessInternal()
    {
        BeginProcessing();
        ProcessRecord();
        EndProcessing();
    }

    /// <summary>
    /// Implements the <see cref="BeginProcessing"/> method for <see cref="InvokeExampleCmdlet"/>.
    /// Initialise temporary containers
    /// </summary>
    protected override void BeginProcessing()
    {

    }

    /// <summary>
    /// Implements the <see cref="ProcessRecord"/> method for <see cref="InvokeExampleCmdlet"/>.
    /// Validates input directory/directories exist and builds a list of directories to process in the EndProcessing method.
    /// </summary>
    protected override void ProcessRecord()
    {
        if (Terminate.IsPresent)
            ThrowTerminatingError(new ErrorRecord(new Exception("Terminating."), null, ErrorCategory.InvalidArgument, null));

        if (WhatIf.IsPresent)
            WriteObject("WhatIf is present.");

        if (!string.IsNullOrWhiteSpace(Thing))
            WriteObject($"You passed a thing: {Thing}");
    }

    /// <summary>
    /// Implements the <see cref="EndProcessing"/> method for <see cref="InvokeExampleCmdlet"/>.
    /// Perform the folder flattening on the configured directories.
    /// </summary>
    protected override void EndProcessing()
    {
        
    }
}