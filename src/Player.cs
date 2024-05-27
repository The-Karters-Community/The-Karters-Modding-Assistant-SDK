using System.Collections.Generic;

namespace TheKartersModdingAssistant;

public class Player {
    public static List<Player> players;

    // Unity object references
    public Ant_Player uAntPlayer;
    public HpBarController uHpBarController;
    public Ant_BoostManager uAntBoostManager;
    public PixelEasyCharMoveKartController uPixelEasyCharMoveKartController;
    public PixelKartPhysics uPixelKartPhysics;
    public PlayerRaceLogic uPlayerRaceLogic;
    public VisualInstanceSyncedParams uVisualInstanceSyncedParams;
    public AIControllerManager uAiControllerManager;
    public AILogicController uAiLogicController;
    public AIDistToTargetBehavController uAiDistToTargetBehavController;
    public WeaponsController uWeaponsController;
    public PTK_WeaponsAndAmunitionManager uPtkWeaponsAndAmunitionManager;

    // CUSTOM
    protected Dictionary<string, object> custom = new();
    protected int currentBoostNumber = 1;
    protected int previousLapCount = 1;

    /// <summary>
    /// Get all players.
    /// </summary>
    /// 
    /// <returns>List<Player></returns>
    public static List<Player> GetPlayers() {
        return Player.players;
    }

    /// <summary>
    /// Get all active players.
    /// </summary>
    /// 
    /// <returns>List<Player></returns>
    public static List<Player> GetActivePlayers() {
        List<Player> players = new();

        foreach (Player player in Player.players) {
            if (!player.IsDisabled()) {
                players.Add(player);
            }
        }

        return players;
    }

    /// <summary>
    /// Get all active players sorted by position.
    /// </summary>
    /// 
    /// <returns>List<Player></returns>
    public static List<Player> GetPlayersSortedByPosition() {
        List<Player> players = Player.GetActivePlayers();

        players.Sort((Player a, Player b) => a.GetPosition() - b.GetPosition());

        return players;
    }

    public static Player FindByIndex(Ant_Player.EAntPlayerNumber index) {
        foreach (Player p in Player.players) {
            if (p.GetIndex() == index) {
                return p;
            }
        }

        return null;
    }

    public static Player FindByAntPlayer(Ant_Player antPlayer) {
        return Player.FindByIndex(antPlayer.eAntPlayerNr);
    }

    public Player(Ant_Player unityObject) {
        this.uAntPlayer = unityObject;
        this.uHpBarController = this.uAntPlayer.hpBarController;
        this.uAntBoostManager = this.uAntPlayer.aiController.aiDistController.boostManager;
        this.uPixelEasyCharMoveKartController = this.uAntBoostManager.kartController;
        this.uPixelKartPhysics = this.uPixelEasyCharMoveKartController.kartPhysics;
        this.uPlayerRaceLogic = this.uAntPlayer.playerRaceLogic;
        this.uVisualInstanceSyncedParams = this.uAntPlayer.visualInstanceSyncedParams;
        this.uAiControllerManager = this.uAntPlayer.aiController;
        this.uAiLogicController = this.uAiControllerManager.aiLogicDrivingController;
        this.uAiDistToTargetBehavController = this.uAiControllerManager.aiDistController;
        this.uWeaponsController = this.uAntPlayer.weaponsController;
        this.uPtkWeaponsAndAmunitionManager = this.uWeaponsController.weaponsAndAmmoManager;
    }

    /// <summary>
    /// Get the index of the player.
    /// </summary>
    /// 
    /// <returns>Ant_Player.EAntPlayerNumber</returns>
    public Ant_Player.EAntPlayerNumber GetIndex() {
        return this.uAntPlayer.eAntPlayerNr;
    }

    /// <summary>
    /// Tell whether the player is of the given type.
    /// </summary>
    /// 
    /// <param name="type">Ant_Player.EPlayerType</param>
    /// <returns>bool</returns>
    public bool IsOfType(Ant_Player.EPlayerType type) {
        return this.uAntPlayer.ePlayerType == type;
    }

    /// <summary>
    /// Set the type of the player.
    /// </summary>
    /// 
    /// <param name="type">Ant_Player.EPlayerType</param>
    /// <returns>Player</returns>
    public Player SetType(Ant_Player.EPlayerType type) {
        this.uAntPlayer.ePlayerType = type;

        return this;
    }

    /// <summary>
    /// Tell whether the player is disabled.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsDisabled() {
        return this.IsOfType(Ant_Player.EPlayerType.E_DISABLED);
    }

    /// <summary>
    /// Disable the player.
    /// </summary>
    /// 
    /// <returns>Player</returns>
    public Player Disable() {
        this.uAntPlayer.DisablePlayer();

        return this;
        //return this.SetType(Ant_Player.EPlayerType.E_DISABLED);
    }

    /// <summary>
    /// Tell whether the player is an AI.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsAi() {
        return this.IsOfType(Ant_Player.EPlayerType.E_AI);
    }

    /// <summary>
    /// Tell whether the player is controlled by an AI.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsControlledByAi() {
        return this.IsAi() || this.uAntPlayer.bDebugHumanControllableByAIEditorForced;
    }

    /// <summary>
    /// Set whether the player is controlled by an AI.
    /// </summary>
    /// 
    /// <param name="isControlledByAi">bool</param>
    /// <returns>Player</returns>
    public Player IsControlledByAi(bool isControlledByAi) {
        this.uAntPlayer.bDebugHumanControllableByAIEditorForced = isControlledByAi;

        return this;
    }

    /// <summary>
    /// Get the AI type.
    /// </summary>
    /// 
    /// <returns>AIDistToTargetBehavController.EAI_PLAYER_TYPE</returns>
    public AIDistToTargetBehavController.EAI_PLAYER_TYPE GetAiType() {
        return this.uAiDistToTargetBehavController.eAIPlayerType;
    }

    /// <summary>
    /// Set the AI type.
    /// </summary>
    /// 
    /// <param name="aiType">AIDistToTargetBehavController.EAI_PLAYER_TYPE</param>
    /// <returns>Player</returns>
    public Player SetAiType(AIDistToTargetBehavController.EAI_PLAYER_TYPE aiType) {
        this.uAiDistToTargetBehavController.eAIPlayerType = aiType;
        
        return this;
    }

    /// <summary>
    /// Get the AI driving state.
    /// </summary>
    /// 
    /// <returns>AIDistToTargetBehavController.ECurrentDrivingState</returns>
    public AIDistToTargetBehavController.ECurrentDrivingState GetAiDrivingState() {
        return this.uAiDistToTargetBehavController.eDrivingState;
    }

    /// <summary>
    /// Set the AI driving state.
    /// </summary>
    /// 
    /// <param name="aiDrivingState">AIDistToTargetBehavController.ECurrentDrivingState</param>
    /// <returns>Player</returns>
    public Player SetAiDrivingState(AIDistToTargetBehavController.ECurrentDrivingState aiDrivingState) {
        this.uAiDistToTargetBehavController.eDrivingState = aiDrivingState;

        return this;
    }

    /// <summary>
    /// Tell whether the player is a Time Trial ghost.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsTimeTrialGhost() {
        return this.IsOfType(Ant_Player.EPlayerType.E_GHOST_TIME_TRIAL);
    }

    /// <summary>
    /// Tell whether the player is a human.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsHuman() {
        return this.IsOfType(Ant_Player.EPlayerType.E_HUMAN);
    }

    /// <summary>
    /// Get the name.
    /// </summary>
    /// 
    /// <returns>string</returns>
    public string GetName() {
        return this.uAntPlayer.GetPlayerName();
    }

    /// <summary>
    /// Set the name.
    /// </summary>
    /// 
    /// <param name="name">string</param>
    /// <returns>Player</returns>
    public Player SetName(string name) {
        this.uAntPlayer.SetPlayerName(name);

        return this;
    }

    /// <summary>
    /// Get current health points.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetCurrentHealth() {
        return this.uHpBarController.currentHp;
    }

    /// <summary>
    /// Set current health points.
    /// </summary>
    /// 
    /// <param name="currentHealth">int</param>
    /// <returns>Player</returns>
    public Player SetCurrentHealth(int currentHealth) {
        this.uHpBarController.currentHp = currentHealth;

        // This method run some processes like death if HP is below 0.
        this.uHpBarController.CheckHp();

        return this;
    }

    /// <summary>
    /// Get maximum health points.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetMaximumHealth() {
        return this.uHpBarController.maxHp_Default;
    }

    /// <summary>
    /// Set maximum health points.
    /// </summary>
    /// 
    /// <param name="maximumHealth">int</param>
    /// <returns>Player</returns>
    public Player SetMaximumHealth(int maximumHealth) {
        this.uHpBarController.maxHp_Default = maximumHealth;

        return this;
    }

    /// <summary>
    /// Get maximum extra health points.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetMaximumExtraHealth() {
        return this.uHpBarController.maxHpWithExtraOverflow;
    }

    /// <summary>
    /// Set maximum extra health points.
    /// </summary>
    /// 
    /// <param name="maximumExtraHealth">int</param>
    /// <returns>Player</returns>
    public Player SetMaximumExtraHealth(int maximumExtraHealth) {
        this.uHpBarController.maxHpWithExtraOverflow = maximumExtraHealth;

        return this;
    }

    /// <summary>
    /// Get the progress of the given boost.
    /// </summary>
    /// 
    /// <param name="boostNumber">int</param>
    /// <param name="clamped">bool</param>
    /// <returns>float</returns>
    public float GetBoostProgress(int boostNumber, bool clamped = false) {
        int boostIndex = boostNumber - 1;

        if (clamped) {
            return this.uAntBoostManager.fCurrentBoostFillTime[boostIndex];
        }

        return this.uAntBoostManager.fCurrentBoostFillTime_NotClampedTimeSinceLoading[boostIndex];
    }

    /// <summary>
    /// Get the current boost number.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetCurrentBoostNumber() {
        //return this.uAntBoostManager.iCurrentBoosterNumberCount;
        return this.currentBoostNumber;
    }

    /// <summary>
    /// Set the current boost number.
    /// </summary>
    /// 
    /// <param name="currentBoostNumber">int</param>
    /// <returns>Player</returns>
    public Player SetCurrentBoostNumber(int currentBoostNumber) {
        //this.uAntBoostManager.iCurrentBoosterNumberCount = currentBoostNumber;
        this.currentBoostNumber = currentBoostNumber;
        
        if (this.currentBoostNumber < 0 || this.currentBoostNumber > 3) {
            this.currentBoostNumber = 1;
        }

        return this;
    }

    /// <summary>
    /// Increase the current boost number by one.
    /// </summary>
    /// 
    /// <returns>Player</returns>
    public Player IncreaseCurrentBoostNumber() {
        return this.SetCurrentBoostNumber(this.GetCurrentBoostNumber() + 1);
    }

    /// <summary>
    /// Get the current progression of the boost.
    /// </summary>
    /// 
    /// <param name="clamped">bool</param>
    /// <returns>float</returns>
    public float GetCurrentBoostProgress(bool clamped = false) {
        return this.GetBoostProgress(this.GetCurrentBoostNumber(), clamped);
    }

    /// <summary>
    /// Get the current amount of reserve.
    /// </summary>
    /// 
    /// <returns>float</returns>
    public float GetCurrentReserve() {
        return this.uAntBoostManager.fBoostingReserves;
    }

    /// <summary>
    /// Set the current amount of reserve.
    /// </summary>
    /// 
    /// <param name="currentReserve">float</param>
    /// <returns>Player</returns>
    public Player SetCurrentReserve(float currentReserve) {
        this.uAntBoostManager.fBoostingReserves = currentReserve;

        return this;
    }

    /// <summary>
    /// Incrase the current amount of reserve.
    /// </summary>
    /// 
    /// <param name="reserve">float</param>
    /// <returns>Player</returns>
    public Player IncreaseCurrentReserve(float reserve) {
        return this.SetCurrentReserve(this.GetCurrentReserve() + reserve);
    }

    /// <summary>
    /// Decrease the current amount of reserve.
    /// </summary>
    /// 
    /// <param name="reserve">float</param>
    /// <returns>Player</returns>
    public Player DecreaseCurrentReserve(float reserve) {
        return this.IncreaseCurrentReserve(-reserve);
    }

    /// <summary>
    /// Get the current amount of reserve in percentage.
    /// </summary>
    /// 
    /// <returns>float</returns>
    public float GetCurrentReserveInPercentage() {
        return this.uPixelKartPhysics.GetCurrentEngineSpeedPowerWithReservesPercentageInfo();
    }

    /// <summary>
    /// Get the current speed ignoring physics.
    /// </summary>
    /// 
    /// <returns>float</returns>
    public float GetCurrentSpeed() {
        return this.uPixelKartPhysics.GetKartSpeedXZ();
    }

    /// <summary>
    /// Tell whether the player is grounded.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsGrounded() {
        return this.uPixelEasyCharMoveKartController.IsGrounded_Stable();
    }

    /// <summary>
    /// Tell whether the player is in air.
    /// </summary>
    /// 
    /// <returns></returns>
    public bool IsInAir() {
        return !this.IsGrounded();
    }

    /// <summary>
    /// Get the amount of time the player has been in air in seconds.
    /// </summary>
    /// 
    /// <returns>float</returns>
    public float GetTimeInAir() {
        return this.uPixelKartPhysics.fTimeInAir;
    }

    /// <summary>
    /// Tell whether the player is drifting.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsDrifting() {
        return this.uPixelKartPhysics.bIsDrifting;
    }

    /// <summary>
    /// Make the player stop drifting.
    /// </summary>
    /// 
    /// <returns>Player</returns>
    public Player StopDrift() {
        this.uPixelKartPhysics.StopDrifting();
        this.SetCurrentBoostNumber(1);

        return this;
    }

    /// <summary>
    /// Tell whether the player is braking.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsBraking() {
        return this.uPixelKartPhysics.bIsBreakingInput;
    }

    /// <summary>
    /// Tell whether the player is respawning.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsRespawning() {
        return this.uAntPlayer.visualInstanceSyncedParams.bIsPlayerRespawning;
    }

    /// <summary>
    /// Get the previous lap count.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetPreviousLapCount() {
        return this.previousLapCount;
    }

    /// <summary>
    /// Set the previous lap count.
    /// </summary>
    /// 
    /// <param name="previousLapCount">int</param>
    /// <returns>Player</returns>
    public Player SetPreviousLapCount(int previousLapCount) {
        this.previousLapCount = previousLapCount;

        return this;
    }

    /// <summary>
    /// Get the current lap count.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetCurrentLapCount() {
        return this.uPlayerRaceLogic.iPlayerMovedThroughFinishLineCount;
    }

    /// <summary>
    /// Set the current lap count.
    /// </summary>
    /// 
    /// <param name="currentLapCount">int</param>
    /// <returns>Player</returns>
    public Player SetCurrentLapCount(int currentLapCount) {
        this.uPlayerRaceLogic.iPlayerMovedThroughFinishLineCount = currentLapCount;

        return this;
    }

    /// <summary>
    /// Tell whether the player has just passed the finish line.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool HasJustPassedFinishLine() {
        return this.GetPreviousLapCount() != this.GetCurrentLapCount();
    }

    /// <summary>
    /// Get the position of the player.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetPosition() {
        return this.uPlayerRaceLogic.iPlayerRacePositionIndex + 1;
    }

    /// <summary>
    /// Set the position of the player.
    /// </summary>
    /// 
    /// <param name="position">int</param>
    /// <returns>Player</returns>
    public Player SetPosition(int position) {
        this.uPlayerRaceLogic.iPlayerRacePositionIndex = position - 1;

        return this;
    }

    /// <summary>
    /// Get the main weapon.
    /// </summary>
    /// 
    /// <returns>PixelWeaponObject.EWeaponType|null</returns>
    public PixelWeaponObject.EWeaponType? GetMainWeaponType() {
        return this.uWeaponsController?.currentWeapon?.eWeaponType;
    }

    /// <summary>
    /// Get the main weapon amount of ammunitions.
    /// </summary>
    /// 
    /// <returns>int</returns>
    public int GetMainWeaponAmmo() {
        PixelWeaponObject.EWeaponType? mainWeaponType = this.GetMainWeaponType();

        if (mainWeaponType is null) {
            return 0;
        }

        return this.uPtkWeaponsAndAmunitionManager.GetCurrentAmmoCount((PixelWeaponObject.EWeaponType)mainWeaponType);
    }

    /// <summary>
    /// Tell whether the player has a main weapon.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool HasMainWeapon() {
        PixelWeaponObject.EWeaponType? mainWeaponType = this.GetMainWeaponType();
        int mainWeaponAmmo = this.GetMainWeaponAmmo();

        return mainWeaponType != PixelWeaponObject.EWeaponType.__DISABLED
            && mainWeaponType != PixelWeaponObject.EWeaponType.__WEAPONS_COUNT
            && mainWeaponType is not null
            && mainWeaponAmmo > 0;
    }

    /// <summary>
    /// Set the type of the main weapon.
    /// </summary>
    /// 
    /// <param name="mainWeaponType|null">PixelWeaponObject.EWeaponType</param>
    /// <returns>Player</returns>
    public Player SetMainWeaponType(PixelWeaponObject.EWeaponType? mainWeaponType) {
        this.SetMainWeaponAmmo(0);

        if (mainWeaponType is null
            || mainWeaponType == PixelWeaponObject.EWeaponType.__DISABLED
            || mainWeaponType == PixelWeaponObject.EWeaponType.__WEAPONS_COUNT) {
            this.uWeaponsController.currentWeapon.eWeaponType = PixelWeaponObject.EWeaponType.__WEAPONS_COUNT;
            return this;
        }
        
        this.uWeaponsController.currentWeapon.eWeaponType = (PixelWeaponObject.EWeaponType)mainWeaponType;
        this.IncreaseMainWeaponAmmo();

        return this;
    }

    /// <summary>
    /// Set the amount of ammunition of the main weapon.
    /// </summary>
    /// 
    /// <param name="mainWeaponAmmo">int</param>
    /// <returns>Player</returns>
    public Player SetMainWeaponAmmo(int mainWeaponAmmo) {
        PixelWeaponObject.EWeaponType? mainWeaponType = this.GetMainWeaponType();

        if (mainWeaponType is null) {
            return this;
        }

        this.uPtkWeaponsAndAmunitionManager.dWeaponToAmmoCountDictionary[(int)mainWeaponType] = mainWeaponAmmo;

        return this;
    }

    /// <summary>
    /// Increase the amount of ammunition of the main weapon.
    /// </summary>
    /// 
    /// <param name="ammo">int</param>
    /// <returns>Player</returns>
    public Player IncreaseMainWeaponAmmo(int ammo = 1) {
        return this.SetMainWeaponAmmo(this.GetMainWeaponAmmo() + ammo);
    }

    /// <summary>
    /// Set the main weapon.
    /// </summary>
    /// 
    /// <param name="mainWeaponType">PixelWeaponObject.EWeaponType</param>
    /// <param name="mainWeaponAmmo">int</param>
    /// <returns>Player</returns>
    public Player SetMainWeapon(PixelWeaponObject.EWeaponType? mainWeaponType, int mainWeaponAmmo = 1) {
        return this.SetMainWeaponType(mainWeaponType).SetMainWeaponAmmo(mainWeaponAmmo);
    }

    /// <summary>
    /// Get the secondary weapon.
    /// </summary>
    /// 
    /// <returns>PixelWeaponObject.EWeaponType</returns>
    /*public PixelWeaponObject.EWeaponType GetSecondaryWeaponType() {
        return this.uWeaponsController.itemFromBoxNr_2;
    }*/

    /// <summary>
    /// Get the secondary weapon amount of ammunitions.
    /// </summary>
    /// 
    /// <returns>int</returns>
    /*public int GetSecondaryWeaponAmmo() {
        return this.uPtkWeaponsAndAmunitionManager.GetCurrentAmmoCount(this.GetSecondaryWeaponType());
    }*/

    /// <summary>
    /// Set the type of the secondary weapon.
    /// </summary>
    /// 
    /// <param name="mainWeaponType">PixelWeaponObject.EWeaponType</param>
    /// <returns>Player</returns>
    /*public Player SetSecondaryWeaponType(PixelWeaponObject.EWeaponType mainWeaponType) {
        this.SetSecondaryWeaponAmmo(0);
        this.uWeaponsController.itemFromBoxNr_2 = mainWeaponType;
        this.SetSecondaryWeaponAmmo(1);

        return this;
    }*/

    /// <summary>
    /// Set the amount of ammunition of the secondary weapon.
    /// </summary>
    /// 
    /// <param name="secondaryWeaponAmmo">int</param>
    /// <returns>Player</returns>
    /*public Player SetSecondaryWeaponAmmo(int secondaryWeaponAmmo) {
        PixelWeaponObject.EWeaponType secondaryWeaponType = this.GetSecondaryWeaponType();

        if (secondaryWeaponType == PixelWeaponObject.EWeaponType.__DISABLED || secondaryWeaponType == PixelWeaponObject.EWeaponType.__WEAPONS_COUNT) {
            return this;
        }

        this.uPtkWeaponsAndAmunitionManager.dWeaponToAmmoCountDictionary[(int)secondaryWeaponType] = secondaryWeaponAmmo;

        return this;
    }*/

    /// <summary>
    /// Increase the amount of ammunition of the secondary weapon.
    /// </summary>
    /// 
    /// <param name="ammo">int</param>
    /// <returns>Player</returns>
    /*public Player IncreaseSecondaryWeaponAmmo(int ammo = 1) {
        return this.SetSecondaryWeaponAmmo(this.GetSecondaryWeaponAmmo() + ammo);
    }*/

    /// <summary>
    /// Set the secondary weapon.
    /// </summary>
    /// 
    /// <param name="secondaryWeaponType">PixelWeaponObject.EWeaponType</param>
    /// <param name="secondaryWeaponAmmo">int</param>
    /// <returns>Player</returns>
    /*public Player SetSecondaryWeapon(PixelWeaponObject.EWeaponType secondaryWeaponType, int secondaryWeaponAmmo = 1) {
        return this.SetSecondaryWeaponType(secondaryWeaponType).SetSecondaryWeaponAmmo(secondaryWeaponAmmo);
    }*/

    /// <summary>
    /// Set the two weapons.
    /// </summary>
    /// 
    /// <param name="mainWeaponType">PixelWeaponObject.EWeaponType</param>
    /// <param name="mainWeaponAmmo">int</param>
    /// <param name="secondaryWeaponType">PixelWeaponObject.EWeaponType</param>
    /// <param name="secondaryWeaponAmmo">int</param>
    /// <returns>Player</returns>
    /*public Player SetWeapons(PixelWeaponObject.EWeaponType mainWeaponType, PixelWeaponObject.EWeaponType secondaryWeaponType, int mainWeaponAmmo = 1, int secondaryWeaponAmmo = 1) {
        this.SetMainWeapon(mainWeaponType, mainWeaponAmmo);
        this.SetSecondaryWeapon(secondaryWeaponType, secondaryWeaponAmmo);
        
        return this;
    }*/

    /*public Player SwitchWeapons() {
        PixelWeaponObject.EWeaponType mainWeaponType = this.GetMainWeaponType();
        int mainWeaponAmmo = this.GetMainWeaponAmmo();

        PixelWeaponObject.EWeaponType secondaryWeaponType = this.GetSecondaryWeaponType();
        int secondaryWeaponAmmo = this.GetSecondaryWeaponAmmo();

        return this.SetWeapons(secondaryWeaponType, mainWeaponType, secondaryWeaponAmmo, mainWeaponAmmo);
    }*/

    /// <summary>
    /// Get all custom data.
    /// </summary>
    /// 
    /// <returns>Dictionary<string, object></returns>
    public Dictionary<string, object> GetCustomData() {
        return this.custom;
    }

    /// <summary>
    /// Set custom data.
    /// </summary>
    /// 
    /// <param name="custom">Dictionary<string, object></param>
    /// <returns>Player</returns>
    public Player SetCustomData(Dictionary<string, object> custom) {
        this.custom = custom;
        
        return this;
    }

    /// <summary>
    /// Get the value associated to the given key, or the default value if none.
    /// </summary>
    /// 
    /// <param name="key">string</param>
    /// <param name="defaultValue">object</param>
    /// <returns>object</returns>
    public object Get(string key, object defaultValue) {
        if (!this.Has(key)) {
            return defaultValue;
        }

        return this.GetCustomData()[key];
    }

    /// <summary>
    /// Tell whether a value associated to the given key exists.
    /// </summary>
    /// 
    /// <param name="key">string</param>
    /// <returns>bool</returns>
    public bool Has(string key) {
        return this.GetCustomData().ContainsKey(key);
    }

    /// <summary>
    /// Set the value associated to the given key
    /// </summary>
    /// 
    /// <param name="key">string</param>
    /// <param name="value">object</param>
    /// <returns>Player</returns>
    public Player Set(string key, object value) {
        Dictionary<string, object> customData = this.GetCustomData();

        customData[key] = value;

        return this.SetCustomData(customData);
    }

    /// <summary>
    /// Unset the value associated to the given key.
    /// </summary>
    /// *
    /// <param name="key">string</param>
    /// <returns>Player</returns>
    public Player Unset(string key) {
        Dictionary<string, object> customData = this.GetCustomData();

        customData.Remove(key);

        return this.SetCustomData(customData);
    }
}