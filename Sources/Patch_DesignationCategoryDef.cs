using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using RimWorld;
using Verse;

namespace DebugGenerator;

[HarmonyPatch(typeof(DesignationCategoryDef))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "UnusedType.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public static class Patch_DesignationCategoryDef
{
    [HarmonyPostfix]
    [HarmonyPatch("ResolveDesignators")]
    public static void ResolveDesignators_Postfix(List<Designator> ___resolvedDesignators)
    {
        for (var i = 0; i < ___resolvedDesignators.Count; i++)
        {
            var designator = ___resolvedDesignators[i];
            if (designator is DesignatorBuildGodModeOnly) continue;
            if (designator is not Designator_Build buildDesignator) continue;
            if (buildDesignator.PlacingDef is not ThingDef thingDef) continue;
            if (!thingDef.HasModExtension<GodModeOnlyExtension>()) continue;
            ___resolvedDesignators[i] = new DesignatorBuildGodModeOnly(thingDef);
        }
    }
}