using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Static;
using Mafi.Core.Products;
using Mafi;
using System;

namespace NuclearPlus.Utils;

internal static class Costs
{
    internal static EntityCostsTpl CostMultiplier<T>
    (
        ProtoRegistrator registrator,
        StaticEntityProto.ID entityId,
        double productCostMulti = 1.0,
        double maintenanceCostsMulti = 1.0,
        double workersCostMulti = 1.0
    )
        where T : EntityProto
    {
        var baseCosts = registrator.PrototypesDb.GetOrThrow<T>(entityId).Costs;
        var costs = new EntityCostsTpl.Builder();
        if (baseCosts.Maintenance.Product != VirtualProductProto.Phantom && baseCosts.Maintenance.MaintenancePerMonth > 0.Quantity()) {
            costs.Maintenance(
                (int)Math.Round(baseCosts.Maintenance.MaintenancePerMonth.Value.ToIntCeiled() * maintenanceCostsMulti),
                baseCosts.Maintenance.Product.Id
            );
        }
        if (baseCosts.Workers > 0) {
            costs.Workers((int)Math.Round(baseCosts.Workers * workersCostMulti));
        }
        foreach (var product in baseCosts.Price.Products) {
            costs.Product((int)Math.Round(product.Quantity.Value * productCostMulti), product.Product.Id);
        }
        return costs;
    }
}
