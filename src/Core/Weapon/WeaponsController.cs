using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(WeaponsController), nameof(WeaponsController.WeaponBoxReward_AddWeapon))]
public class WeaponsController__WeaponBoxReward_AddWeapon {
    public static void Prefix(WeaponsController __instance) {
        PlayerEvent.onItemPick?.Invoke(Player.FindByAntPlayer(__instance.player));
    }

    public static void Postfix(WeaponsController __instance) {
        PlayerEvent.onItemPickAfter?.Invoke(Player.FindByAntPlayer(__instance.player));
    }
}

[HarmonyPatch(typeof(WeaponsController), nameof(WeaponsController.PickupCurrentlySelectedWeapon))]
public class WeaponsController__PickupCurrentlySelectedWeapon {
    public static void Prefix(WeaponsController __instance) {
        PlayerEvent.onItemObtain?.Invoke(Player.FindByAntPlayer(__instance.player));
    }

    public static void Postfix(WeaponsController __instance) {
        PlayerEvent.onItemObtainAfter?.Invoke(Player.FindByAntPlayer(__instance.player));
    }
}

[HarmonyPatch(typeof(WeaponsController), nameof(WeaponsController.Shoot))]
public class WeaponsController__Shoot {
    public static void Prefix(WeaponsController __instance) {
        PlayerEvent.onItemUse?.Invoke(Player.FindByAntPlayer(__instance.player));
    }

    public static void Postfix(WeaponsController __instance) {
        PlayerEvent.onItemUseAfter?.Invoke(Player.FindByAntPlayer(__instance.player));
    }
}