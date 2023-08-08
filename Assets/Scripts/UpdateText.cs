using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;

    // Update is called once per frame
    private void Update()
    {
        text.text = (slider.value).ToString();
    }
}
