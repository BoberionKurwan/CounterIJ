using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _counterText;

    private int _initialCount = 0;

    private void Awake()
    {
        _counter.OnCountChanged += UpdateCounterText;
        UpdateCounterText(_initialCount);
    }

    private void UpdateCounterText(int count)
    {
        _counterText.text = $"Count : {count}";
    }
}