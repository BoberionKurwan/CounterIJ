using UnityEngine;
using UnityEngine.UI;

public class CounterDisplay : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private Text _counterText;

    private void Awake()
    {
        _counter.CountChanged += UpdateCounterText;
        UpdateCounterText(_counter.GetCurrentCount());
    }

    private void OnDestroy()
    {
        _counter.CountChanged -= UpdateCounterText;
    }

    private void UpdateCounterText(int count)
    {
        _counterText.text = $"Count : {count}";
    }
}