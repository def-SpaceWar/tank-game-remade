using UnityEngine;
using UnityEngine.UI;

public class ChangePower : MonoBehaviour
{
    public int tankNum;

    public string increasePowerKey;
    public string decreasePowerKey;

    private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        slider = GetComponent<Slider>();

        if (PlayerPrefs.GetString("player1up") == "")
        {
            Controls.ErrorResetControls();
        }

        if (tankNum == 1)
        {
            increasePowerKey = PlayerPrefs.GetString("player1increasePower");
            decreasePowerKey = PlayerPrefs.GetString("player1decreasePower");
        }
        else if (tankNum == 2)
        {
            increasePowerKey = PlayerPrefs.GetString("player2increasePower");
            decreasePowerKey = PlayerPrefs.GetString("player2decreasePower");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(increasePowerKey))
        {
            slider.value += 1;
        }
        else if (Input.GetKey(decreasePowerKey))
        {
            slider.value -= 1;
        }
    }
}
