using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(PixelKartPhysics), nameof(PixelKartPhysics.FixedUpdate))]
public class PixelKartPhysics__FixedUpdate {
    public static void Prefix(PixelKartPhysics __instance) {
        Player player = Player.FindByAntPlayer(__instance.kartController.parentPlayer);

        if (__instance is null || player is null) {
            return;
        }

        PlayerEvent.onFixedUpdate?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));

        if (player.HasJustPassedFinishLine()) {
            PlayerEvent.onNewLap?.Invoke(player);
        }

        player.SetPreviousLapCount(player.GetCurrentLapCount());

        if (!player.IsGrounded()) {
            PlayerEvent.onAir?.Invoke(player);
        }

        if (player.IsDrifting()) {
            PlayerEvent.onDrift?.Invoke(player);
        }
    }

    public static void Postfix(PixelKartPhysics __instance) {
        Player player = Player.FindByAntPlayer(__instance.kartController.parentPlayer);

        if (__instance is null || player is null) {
            return;
        }

        PlayerEvent.onFixedUpdateAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }
}

[HarmonyPatch(typeof(PixelKartPhysics), nameof(PixelKartPhysics.JumpInputTheKarters))]
public class PixelKartPhysics__JumpInputTheKarters {
    public static void Prefix(PixelKartPhysics __instance, ref bool bJump) {
        if (!bJump) {
            return;
        }

        PlayerEvent.onJump?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }

    public static void Postfix(PixelKartPhysics __instance, bool bJump) {
        if (!bJump) {
            return;
        }

        PlayerEvent.onJumpAfter?.Invoke(Player.FindByAntPlayer(__instance.kartController.parentPlayer));
    }

}