using UnityEngine;

public static class GameData
{
    public static string TeamOneName = "Player 1";
    public static string TeamTwoName = "Player 2";
    public static Color TeamOneColor = PieceColors.Red;
    public static Color TeamTwoColor = PieceColors.Blue;
    public static int ScoreToWin = 3;

    public static void SetTeamNames(string teamOneName, string teamTwoName)
    {
        if (string.IsNullOrEmpty(teamOneName))
        {
            GameData.TeamOneName = "Player 1";
        }
        else
        {
            GameData.TeamOneName = teamOneName;
        }

        if (string.IsNullOrEmpty(teamTwoName))
        {
            GameData.TeamTwoName = "Player 2";
        }
        else
        {
            GameData.TeamTwoName = teamTwoName;
        }
    }

    public static void SetTeamColors(Color teamOneColor, Color teamTwoColor)
    {

        GameData.TeamOneColor = teamOneColor;
        GameData.TeamTwoColor = teamTwoColor;
    }
}
