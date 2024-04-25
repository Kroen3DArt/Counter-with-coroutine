using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _countCoroutine;
    private int _maxTime = 100;
    private float _delay = 0.5f;
    private float _currentTime;
    private bool _isRunning;

    private void Start()
    {
        _text.text = "0";
        _currentTime = 0f;
        _isRunning = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isRunning == false)
            {
                _countCoroutine = StartCoroutine(CountTime());
                _isRunning = true;
            }
            else
            {
                if (_countCoroutine != null)
                    StopCoroutine(_countCoroutine);

                _isRunning = false;
            }
        }
    }

    private IEnumerator CountTime()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (_currentTime < _maxTime)
        {
            _currentTime++;
            DisplayCount(_currentTime);
            yield return wait;
        }
    }

    private void DisplayCount(float count) => _text.text = count.ToString("");
}
