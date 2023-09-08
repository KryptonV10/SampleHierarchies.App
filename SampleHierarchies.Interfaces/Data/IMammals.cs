using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }

    List<ITiger> Tigers { get; set; }

    List<IFlyingSquirrel> FlyingSquirrels { get; set; }

    List<IHedgehog> Hedgehogs { get; set; }

    #endregion // Interface Members
}
