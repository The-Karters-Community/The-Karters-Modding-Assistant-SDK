using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(HpBarController), nameof(HpBarController.RefillHp))]
public class HpBarController__RefillHp {
    public static void Prefix(HpBarController __instance, ref int hp, ref bool overdrive) {
        Player player = Player.FindByAntPlayer(__instance.player);

        PlayerEvent.onHeal?.Invoke(player, hp, overdrive);
    }

    public static void Postfix(HpBarController __instance, int hp, bool overdrive) {
        Player player = Player.FindByAntPlayer(__instance.player);

        PlayerEvent.onHealAfter?.Invoke(player, hp, overdrive);
    }
}