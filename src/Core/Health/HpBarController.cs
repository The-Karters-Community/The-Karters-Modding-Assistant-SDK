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

[HarmonyPatch(typeof(HpBarController), nameof(HpBarController.Hit))]
public class HpBarController__Hit {
    public static void Prefix(HpBarController __instance, ref int damage, ref int playerMakingDamage, ref PixelWeaponObject.EWeaponType eWeaponType) {
        Player player = Player.FindByAntPlayer(__instance.player);
        Player authorPlayer = Player.FindByIndex((Ant_Player.EAntPlayerNumber)playerMakingDamage);

        PlayerEvent.onItemHit?.Invoke(player, damage, authorPlayer, (Item)eWeaponType);
    }

    public static void Postfix(HpBarController __instance, int damage, int playerMakingDamage, PixelWeaponObject.EWeaponType eWeaponType) {
        Player player = Player.FindByAntPlayer(__instance.player);
        Player authorPlayer = Player.FindByIndex((Ant_Player.EAntPlayerNumber)playerMakingDamage);

        PlayerEvent.onItemHitAfter?.Invoke(player, damage, authorPlayer, (Item)eWeaponType);
    }
}