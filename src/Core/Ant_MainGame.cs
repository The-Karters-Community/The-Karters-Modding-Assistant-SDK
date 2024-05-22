using System;
using HarmonyLib;
using TheKartersModdingAssistant.Event;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(Ant_MainGame), nameof(Ant_MainGame.Start))]
public class Ant_MainGame__Start {
    public static void Prefix(Ant_MainGame __instance) {
        Action onRaceStart = () => {
            GameEvent.onRaceStart?.Invoke();

            foreach (Player player in Player.GetActivePlayers()) {
                PlayerEvent.onRaceStart?.Invoke(player);
            }
        };

        __instance.OnRaceCountdownJustEnded_JustStartedRace += onRaceStart;
    }
}

[HarmonyPatch(typeof(Ant_MainGame), nameof(Ant_MainGame.FixedUpdate))]
public class Ant_MainGame__FixedUpdate {
    public static void Prefix() {
        //float time = GameEvent.Get().GetTotalTime();

        // At first frame of race start, time should ~0,0049991608.
        /*if (time > 0.004f && time < 0.005f) {
            GameEvent.onRaceStart?.Invoke();
        }*/

        GameEvent.onRaceUpdate?.Invoke();
    }
}

[HarmonyPatch(typeof(Ant_MainGame), nameof(Ant_MainGame.GetGameModeRequiredLapCount))]
public class Ant_MainGame__GetGameModeRequiredLapCount {
    public static void Postfix(ref int __result) {
        __result = Game.Get().GetAmountOfLaps();
    }
}

[HarmonyPatch(typeof(Ant_MainGame), nameof(Ant_MainGame.StartAndInitializeRace_Coroutine))]
public class Ant_MainGame__StartAndInitializeRace_Coroutine {
    public static void Postfix() {
        GameEvent.onRaceInitialize?.Invoke();

        foreach (Player player in Player.GetActivePlayers()) {
                PlayerEvent.onRaceInitialize?.Invoke(player);
            }
    }
}