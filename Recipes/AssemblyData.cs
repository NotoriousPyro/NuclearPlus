using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Factory.Machines;

namespace NuclearPlus.Recipes;

internal class AssemblyData : IModData
{
    private static readonly MachineProto.ID machineId = Ids.Machines.AssemblyRoboticT2;
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.RecipeProtoBuilder
            .Start("Plutonium rods (T1)", NuclearPlusIds.Recipes.PlutoniumRodProduction, machineId)
            .AddInput(36, NuclearPlusIds.Products.PlutoniumPellets)
            .AddInput(1, Ids.Products.Steel)
            .SetDuration(180.Seconds())
            .AddOutput(6, NuclearPlusIds.Products.PlutoniumRod)
        .BuildAndAdd();
    }
}
