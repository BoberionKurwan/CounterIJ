using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _counterText;

    private CounterDisplay _display;
    private Coroutine _counting;
    private event Action<int> _OnCounterChange;
    private int _count = 0;
    private bool _isCounting = false;

    private void Start()
    {
        _OnCounterChange += _display.UpdateDisplay;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            _counting = StartCoroutine(CountEveryHalfSecond());
        }
        else
        {
            StopCoroutine(_counting);
        }
    }

    private IEnumerator CountEveryHalfSecond()
    {
        float delay = 0.5f;
        WaitForSeconds waitForSceonds = new WaitForSeconds(delay);

        while (enabled)
        {
            yield return waitForSceonds;
            _count++;
            _OnCounterChange?.Invoke(_count);
        }
    }
}
