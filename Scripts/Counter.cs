using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Coroutine _counting;
    private ButtonDisplay _buttonDisplay;
    private CounterDisplay _counterDisplay;

    private int _count = 0;
    private bool _isCounting = false;

    private void Awake()
    {
        _buttonDisplay = _button.GetComponent<ButtonDisplay>();
        _counterDisplay = GetComponent<CounterDisplay>();
        _button.onClick.AddListener(ToggleCounting);
        UpdateCounterText();
        UpdateButtonState();
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;
        UpdateButtonState();

        if (_isCounting)
        {
            _counting = StartCoroutine(CountEveryHalfSecond());
        }
        else
        {
            StopCoroutine(_counting);
        }
    }

    private void UpdateButtonState()
    {
        _buttonDisplay.SetButtonState(_isCounting);
    }

    private void UpdateCounterText()
    {
        _counterDisplay.SetCounterText(_count);
    }

    private IEnumerator CountEveryHalfSecond()
    {
        float delay = 0.5f;
        WaitForSeconds waitForSeconds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return waitForSeconds;
            _count++;
            UpdateCounterText();
        }
    }
}