using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private int _mouseButton = 0;

    private Coroutine _counting;
    private int _count = 0;
    private bool _isCounting = false;

    public event Action<int> OnCountChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
            _counting = StartCoroutine(CountProcess());
        else
            StopCoroutine(_counting);
    }

    private IEnumerator CountProcess()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        while (enabled)
        {
            yield return waitForSeconds;
            _count++;
            OnCountChanged?.Invoke(_count);
        }
    }
}