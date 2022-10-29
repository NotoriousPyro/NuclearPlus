using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Factory.Recipes;
using Mafi.Core.Products;
using Mafi.Core.Factory.Machines;

namespace NuclearPlus.Recipes;

internal class ChemicalPlantData : IModData
{
    private static readonly MachineProto.ID machineId = Ids.Machines.ChemicalPlant2;

    private static void registerReprocessingRecipe(
        string name,
        ProtoRegistrator registrator,
        RecipeProto.ID recipeId,
        ProductProto.ID inputProductId,
        int outputProducts
    ) => registrator.RecipeProtoBuilder
            .Start($"{name} reprocessing", recipeId, machineId)
            .AddInput(50, inputProductId)
            .AddInput(50, NuclearPlusIds.Products.NitricAcid)
            .SetDuration(20.Seconds())
            .AddOutput(outputProducts, NuclearPlusIds.Products.SpentFuelSolutionT1)
        .BuildAndAdd();

    private static void registerEnrichmentFromNitrateRecipe(
        string name,
        ProtoRegistrator registrator,
        RecipeProto.ID recipeId,
        ProductProto.ID inputProductId,
        ProductProto.ID outputProductId
    ) => registrator.RecipeProtoBuilder
            .Start($"{name} enrichment", recipeId, machineId)
            .AddInput(4, inputProductId)
            .SetDuration(20.Seconds())
            .AddOutput(2, NuclearPlusIds.Products.NitricAcid)
            .AddOutput(24, outputProductId)
        .BuildAndAdd();

    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.RecipeProtoBuilder
            .Start("Nitric acid", NuclearPlusIds.Recipes.NitricAcidProduction, machineId)
            .AddInput(2, Ids.Products.Ammonia)
            .AddInput(4, Ids.Products.Acid)
            .SetDuration(20.Seconds())
            .AddOutput(6, NuclearPlusIds.Products.NitricAcid)
        .BuildAndAdd();

        registerReprocessingRecipe(
            "Spent fuel",
            registrator,
            recipeId: NuclearPlusIds.Recipes.SpentFuelRecycling,
            inputProductId: Ids.Products.SpentFuel,
            outputProducts: 100
        );
        registerReprocessingRecipe(
            "Breeder reactor spent fuel",
            registrator,
            recipeId: NuclearPlusIds.Recipes.BreederSpentFuelRecycling,
            inputProductId: NuclearPlusIds.Products.BreederSpentFuel,
            outputProducts: 105
        );

        registerEnrichmentFromNitrateRecipe(
            "Uranium",
            registrator,
            NuclearPlusIds.Recipes.UraniumEnrichmentFromNitrate,
            NuclearPlusIds.Products.UranylNitrate,
            Ids.Products.UraniumPellets
        );
        registerEnrichmentFromNitrateRecipe(
            "Plutonium",
            registrator,
            NuclearPlusIds.Recipes.PlutoniumEnrichmentFromNitrate,
            NuclearPlusIds.Products.PlutoniumNitrate,
            NuclearPlusIds.Products.PlutoniumPellets
        );

        registrator.RecipeProtoBuilder
            .Start($"Fission product evaporation", NuclearPlusIds.Recipes.FissionProductsDepletedProduction, machineId)
            .AddInput(1, Ids.Products.Glass)
            .AddInput(4, NuclearPlusIds.Products.FissionProducts)
            .SetDuration(60.Seconds())
            .AddOutput(1, NuclearPlusIds.Products.NitricAcid)
            .AddOutput(3, NuclearPlusIds.Products.FissionProductsDepleted)
        .BuildAndAdd();
    }
}
