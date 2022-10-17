using Mafi.Base;
using Mafi.Core.Products;

namespace NuclearPlus;

public partial class NuclearPlusIds
{
    public static class Products
    {
        public static readonly ProductProto.ID SpentFuelSolutionT1 = Ids.Products.CreateId("SpentFuelSolutionT1");
        public static readonly ProductProto.ID SpentFuelSolutionT2 = Ids.Products.CreateId("SpentFuelSolutionT2");
        public static readonly ProductProto.ID SpentFuelSolutionT3 = Ids.Products.CreateId("SpentFuelSolutionT3");

        public static readonly ProductProto.ID FissionProducts = Ids.Products.CreateId("FissionProducts");
        public static readonly ProductProto.ID FissionProductsDepleted = Ids.Products.CreateId("FissionProductsDepleted");
        public static readonly ProductProto.ID NitricAcid = Ids.Products.CreateId("NitricAcid");
        public static readonly ProductProto.ID UranylNitrate = Ids.Products.CreateId("UranylNitrate");
        public static readonly ProductProto.ID PlutoniumNitrate = Ids.Products.CreateId("PlutoniumNitrate");
        public static readonly ProductProto.ID BreederSpentFuel = Ids.Products.CreateId("BreederSpentFuel");
        public static readonly ProductProto.ID BreederSpentFuelFromUranium = Ids.Products.CreateId("BreederSpentFuelFromUranium");
        public static readonly ProductProto.ID PlutoniumRod = Ids.Products.CreateId("PlutoniumRod");
        public static readonly ProductProto.ID PlutoniumPellets = Ids.Products.CreateId("PlutoniumPellets");
    }
}
