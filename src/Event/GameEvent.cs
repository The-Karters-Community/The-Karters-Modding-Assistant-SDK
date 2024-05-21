using System;

namespace TheKartersAssistant.Event;

public class GameEvent {
    // Ant_CurrentGameConfiguration::Start
    public static Action onGameStart;

    // Ant_MainGame::StartAndInitializeRace_Coroutine
    public static Action onRaceInitialize;

    // Ant_MainGame::FixedUpdate
    public static Action onRaceStart;
    public static Action onRaceUpdate;
}