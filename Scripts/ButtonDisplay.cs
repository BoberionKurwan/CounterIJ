using UnityEngine;
using UnityEngine.UI;

public class ButtonDisplay : MonoBehaviour
{
    [SerializeField] private Text _buttonText;

    private string _stopText = "Stop";
    private string _startText = "Start";

    public void SetButtonState(bool isCounting)
    {
        _buttonText.text = isCounting ? _stopText : _startText;
    }
}
