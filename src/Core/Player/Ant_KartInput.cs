using HarmonyLib;
using TheKartersModdingAssistant.Event;
using TheKartersModdingAssistant.RewiredInput;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(Ant_KartInput), nameof(Ant_KartInput.ProcessRacingInput))]
public class Ant_KartInput__ProcessRacingInput {
    public static void Postfix(Ant_KartInput __instance) {
        Rewired.Player rewired = __instance.player;

        if (rewired is null) {
            return;
        }

        Player player = Player.FindByAntPlayer(__instance.antPlayer);

        Ant_KartInput__ProcessRacingInput.ProcessButtonPressed(rewired, player);
        Ant_KartInput__ProcessRacingInput.ProcessButtonHolding(rewired, player);
        Ant_KartInput__ProcessRacingInput.ProcessButtonReleased(rewired, player);
    }

    protected static void ProcessButtonPressed(Rewired.Player rewired, Player player) {
        if (rewired.GetButtonDown(Button.XboxA)) {
            PlayerInputEvent.onBottomFaceButtonPress?.Invoke(player);
        }

        if (rewired.GetButtonDown(Button.XboxB)) {
            PlayerInputEvent.onRightFaceButtonPress?.Invoke(player);
        }

        if (rewired.GetButtonDown(Button.XboxX)) {
            PlayerInputEvent.onLeftFaceButtonPress?.Invoke(player);
        }

        if (rewired.GetButtonDown(Button.XboxY)) {
            PlayerInputEvent.onTopFaceButtonPress?.Invoke(player);
        }
    }

    protected static void ProcessButtonHolding(Rewired.Player rewired, Player player) {
        if (rewired.GetButton(Button.XboxA)) {
            PlayerInputEvent.onBottomFaceButtonHold?.Invoke(player);
        }

        if (rewired.GetButton(Button.XboxB)) {
            PlayerInputEvent.onRightFaceButtonHold?.Invoke(player);
        }

        if (rewired.GetButton(Button.XboxX)) {
            PlayerInputEvent.onLeftFaceButtonHold?.Invoke(player);
        }

        if (rewired.GetButton(Button.XboxY)) {
            PlayerInputEvent.onTopFaceButtonHold?.Invoke(player);
        }
    }

    protected static void ProcessButtonReleased(Rewired.Player rewired, Player player) {
        if (rewired.GetButtonUp(Button.XboxA)) {
            PlayerInputEvent.onBottomFaceButtonRelease?.Invoke(player);
        }

        if (rewired.GetButtonUp(Button.XboxB)) {
            PlayerInputEvent.onRightFaceButtonRelease?.Invoke(player);
        }

        if (rewired.GetButtonUp(Button.XboxX)) {
            PlayerInputEvent.onLeftFaceButtonRelease?.Invoke(player);
        }

        if (rewired.GetButtonUp(Button.XboxY)) {
            PlayerInputEvent.onTopFaceButtonRelease?.Invoke(player);
        }
    }
}