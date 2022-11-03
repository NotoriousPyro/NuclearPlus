using Mafi.Core.Economy;
using Mafi.Core.Entities.Static;
using Mafi.Core.Prototypes;
using Mafi.Core.Factory.NuclearReactors;
using Mafi.Base;
using Mafi.Core.Products;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Entities.Static.Layout;
using System.Collections.Generic;

namespace Mafi.Core.Mods;

public class NuclearReactorProtoBuilder : IProtoBuilder
{
    public class State : LayoutEntityBuilderState<State>
    {
        private readonly StaticEntityProto.ID m_id;
        private Collections.ImmutableCollections.ImmutableArray<Entities.Static.Layout.ToolbarCategoryProto> m_category;
        private ProductProto m_coolantIn;
        private ProductProto m_coolantOut;
        private List<NuclearReactorProto.FuelData> m_fuelData = new List<NuclearReactorProto.FuelData>();
        private string m_soundPrefabPath = Assets.Base.Buildings.NuclearReactors.T1.ReactorSound_prefab;

        public State(NuclearReactorProtoBuilder builder, StaticEntityProto.ID id, string name)
            : base(builder, id, name)
        {
            m_id = id;
            m_category = builder.Registrator.GetCategoriesProtos(Ids.ToolbarCategories.MachinesElectricity);
            m_coolantIn = builder.ProtosDb.GetOrThrow<ProductProto>(Ids.Products.Water);
            m_coolantOut = builder.ProtosDb.GetOrThrow<ProductProto>(Ids.Products.SteamHi);
            base.SetLayout(new EntityLayoutParams(null, useNewLayoutSyntax: true, new CustomLayoutToken[1]
            {
                new CustomLayoutToken("-0]", (EntityLayoutParams p, int h) => new LayoutTokenSpec(-h, 5, LayoutTileConstraint.None, -h))
            }),
            "                              [4][4][4][4][4][4][4]",
            "      [4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "      [4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][5][5][5][5][5][5][5][5][5][5][4]",
            "   [2][4][4][4][4][4][4][4][4][4][4][4][4][4][4][4]",
            "            [4][4][4][4][4][4][4][4][4]            ",
            "         [4][4][4][4][4][4][4][4][4][4]            ",
            "         [4][4][4]-3]-3]-3]-3][4][4][4]            ",
            "   [2][2][5][5]-3]-3]-7]-7]-3]-3]-3][5][2][2]      ",
            "F#>[2]-3]-3]-3]-3]-7]-7]-7]-7]-7]-3]-3]-3][2]      ",
            "   [2]-3]-4]-4]-7]-7]-7]-7]-7]-7]-4]-4]-3][2]      ",
            "   [2]-3]-4]-4]-7]-7]-7]-7]-7]-7]-4]-4]-3][2]      ",
            "S#<[2]-3]-3]-3]-7]-7]-7]-7]-7]-7]-3]-3]-3][2]      ",
            "   [2][2][5]-3]-3]-7]-7]-7]-7]-7]-3][5][2][2]      ",
            "         [4][4]-3]-3]-3]-3]-3]-3]-3][4]            ",
            "      D@>[4][4][4][4][4][4][4][4][4][4]W@>         ",
            "            [4][4][4][4][4][4][4][4]               ",
            "            [4][4][4][4][4][4][4][4]               ",
            "         A@>[4][4][4][4][4][4][4][4]X@>            ",
            "         B@>[4][4][5][5][5][5][5][5]Y@>            ",
            "         C@>[4][4][4][4][4][4][4][4]Z@>            ",
            "               [4][4][4][4][4][4]                  ");
            base.SetPrefabPath(Assets.Base.Buildings.NuclearReactors.NuclearReactor_prefab);
        }

        [MustUseReturnValue]
        public override State Description(string description, string explanation = "short description of a machine")
        {
            return base.Description(description, explanation);
        }

        [MustUseReturnValue]
        public State AddFuelPair(ProductProto fuelIn, ProductProto fuelOut, Duration duration)
        {
            m_fuelData.Add(new NuclearReactorProto.FuelData(fuelIn, fuelOut, duration));
            return (State)this;
        }

        [MustUseReturnValue]
        public State SetReactorSound(string prefabPath)
        {
            m_soundPrefabPath = prefabPath;
            return (State)this;
        }

        [MustUseReturnValue]
        public State SetDeconstructionParams(AssetValue productGiven, EntityCosts entityCosts)
        {
            return this;
        }

        public NuclearReactorProto BuildAndAdd()
        {
            return AddToDb(
                new NuclearReactorProto(
                    m_id,
                    base.Strings,
                    layout: base.LayoutOrThrow,
                    costs: base.Costs,
                    waterInPerStep: m_coolantIn.WithQuantity(16),
                    steamOutPerStep: m_coolantOut.WithQuantity(16),
                    processDuration: 10.Seconds(),
                    fuelPairs: ImmutableArray.Create(m_fuelData.ToArray()),
                    coolantIn: m_coolantIn,
                    coolantOut: m_coolantOut,
                    coolantInPort: 'D',
                    coolantOutPort: 'W',
                    computingConsumed: Computing.Zero,
                    nextTier: Option<NuclearReactorProto>.None,
                    graphics: new NuclearReactorProto.Gfx(
                        customIconPath: base.CustomIconPath,
                        soundPrefabPath: m_soundPrefabPath,
                        prefabPath: base.PrefabPath,
                        categories: m_category
                    )
                )
            );
        }
    }

    public ProtosDb ProtosDb => Registrator.PrototypesDb;

    public ProtoRegistrator Registrator
    {
        get;
    }

    public NuclearReactorProtoBuilder(ProtoRegistrator registrator)
        : base()
    {
        Registrator = registrator;
    }

    public State Start(string name, StaticEntityProto.ID labId)
    {
        return new State(this, labId, name);
    }
}
