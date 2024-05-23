using BepInEx;
using TheKarters2Mods;
using TheKartersModdingAssistant.Core;

namespace TheKartersModdingAssistant;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(AutoReloadConfigModSDK_BepInExInfo.PLUGIN_GUID)]
public class TheKartersModdingAssistant : AbstractPlugin {
    /// <summary>
    /// TheKartersModdingAssistant constructor.
    /// </summary>
    public TheKartersModdingAssistant(): base() {
        this.pluginGuid = MyPluginInfo.PLUGIN_GUID;
        this.pluginName = MyPluginInfo.PLUGIN_NAME;
        this.pluginVersion = MyPluginInfo.PLUGIN_VERSION;

        this.harmony = new(this.pluginGuid);
        this.logger = new(this.Log);
    }

    /// <summary>
    /// Patch all the methods with Harmony.
    /// </summary>
    public override void ProcessPatching() {
        this.harmony.PatchAll(typeof(Ant_BoostManager__BoostPadTriggerEnter));
        this.harmony.PatchAll(typeof(Ant_BoostManager__FireSliderBoost));
        this.harmony.PatchAll(typeof(Ant_BoostManager__OnKartLandedAfterPlayerTriggeredJump));
        this.harmony.PatchAll(typeof(Ant_BoostManager__WallCollisionOccuredInTimeFromLastOne));

        this.harmony.PatchAll(typeof(Ant_CurrentGameConfiguration__Start));

        this.harmony.PatchAll(typeof(Ant_MainGame__Start));
        this.harmony.PatchAll(typeof(Ant_MainGame__FixedUpdate));
        this.harmony.PatchAll(typeof(Ant_MainGame__GetGameModeRequiredLapCount));

        this.harmony.PatchAll(typeof(Ant_MainGame_Players__Start));
        this.harmony.PatchAll(typeof(Ant_MainGame_Players__ResetAndPreparePlayersToRace));

        this.harmony.PatchAll(typeof(Ant_Player__Update));

        this.harmony.PatchAll(typeof(PixelKartPhysics__FixedUpdate));
        this.harmony.PatchAll(typeof(PixelKartPhysics__JumpInputTheKarters));

        this.harmony.PatchAll(typeof(WeaponsController__WeaponBoxReward_AddWeapon));
        this.harmony.PatchAll(typeof(WeaponsController__PickupCurrentlySelectedWeapon));
        this.harmony.PatchAll(typeof(WeaponsController__Shoot));

        this.harmony.PatchAll(typeof(Ant_KartInput__ProcessRacingInput));
    }
}
