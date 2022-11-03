using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Factory.Recipes;
using Mafi.Core.Products;

namespace NuclearPlus.Recipes;

internal class AdvancedCoolingTowerData : IModData
{
    private static void registerCoolingTowerRecipe(
        string name,
        ProtoRegistrator registrator,
        RecipeProto.ID recipeId,
        ProductProto.ID inputProductId
    ) => registrator.RecipeProtoBuilder
            .Start($"{name} steam condensation", recipeId, NuclearPlusIds.Machines.AdvancedCoolingTower)
                .EnablePartialExecution(25.Percent())
                .AddInput(16, inputProductId)
                .AddInput(1, Ids.Products.ChilledWater)
                .SetDuration(10.Seconds())
                .AddOutput(15, Ids.Products.Water)
            .BuildAndAdd();

    public void RegisterData(ProtoRegistrator registrator)
    {
        registerCoolingTowerRecipe(
            "Hi-press",
            registrator,
            NuclearPlusIds.Recipes.AdvancedSteamHpCondensation,
            Ids.Products.SteamHi
        );
        registerCoolingTowerRecipe(
            "Lo-press",
            registrator,
            NuclearPlusIds.Recipes.AdvancedSteamLpCondensation,
            Ids.Products.SteamLo
        );
        registerCoolingTowerRecipe(
            "Depleted",
            registrator,
            NuclearPlusIds.Recipes.AdvancedSteamDepletedCondensation,
            Ids.Products.SteamDepleted
        );
    }
}
