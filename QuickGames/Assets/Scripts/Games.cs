using UnityEngine;
using System.Collections;

// List of games and tracks current game
public static class Games
{
    public enum GamesEnum { Sequencer, ColorShooter, ArrowSwipe }
    public static bool[] isCompleted = { true, true, true };
    public static bool[] isTutorial = { true, true, false };
    public static GamesEnum currentGame;
    public static int noOfGames = 3;
}
