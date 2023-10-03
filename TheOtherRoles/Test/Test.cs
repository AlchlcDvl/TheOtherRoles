using HarmonyLib;

namespace TheOtherRoles.Test;

public static class Test
{
    [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.OnDestroy))]
    public static class IntroCutsceneOnDestroyPatch
    {
        public static void Prefix()
        {
            if (Tracer.tracer != null && Tracer.tracer == PlayerControl.LocalPlayer)
                Tracer.createArrows();
        }
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    public static class HudManagerUpdatePatch
    {
        public static void Postfix()
        {
            if (Tracer.tracer != null && Tracer.tracer == PlayerControl.LocalPlayer)
                Tracer.update();
        }
    }
}