using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;

namespace NuclearPlus.Products;

internal class CountableProductData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.CountableProductProtoBuilder
            .Start("Plutonium rods", NuclearPlusIds.Products.PlutoniumRod)
                .Description("Plutonium rods ready for use in a plutonium reactor. Plutonium is around 100 times more energy dense than uranium.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetPrefabPath(Assets.Base.Products.Countable.UraniumRod_prefab)
                .SetCustomIconPath(Assets.Base.Products.Icons.UraniumRod_svg)
                .MaxQuantityPerTransportStack(1)
            .BuildAndAdd();

        registrator.CountableProductProtoBuilder
            .Start("Plutonium pellets", NuclearPlusIds.Products.PlutoniumPellets)
                .Description("These pellets need to be prepared into rods before they can be used in a reactor. Plutonium is around 100 times more energy dense than uranium.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetPrefabPath(Assets.Base.Products.Countable.UraniumPellets_prefab)
                .SetCustomIconPath(Assets.Base.Products.Icons.UraniumPellets_svg)
                .MaxQuantityPerTransportStack(1)
            .BuildAndAdd();

        registrator.CountableProductProtoBuilder
            .Start("Spent fuel (Breeder reactor)", NuclearPlusIds.Products.BreederSpentFuel)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(2)
                .SetPrefabPath(Assets.Base.Products.Countable.SpentFuel_prefab)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
                .MaxQuantityPerTransportStack(1)
            .BuildAndAdd();

        registrator.CountableProductProtoBuilder
            .Start("Fission products (depleted)", NuclearPlusIds.Products.FissionProductsDepleted)
                .Description("Fission products from nuclear reactor waste that has been reprocessed and crystallised in glass for safer storage.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetPrefabPath(Assets.Base.Products.Countable.SpentFuel_prefab)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
                .MaxQuantityPerTransportStack(1)
            .BuildAndAdd();
    }
}
