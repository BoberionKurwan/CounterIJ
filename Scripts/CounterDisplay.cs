using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    private Text _countText;

    public void UpdateDisplay(int count)
    {
        _countText.text = "Count: " + count;
    }
}