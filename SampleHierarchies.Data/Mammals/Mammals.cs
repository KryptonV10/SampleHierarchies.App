using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }

    public List<ITiger> Tigers { get; set; }

    public List<IFlyingSquirrel> FlyingSquirrels { get; set; }

    public List<IHedgehog> Hedgehogs { get; set; }

    #endregion // IMammals Implementation

    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Tigers = new List<ITiger>();
        FlyingSquirrels = new List<IFlyingSquirrel>();
        Hedgehogs = new List<IHedgehog>();
    }

    #endregion // Ctors
}
