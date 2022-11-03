using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Prototypes;
using Mafi.Core.Factory.Machines;

namespace NuclearPlus.Machines;

internal class AdvancedCoolingTowerData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        registrator.MachineProtoBuilder
            .Start("Advanced cooling tower", NuclearPlusIds.Machines.AdvancedCoolingTower)
                .Description("An advanced cooling tower using chilled water to cool the steam, increasing condensation and improving the recovery of water.")
                .SetCost(Utils.Costs.CostMultiplier<MachineProto>(registrator, Ids.Machines.CoolingTowerT2, 1.5, 1.5, 1.5))
                .SetCategories(Ids.ToolbarCategories.MachinesWater)
                .SetLayout(new EntityLayoutParams(null, useNewLayoutSyntax: true, new CustomLayoutToken[1]
                {
                    new CustomLayoutToken("[0!", delegate(EntityLayoutParams p, int h)
                    {
                        int heightToExcl = 2 * h + 1;
                        int? terrainSurfaceHeight = 0;
                        Proto.ID? surfaceId = p.HardenedFloorSurfaceId;
                        return new LayoutTokenSpec(0, heightToExcl, LayoutTileConstraint.None, terrainSurfaceHeight, null, null, null, null, surfaceId);
                    })
                }),
                "      [1![1![2![2![2![1![1!      ",
                "   [1![2![2![5![5![5![2![2![1!   ",
                "   [1![2![5![5![5![5![5![2![1!   ",
                "A@>[2![5![5![5![5![5![5![5![2!>@X",
                "B@>[2![5![5![5![5![5![5![5![2!>@Y",
                "C@>[2![5![5![5![5![5![5![5![2!>@Z",
                "   [1![2![5![5![5![5![5![2![1!   ",
                "   [1![2![2![5![5![5![2![2![1!   ",
                "      [1![1![2![2![2![1![1!      "
                )
                .AddParticleParams(ParticlesParams.Loop("Steam", useUtilizationOnAlpha: true))
                .UseAllRecipesAtStartOrAfterUnlock()
                .SetPrefabPath(Assets.Base.Machines.PowerPlant.CoolingTowerT2_prefab)
                .SetCustomIconPath(registrator.PrototypesDb.GetOrThrow<MachineProto>(Ids.Machines.CoolingTowerT2).Graphics.IconPath)
            .BuildAndAdd();
    }
}
