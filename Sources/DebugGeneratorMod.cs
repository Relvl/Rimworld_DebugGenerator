using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace DebugGenerator;

[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
public class DebugGeneratorMod : Mod
{
    public DebugGeneratorMod(ModContentPack content) : base(content)
    {
        new Harmony("johnson1893.archotech.dev.generator")
            .PatchAll(Assembly.GetExecutingAssembly());
    }
}