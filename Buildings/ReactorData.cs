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
        
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium nuclear reactor", NuclearPlusIds.Buildings.PlutoniumReactor)
                .Description("This reactor can utilize plutonium rods.")
                .AddFuelPair(plutoniumRod, spentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();
    
        registrator.NuclearReactorProtoBuilder()
            .Start("Plutonium fast breeder reactor", NuclearPlusIds.Buildings.PlutoniumBreederReactor)
                .Description("This reactor can utilize plutonium rods. The output of this reactor contains more fissile material than was consumed in the reaction. Plutonium is around 100 times more energy dense than uranium, thus only 1% of the fuel is used.")
                .AddFuelPair(plutoniumRod, breederSpentFuel, 18000.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();

        registrator.NuclearReactorProtoBuilder()
            .Start("Uranium fast breeder reactor", NuclearPlusIds.Buildings.BreederReactor)
                .Description("This reactor can utilize uranium rods. The output of this reactor contains more fissile material than was consumed in the reaction.")
                .AddFuelPair(uraniumRod, breederSpentFuel, 180.Seconds())
                .SetCategories(Ids.ToolbarCategories.MachinesElectricity)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<NuclearReactorProto>(Ids.Buildings.NuclearReactor).Graphics.IconPath)
            .BuildAndAdd();
    }
}
