using Mafi.Base;
using Mafi.Core.Research;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace NuclearPlus;


public partial class NuclearPlusIds
{
    public partial class Research
    {
        public static readonly ResNodeID UnlockAdvancedNuclear = Ids.Research.CreateId("UnlockAdvancedNuclear");
        public static readonly ResNodeID UnlockPlutoniumPowerProduction = Ids.Research.CreateId("UnlockPlutoniumPowerProduction");
    }
}