using Mafi.Base;
using RecipeID = Mafi.Core.Factory.Recipes.RecipeProto.ID;

namespace NuclearPlus;

public partial class NuclearPlusIds
{
    public partial class Recipes
    {
        public static readonly RecipeID SpentFuelRecycling = Ids.Recipes.CreateId("SpentFuelRecycling");
        public static readonly RecipeID SpentFuelSolutionDistillationT1 = Ids.Recipes.CreateId("SpentFuelSolutionDistillationT1");
        public static readonly RecipeID SpentFuelSolutionDistillationT2 = Ids.Recipes.CreateId("SpentFuelSolutionDistillationT2");
        public static readonly RecipeID SpentFuelSolutionDistillationT3 = Ids.Recipes.CreateId("SpentFuelSolutionDistillationT3");
        public static readonly RecipeID UraniumEnrichmentFromNitrate = Ids.Recipes.CreateId("UraniumEnrichmentFromNitrate");
        public static readonly RecipeID PlutoniumEnrichmentFromNitrate = Ids.Recipes.CreateId("PlutoniumEnrichmentFromNitrate");
        public static readonly RecipeID PlutoniumRodProduction = Ids.Recipes.CreateId("PlutoniumRodProduction");
        public static readonly RecipeID BreederSpentFuelRecycling = Ids.Recipes.CreateId("BreederSpentFuelRecycling");
        public static readonly RecipeID NitricAcidProduction = Ids.Recipes.CreateId("NitricAcidProduction");
        public static readonly RecipeID FissionProductsDepletedProduction = Ids.Recipes.CreateId("FissionProductsDepletedProduction");
    }
}