using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;

namespace NuclearPlus.Products;

internal class FluidProductData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.FluidProductProtoBuilder
            .Start("Spent fuel solution", NuclearPlusIds.Products.SpentFuelSolutionT1)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Spent fuel solution (stage 2)", NuclearPlusIds.Products.SpentFuelSolutionT2)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Spent fuel solution (stage 3)", NuclearPlusIds.Products.SpentFuelSolutionT3)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Fission products", NuclearPlusIds.Products.FissionProducts)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Magenta)
                .SetCustomIconPath(Assets.Base.Products.Icons.OilMedium_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Uranyl nitrate", NuclearPlusIds.Products.UranylNitrate)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Green)
                .SetCustomIconPath(Assets.Base.Products.Icons.OilLight_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Plutonium nitrate", NuclearPlusIds.Products.PlutoniumNitrate)
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Yellow)
                .SetCustomIconPath(Assets.Base.Products.Icons.Naphtha_svg)
            .BuildAndAdd();
        
        registrator.FluidProductProtoBuilder
            .Start("Nitric acid", NuclearPlusIds.Products.NitricAcid)
                .SetIsStorable(true)
                .SetCanBeDiscarded(true)
                .SetIsWaste(false)
                .SetColor(ColorRgba.Blue)
                .SetCustomIconPath(Assets.Base.Products.Icons.Acid_svg)
            .BuildAndAdd();
    }
}
