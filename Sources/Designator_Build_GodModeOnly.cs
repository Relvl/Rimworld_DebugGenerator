using RimWorld;
using Verse;

namespace DebugGenerator;

public class DesignatorBuildGodModeOnly(BuildableDef ent) : Designator_Build(ent)
{
    public override bool Visible => DebugSettings.godMode;
}