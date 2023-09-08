﻿using System.ComponentModel;
/// <summary>
/// Dummy enum.
/// </summary>
public enum MammalSpecies
{
    [Description("Simple description of a none")]
    None = 0,
    [Description("Simple description of a dog")]
    Dog = 1,
    [Description("Simple description of a tiger")]
    Tiger = 2,
    [Description("Simple description of a flying squirrel")]
    FlyingSquirrel = 3,
    [Description("Simple description of a hedgehog")]
    Hedgehog = 4,
}
