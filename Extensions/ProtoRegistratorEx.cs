using Mafi.Core.Mods;

public static class ProtoRegistratorEx
{
    public static NuclearReactorProtoBuilder NuclearReactorProtoBuilder(this ProtoRegistrator registrator) => new NuclearReactorProtoBuilder(registrator);
}
