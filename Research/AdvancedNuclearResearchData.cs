using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace NuclearPlus.Research;

internal class AdvancedNuclearResearchData : IResearchNodesData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var nuclearParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.NuclearReactor);
        var advancedNuclear = registrator.ResearchNodeProtoBuilder
            .Start("Advanced nuclear", NuclearPlusIds.Research.UnlockAdvancedNuclear)
                .Description("Unlock advanced nuclear.")
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.BreederSpentFuelRecycling)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.FissionProductsDepletedProduction)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.NitricAcidProduction)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.SpentFuelRecycling)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT1)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT2)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.UraniumEnrichmentFromNitrate)
                .AddProductToUnlock(NuclearPlusIds.Products.BreederSpentFuel)
                .AddProductToUnlock(NuclearPlusIds.Products.NitricAcid)
                .AddProductToUnlock(NuclearPlusIds.Products.FissionProducts)
                .AddProductToUnlock(NuclearPlusIds.Products.FissionProductsDepleted)
                .AddProductToUnlock(NuclearPlusIds.Products.SpentFuelSolutionT1)
                .AddProductToUnlock(NuclearPlusIds.Products.SpentFuelSolutionT2)
                .AddProductToUnlock(NuclearPlusIds.Products.UranylNitrate)
                .AddLayoutEntityToUnlock(NuclearPlusIds.Buildings.BreederReactor)
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(24))
                .SetGridPosition(nuclearParent.GridPosition + new Vector2i(4, 1))
                .AddParents(nuclearParent)
            .BuildAndAdd();

        var roboticsAssemblyParent = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.Assembler3);
        var plutoniumRodResearch = registrator.ResearchNodeProtoBuilder
            .Start("Plutonium power production", NuclearPlusIds.Research.UnlockPlutoniumPowerProduction)
                .Description("Unlock plutonium power production.")
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.PlutoniumEnrichmentFromNitrate)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.PlutoniumRodProduction)
                .AddRecipeToUnlock(NuclearPlusIds.Recipes.SpentFuelSolutionDistillationT3)
                .AddProductToUnlock(NuclearPlusIds.Products.PlutoniumNitrate)
                .AddProductToUnlock(NuclearPlusIds.Products.PlutoniumPellets)
                .AddProductToUnlock(NuclearPlusIds.Products.PlutoniumRod)
                .AddProductToUnlock(NuclearPlusIds.Products.SpentFuelSolutionT3)
                .AddLayoutEntityToUnlock(NuclearPlusIds.Buildings.PlutoniumBreederReactor)
                .AddLayoutEntityToUnlock(NuclearPlusIds.Buildings.PlutoniumReactor)
                .SetCosts(ResearchCostsTpl.Build.SetDifficulty(45))
                .SetGridPosition(roboticsAssemblyParent.GridPosition + new Vector2i(5, 20))
                .AddParents(roboticsAssemblyParent, advancedNuclear)
            .BuildAndAdd();
    }
}
