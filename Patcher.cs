using HarmonyLib;
using TheKartersAssistant.Core;

namespace TheKartersAssistant;

public class Patcher {
    protected readonly static Harmony Harmony = new(MyPluginInfo.PLUGIN_GUID);

    public static void Patch(TheKartersAssistant plugin) {
        if (plugin == null) {
            Logger.Error($"Plugin not found while patching, {MyPluginInfo.PLUGIN_NAME} can't be loaded properly.");

            return;
        }

        Patcher.Harmony.PatchAll(typeof(Ant_BoostManager__BoostPadTriggerEnter));
        Patcher.Harmony.PatchAll(typeof(Ant_BoostManager__FireSliderBoost));
        Patcher.Harmony.PatchAll(typeof(Ant_BoostManager__OnKartLandedAfterPlayerTriggeredJump));
        Patcher.Harmony.PatchAll(typeof(Ant_BoostManager__WallCollisionOccuredInTimeFromLastOne));

        Patcher.Harmony.PatchAll(typeof(Ant_CurrentGameConfiguration__Start));

        Patcher.Harmony.PatchAll(typeof(Ant_MainGame__Start));
        Patcher.Harmony.PatchAll(typeof(Ant_MainGame__FixedUpdate));
        Patcher.Harmony.PatchAll(typeof(Ant_MainGame__GetGameModeRequiredLapCount));
        Patcher.Harmony.PatchAll(typeof(Ant_MainGame__StartAndInitializeRace_Coroutine));

        Patcher.Harmony.PatchAll(typeof(Ant_MainGame_Players__Start));

        Patcher.Harmony.PatchAll(typeof(Ant_Player__Update));

        Patcher.Harmony.PatchAll(typeof(PixelKartPhysics__FixedUpdate));
        Patcher.Harmony.PatchAll(typeof(PixelKartPhysics__JumpInputTheKarters));

        Patcher.Harmony.PatchAll(typeof(WeaponsController__WeaponBoxReward_AddWeapon));
        Patcher.Harmony.PatchAll(typeof(WeaponsController__PickupCurrentlySelectedWeapon));
        Patcher.Harmony.PatchAll(typeof(WeaponsController__Shoot));

        Patcher.Harmony.PatchAll(typeof(Ant_KartInput__ProcessRacingInput));
    }

    public static void Unpatch(TheKartersAssistant plugin) {
        if (plugin == null) {
            Logger.Error($"Plugin not found while unpatching, {MyPluginInfo.PLUGIN_NAME} can't be loaded properly.");

            return;
        }

        Patcher.Harmony.UnpatchSelf();
    }
}