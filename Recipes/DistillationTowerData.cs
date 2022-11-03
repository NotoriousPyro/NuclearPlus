using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;

namespace NuclearPlus.Recipes;

internal class DistillationTowerData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.RecipeProtoBuilder
            .Start("Spent fuel solution distillation (stage 1)", NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT1, Ids.Machines.DistillationTowerT1)
                .AddInput(100, NuclearPlusIds.Products.SpentFuelSolutionT1, "B")
                .AddInput(32, Ids.Products.SteamHi, "A")
                .SetDuration(360.Seconds())
                .AddOutput(97, NuclearPlusIds.Products.SpentFuelSolutionT2, "X")
                .AddOutput(3, NuclearPlusIds.Products.FissionProducts, "Y")
            .BuildAndAdd();

        registrator.RecipeProtoBuilder
            .Start("Spent fuel solution distillation (stage 2)", NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT2, Ids.Machines.DistillationTowerT2)
                .AddInput(97, NuclearPlusIds.Products.SpentFuelSolutionT2, "B")
                .AddInput(32, Ids.Products.SteamHi, "A")
                .SetDuration(360.Seconds())
                .AddOutput(9, NuclearPlusIds.Products.SpentFuelSolutionT3, "X")
                .AddOutput(88, NuclearPlusIds.Products.UranylNitrate, "Z")
            .BuildAndAdd();

        registrator.RecipeProtoBuilder
            .Start("Spent fuel solution distillation (stage 3)", NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT3, Ids.Machines.DistillationTowerT3)
                .AddInput(9, NuclearPlusIds.Products.SpentFuelSolutionT3, "B")
                .AddInput(32, Ids.Products.SteamHi, "A")
                .SetDuration(360.Seconds())
                .AddOutput(1, NuclearPlusIds.Products.FissionProducts, "X")
                .AddOutput(8, NuclearPlusIds.Products.PlutoniumNitrate, "Z")
            .BuildAndAdd();
    }
}
