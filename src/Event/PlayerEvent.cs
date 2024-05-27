using System;

namespace TheKartersModdingAssistant.Event;

public class PlayerEvent {
     // Ant_Player::Update
    public static Action<Player> onUpdate;
    public static Action<Player> onUpdateAfter;

    // Ant_BoostManager::FireSliderBoost
    public static Action<Player> onBoost;
    public static Action<Player> onBoostAfter;

    // Ant_BoostManager::WallCollisionOccuredInTimeFromLastOne
    public static Action<Player> onWallHit;
    public static Action<Player> onWallHitAfter;

    // Ant_BoostManager::BoostPadTriggerEnter
    public static Action<Player, float, float> onPadEnter;
    public static Action<Player, float, float> onPadEnterAfter;

    // Ant_BoostManager::OnKartLandedAfterPlayerTriggeredJump
    public static Action<Player, bool> onLand;
    public static Action<Player, bool> onLandAfter;

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

    // Ant_MainGame::StartAndInitializeRace_Coroutine
    public static Action<Player> onRaceInitialize;

    // Ant_MainGame::Start
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

    // HpBarController::Hit
    public static Action<Player, int, Player, Item> onItemHit;
    public static Action<Player, int, Player, Item> onItemHitAfter;

    // HpBarController::RefillHp
    public static Action<Player, int, bool> onHeal;
    public static Action<Player, int, bool> onHealAfter;

    // HpBarController::Death
    public static Action<Player> onDeath;
    public static Action<Player> onDeathAfter;
}