using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    public void SetCounterText(int count)
    {
        _counterText.text = $"Count : {count}";
    }
}