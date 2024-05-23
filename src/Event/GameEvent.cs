using System;

namespace TheKartersModdingAssistant.Event;

public class GameEvent {
    // Ant_CurrentGameConfiguration::Start
    public static Action onGameStart;

    // Ant_MainGame_Players::ResetAndPreparePlayersToRace
    public static Action onRaceInitialize;

    // Ant_MainGame::FixedUpdate
    public static Action onRaceStart;
    public static Action onRaceUpdate;
}