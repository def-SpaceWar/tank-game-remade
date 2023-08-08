using TMPro;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public TMP_InputField player1up, player2up, player1down, player2down, player1left, player2left, player1right, player2right, player1shoot, player2shoot, player1increasePower, player2increasePower, player1decreasePower, player2decreasePower;

    private void Start()
    {
        if (PlayerPrefs.GetString("player1up") == "")
        {
            ResetControls();
        }

        ReloadControls();
    }

    public void SaveControls()
    {
        PlayerPrefs.SetString("player1up", player1up.text);
        PlayerPrefs.SetString("player2up", player2up.text);
        PlayerPrefs.SetString("player1down", player1down.text);
        PlayerPrefs.SetString("player2down", player2down.text);
        PlayerPrefs.SetString("player1left", player1left.text);
        PlayerPrefs.SetString("player2left", player2left.text);
        PlayerPrefs.SetString("player1right", player1right.text);
        PlayerPrefs.SetString("player2right", player2right.text);
        PlayerPrefs.SetString("player1shoot", player1shoot.text);
        PlayerPrefs.SetString("player2shoot", player2shoot.text);
        PlayerPrefs.SetString("player1increasePower", player1increasePower.text);
        PlayerPrefs.SetString("player2increasePower", player2increasePower.text);
        PlayerPrefs.SetString("player1decreasePower", player1decreasePower.text);
        PlayerPrefs.SetString("player2decreasePower", player2decreasePower.text);

        ReloadControls();
    }

    public void ResetControls()
    {
        PlayerPrefs.SetString("player1up", "up");
        PlayerPrefs.SetString("player2up", "e");
        PlayerPrefs.SetString("player1down", "down");
        PlayerPrefs.SetString("player2down", "d");
        PlayerPrefs.SetString("player1left", "left");
        PlayerPrefs.SetString("player2left", "s");
        PlayerPrefs.SetString("player1right", "right");
        PlayerPrefs.SetString("player2right", "f");
        PlayerPrefs.SetString("player1shoot", "m");
        PlayerPrefs.SetString("player2shoot", "q");
        PlayerPrefs.SetString("player1increasePower", ".");
        PlayerPrefs.SetString("player2increasePower", "2");
        PlayerPrefs.SetString("player1decreasePower", ",");
        PlayerPrefs.SetString("player2decreasePower", "1");

        ReloadControls();
    }

    private void ReloadControls()
    {
        player1up.text = PlayerPrefs.GetString("player1up");
        player2up.text = PlayerPrefs.GetString("player2up");
        player1down.text = PlayerPrefs.GetString("player1down");
        player2down.text = PlayerPrefs.GetString("player2down");
        player1left.text = PlayerPrefs.GetString("player1left");
        player2left.text = PlayerPrefs.GetString("player2left");
        player1right.text = PlayerPrefs.GetString("player1right");
        player2right.text = PlayerPrefs.GetString("player2right");
        player1shoot.text = PlayerPrefs.GetString("player1shoot");
        player2shoot.text = PlayerPrefs.GetString("player2shoot");
        player1increasePower.text = PlayerPrefs.GetString("player1increasePower");
        player2increasePower.text = PlayerPrefs.GetString("player2increasePower");
        player1decreasePower.text = PlayerPrefs.GetString("player1decreasePower");
        player2decreasePower.text = PlayerPrefs.GetString("player2decreasePower");
    }

    // This is to be used when controls are not found
    public static void ErrorResetControls()
    {
        PlayerPrefs.SetString("player1up", "up");
        PlayerPrefs.SetString("player2up", "e");
        PlayerPrefs.SetString("player1down", "down");
        PlayerPrefs.SetString("player2down", "d");
        PlayerPrefs.SetString("player1left", "left");
        PlayerPrefs.SetString("player2left", "s");
        PlayerPrefs.SetString("player1right", "right");
        PlayerPrefs.SetString("player2right", "f");
        PlayerPrefs.SetString("player1shoot", "m");
        PlayerPrefs.SetString("player2shoot", "q");
        PlayerPrefs.SetString("player1increasePower", ".");
        PlayerPrefs.SetString("player2increasePower", "2");
        PlayerPrefs.SetString("player1decreasePower", ",");
        PlayerPrefs.SetString("player2decreasePower", "1");
    }
}
