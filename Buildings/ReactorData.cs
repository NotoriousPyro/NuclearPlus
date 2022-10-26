using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Factory.NuclearReactors;
using Mafi.Core.Prototypes;
using System;

namespace NuclearPlus.Buildings;

internal class ReactorData : IModData
{

    private EntityCostsTpl ReactorCostBuilder(ProtoRegistrator registrator,
        double productCostMulti,
        double maintenanceCostsMulti,
        double workersCostMulti
    ) {
        var reactorCost = registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Costs;
        var costs = new EntityCostsTpl.Builder()
            .Maintenance(
                (int)Math.Round(reactorCost.Maintenance.MaintenancePerMonth.Value.ToIntCeiled() * maintenanceCostsMulti),
                reactorCost.Maintenance.Product.Id
            )
            .Workers((int)Math.Round(reactorCost.Workers * workersCostMulti));
        foreach (var product in reactorCost.Price.Products) {
            costs.Product(((int)Math.Round(product.Quantity.Value * productCostMulti)), product.Product.Id);
        }
        return costs;
    }

    public void RegisterData(ProtoRegistrator registrator)
    {
        var uraniumRod = registrator.PrototypesDb.GetOrThrow<ProductProto>(Ids.Products.UraniumRod);
        var plutoniumRod = registrator.PrototypesDb.GetOrThrow<ProductProto>(NuclearPlusIds.Products.PlutoniumRod);
        var breederSpentFuel = registrator.PrototypesDb.GetOrThrow<ProductProto>(NuclearPlusIds.Products.BreederSpentFuel);
        var spentFuel = registrator.PrototypesDb.GetOrThrow<ProductProto>(Ids.Products.SpentFuel);
        
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium nuclear reactor", NuclearPlusIds.Buildings.PlutoniumReactor)
                .Description("This reactor can utilize plutonium rods. Plutonium is around 100 times more energy dense than uranium, thus only 1% of the fuel is used.")
                .SetCost(ReactorCostBuilder(registrator, 2, 1.2, 1.2))
                .AddFuelPair(plutoniumRod, spentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();
    
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium fast breeder reactor", NuclearPlusIds.Buildings.PlutoniumBreederReactor)
                .Description("This reactor can utilize plutonium rods. Plutonium is around 100 times more energy dense than uranium, thus only 1% of the fuel is used. The output of this reactor contains more fissile material than was consumed in the reaction.")
                .SetCost(ReactorCostBuilder(registrator, 2, 1.5, 1.5))
                .AddFuelPair(plutoniumRod, breederSpentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();

        registrator.NuclearReactorProtoBuilder()
            .Start("Uranium fast breeder reactor", NuclearPlusIds.Buildings.BreederReactor)
                .Description("This reactor can utilize uranium rods. The output of this reactor contains more fissile material than was consumed in the reaction.")
                .SetCost(ReactorCostBuilder(registrator, 2, 2, 1.5))
                .AddFuelPair(uraniumRod, breederSpentFuel, 180.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();
    }
}
