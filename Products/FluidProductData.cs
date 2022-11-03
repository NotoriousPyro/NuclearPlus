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
                .Description("A dissolution of spent fuel in nitric acid.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Spent fuel solution (stage 2)", NuclearPlusIds.Products.SpentFuelSolutionT2)
                .Description("A dissolution of spent fuel in nitric acid.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Spent fuel solution (stage 3)", NuclearPlusIds.Products.SpentFuelSolutionT3)
                .Description("A dissolution of spent fuel in nitric acid.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Brown)
                .SetCustomIconPath(Assets.Base.Products.Icons.SpentFuel_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Fission products", NuclearPlusIds.Products.FissionProducts)
                .Description("Highly dangerous and radioactive fission products extracted from nuclear reactor waste.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(4)
                .SetColor(ColorRgba.Magenta)
                .SetCustomIconPath(Assets.Base.Products.Icons.OilMedium_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Uranyl nitrate", NuclearPlusIds.Products.UranylNitrate)
                .Description("Usable nitrate extraction of uranium from spent fuel. Can be reprocessed further into uranium rods.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Green)
                .SetCustomIconPath(Assets.Base.Products.Icons.OilLight_svg)
            .BuildAndAdd();

        registrator.FluidProductProtoBuilder
            .Start("Plutonium nitrate", NuclearPlusIds.Products.PlutoniumNitrate)
                .Description("Usable nitrate extraction of plutonium from spent fuel. Can be reprocessed further into plutonium rods. Plutonium is around 100 times more energy dense than uranium.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(false)
                .SetIsWaste(false)
                .SetRadioactivity(1)
                .SetColor(ColorRgba.Yellow)
                .SetCustomIconPath(Assets.Base.Products.Icons.Naphtha_svg)
            .BuildAndAdd();
        
        registrator.FluidProductProtoBuilder
            .Start("Nitric acid", NuclearPlusIds.Products.NitricAcid)
                .Description("Nitric acid is often used in complex reactions such as nuclear waste reprocessing as it is capable of dissolving nuclear actinides for later separation.")
                .SetIsStorable(true)
                .SetCanBeDiscarded(true)
                .SetIsWaste(false)
                .SetColor(ColorRgba.Blue)
                .SetCustomIconPath(Assets.Base.Products.Icons.Acid_svg)
            .BuildAndAdd();
    }
}
