using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private InputReader _inputReader;

    private Coroutine _counting;
    private int _count = 0;
    private bool _isCounting = false;

    public event Action<int> CountChanged;

    public int GetCurrentCount()
    {
        return _count;
    }

    private void Start()
    {
        if(_inputReader != null)
        _inputReader.OnLeftMouseClick += ToggleCounting;
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
            _counting = StartCoroutine(IncreaseCount());
        else
            StopCoroutine(_counting);
    }

    private IEnumerator IncreaseCount()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return waitForSeconds;
            _count++;
            CountChanged?.Invoke(_count);
        }
    }
}