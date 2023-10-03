using HarmonyLib;

namespace TheOtherRoles.Test;

public static class Test
{
    [HarmonyPatch(typeof(IntroCutscene), nameof(IntroCutscene.OnDestroy))]
    public static void Prefix()
    {
        if (Tracer.tracer != null && Tracer.tracer == PlayerControl.LocalPlayer)
            Tracer.createArrows();
    }

    [HarmonyPatch(typeof(HudManager), nameof(HudManager.Update))]
    [HarmonyPostfix]
    public static void Postfix1()
    {
        if (Tracer.tracer != null && Tracer.tracer == PlayerControl.LocalPlayer)
            Tracer.update();
    }

    [HarmonyPatch(typeof(MeetingHud), nameof(MeetingHud.Start))]
    [HarmonyPostfix]
    public static void Postfix2() => Tracer.RoundCount++;
}