using UnityEngine;

// Sets and gets scores depending on Games.currentGame
public static class Scores
{
    public static void setScore(int score)
    {
        PlayerPrefs.SetInt("Score" + Games.currentGame.ToString(), score);
        PlayerPrefs.SetInt("BestScore" + Games.currentGame.ToString(), Mathf.Max(PlayerPrefs.GetInt("BestScore" + Games.currentGame.ToString()), score));
    }

    public static int getScore()
    {
        return PlayerPrefs.GetInt("Score" + Games.currentGame.ToString());
    }

    public static int getBestScore()
    {
        return PlayerPrefs.GetInt("BestScore" + Games.currentGame.ToString());
    }
}
