using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Factory.NuclearReactors;

namespace NuclearPlus.Buildings;

internal class ReactorData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var uraniumRod = registrator.PrototypesDb.GetOrThrow<ProductProto>(Ids.Products.UraniumRod);
        var plutoniumRod = registrator.PrototypesDb.GetOrThrow<ProductProto>(NuclearPlusIds.Products.PlutoniumRod);
        var breederSpentFuel = registrator.PrototypesDb.GetOrThrow<ProductProto>(NuclearPlusIds.Products.BreederSpentFuel);
        var spentFuel = registrator.PrototypesDb.GetOrThrow<ProductProto>(Ids.Products.SpentFuel);
        var nuclearReactor = registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor);
        
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium nuclear reactor", NuclearPlusIds.Buildings.PlutoniumReactor)
                .Description("This reactor can utilize plutonium rods. Plutonium is around 100 times more energy dense than uranium, thus only 1% of the fuel is used.")
                .SetCost(Utils.Costs.CostMultiplier<NuclearReactorProto>(registrator, Ids.Buildings.NuclearReactor, 2, 1.2, 1.2))
                .AddFuelPair(plutoniumRod, spentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(nuclearReactor.Graphics.IconPath)
            .BuildAndAdd();
    
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium fast breeder reactor", NuclearPlusIds.Buildings.PlutoniumBreederReactor)
                .Description("This reactor can utilize plutonium rods. Plutonium is around 100 times more energy dense than uranium, thus only 1% of the fuel is used. The output of this reactor contains more fissile material than was consumed in the reaction.")
                .SetCost(Utils.Costs.CostMultiplier<NuclearReactorProto>(registrator, Ids.Buildings.NuclearReactor, 2, 1.5, 1.5))
                .AddFuelPair(plutoniumRod, breederSpentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(nuclearReactor.Graphics.IconPath)
            .BuildAndAdd();

        registrator.NuclearReactorProtoBuilder()
            .Start("Uranium fast breeder reactor", NuclearPlusIds.Buildings.BreederReactor)
                .Description("This reactor can utilize uranium rods. The output of this reactor contains more fissile material than was consumed in the reaction.")
                .SetCost(Utils.Costs.CostMultiplier<NuclearReactorProto>(registrator, Ids.Buildings.NuclearReactor, 2, 2, 1.5))
                .AddFuelPair(uraniumRod, breederSpentFuel, 180.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(nuclearReactor.Graphics.IconPath)
            .BuildAndAdd();
    }
}
