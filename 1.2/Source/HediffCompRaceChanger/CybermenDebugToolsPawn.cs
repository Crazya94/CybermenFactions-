using System.Linq;
using RimWorld;
 
namespace Verse
{
    public static class CybermenDebugToolsPawn
    {
        [DebugAction("Pawns", null, actionType = DebugActionType.ToolMapForPawns, allowedGameStates = AllowedGameStates.PlayingOnMap)]
        private static void InstallCyberUpgrade(Pawn p)
        {
            if (!p.RaceProps.Humanlike)
            {
                Log.Error("Not Humanlike, Unsuitable cadidate");
                return;
            }
            if (!p.def.defName.Contains("Human"))
            {
                Log.Error("Not Human, Unsuitable cadidate");
                return;
            }
            HediffDef hediffDef = DefDatabase<HediffDef>.GetNamed("Cyberupgradekit");
            BodyPartRecord bodyPartRecord =
               (from x in p.health.hediffSet.GetNotMissingParts(BodyPartHeight.Undefined, BodyPartDepth.Undefined, null, null)
                                        where !x.def.conceptual && x.def == BodyPartDefOf.Torso
                select x).First<BodyPartRecord>();
            p.health.AddHediff(hediffDef, bodyPartRecord, null, null);
        }
        
    }
}
