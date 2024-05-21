using System;

namespace TheKartersAssistant.Event;

public class PlayerEvent {
     // Ant_Player::Update
    public static Action<Player> onUpdate;
    public static Action<Player> onUpdateAfter;

    // Ant_BoostManager::FireSliderBoost
    public static Action<Player, int> onBoost;
    public static Action<Player, int> onBoostAfter;

    // Ant_BoostManager::WallCollisionOccuredInTimeFromLastOne
    public static Action<Player> onWallHit;
    public static Action<Player> onWallHitAfter;

    // Ant_BoostManager::BoostPadTriggerEnter
    public static Action<Player, float, float> onPadEnter;
    public static Action<Player, float, float> onPadEnterAfter;

    // Ant_BoostManager::OnKartLandedAfterPlayerTriggeredJump
    public static Action<Player, float, bool> onLand;
    public static Action<Player, float, bool> onLandAfter;

    // PixelKartPhysics::JumpInputTheKarters
    public static Action<Player> onJump;
    public static Action<Player> onJumpAfter;

    // PixelKartPhysics::FixedUpdate
    public static Action<Player> onFixedUpdate;
    public static Action<Player> onFixedUpdateAfter;
    public static Action<Player> onAir;
    public static Action<Player> onAirAfter;
    public static Action<Player> onDrift;
    public static Action<Player> onDriftAfter;
    public static Action<Player> onNewLap;

    public static Action<Player> onRaceInitialize;
    public static Action<Player> onRaceStart;

    // WeaponsController::WeaponBoxReward_AddWeapon
    public static Action<Player> onItemPick;
    public static Action<Player> onItemPickAfter;

    // WeaponsController::PickupCurrentlySelectedWeapon
    public static Action<Player> onItemObtain;
    public static Action<Player> onItemObtainAfter;

    // WeaponsController::Shoot
    public static Action<Player> onItemUse;
    public static Action<Player> onItemUseAfter;
}