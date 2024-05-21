namespace TheKartersAssistant;

public class Game {
    // CUSTOM
    public static Game Instance = null;

    public int amountOfLaps = 3;

    public static Game Get() {
        if (Game.Instance is null) {
            Game.Instance = new Game();
        }

        return Game.Instance;
    }

    public Ant_CurrentGameConfiguration.ERaceState GetRaceState() {
        return Ant_CurrentGameConfiguration.eCurrentRaceState;
    }

    public bool IsRaceState(Ant_CurrentGameConfiguration.ERaceState raceState) {
        return Ant_CurrentGameConfiguration.eCurrentRaceState == raceState;
    }

    public bool IsRaceCountingBeforeStart() {
        return this.IsRaceState(Ant_CurrentGameConfiguration.ERaceState.E_321_COUNTING_BEFORE_RACE);
    }

    public bool IsRaceStarted() {
        return this.IsRaceState(Ant_CurrentGameConfiguration.ERaceState.E_RACE_RUNNING);
    }

    public Ant_GameEnums.EGAMEMODE_TYPE GetGameMode() {
        return Ant_CurrentGameConfiguration.eGameModeType;
    }

    public Game SetGameMode(Ant_GameEnums.EGAMEMODE_TYPE gameMode) {
        Ant_CurrentGameConfiguration.finalChoosedGameModeConfig[(int) Ant_CurrentGameConfiguration.iGameCurrentCupRoundIndex].pixelSerializedData.eGameModeConfig_GameMode = gameMode;

        return this;
    }

    public PTK_AIPlayersDifficultyManager.EDifficultyType GetDifficulty() {
        return Ant_CurrentGameConfiguration.eAIDifficulty;
    }

    public Game SetDifficulty(PTK_AIPlayersDifficultyManager.EDifficultyType difficulty) {
        Ant_CurrentGameConfiguration.eAIDifficulty = difficulty;

        return this;
    }

    public int GetAmountOfLaps() {
        return this.amountOfLaps;
    }

    public Game SetAmountOfLaps(int amountOfLaps) {
        this.amountOfLaps = amountOfLaps;

        return this;
    }

    public float GetTotalTime() {
        return Ant_CurrentGameConfiguration.fSynchronizedTime;
    }

    /// <summary>
    /// Tell whether the game is paused.
    /// </summary>
    /// 
    /// <returns>bool</returns>
    public bool IsPaused() {
        return Ant_MainGame.Instance.bIsPaused;
    }
}