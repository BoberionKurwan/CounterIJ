using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text _counterText;
    private int _count = 0;
    private bool _isCounting = false;
    private Coroutine countingCoroutine;

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
            countingCoroutine = StartCoroutine(CountEveryHalfSecond());
        }
        else
        {
            if (countingCoroutine != null)
            {
                StopCoroutine(countingCoroutine);
            }
        }
    }

    private void UpdateCounterDisplay()
    {
        if (_counterText != null)
        {
            _counterText.text = "Count: " + _count;
        }

    }

    private IEnumerator CountEveryHalfSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _count++;
            UpdateCounterDisplay();
        }
    }
}
