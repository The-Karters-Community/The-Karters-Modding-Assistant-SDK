using System.Collections.Generic;
using HarmonyLib;

namespace TheKartersModdingAssistant.Core;

[HarmonyPatch(typeof(Ant_MainGame_Players), nameof(Ant_MainGame_Players.Start))]
public class Ant_MainGame_Players__Start {
    public static void Postfix(Ant_MainGame_Players __instance) {
        Ant_Player[] antPlayers = __instance.GetAllPlayers();
        List<Player> players = new();

        foreach (Ant_Player antPlayer in antPlayers) {
            players.Add(new Player(antPlayer));
        }

        Player.players = players;
    }
}