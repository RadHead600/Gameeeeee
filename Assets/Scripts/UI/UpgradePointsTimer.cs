using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePointsTimer : Singleton<UpgradePointsTimer>
{
    [SerializeField] private Slider _timerSlider;

    private float _time;
    private float _startTime;
    private Coroutine _timerSliderCoroutine;

    public float RemainingTimeInProcent { get; private set; }

    public void StartTimer(float time)
    {
        _time = time;
        _startTime = time;
        _timerSliderCoroutine = StartCoroutine(TimerUpdate());
        LevelProgressUpdater.Instance.OnCompletedLevel += StopTimer;
        LevelProgressUpdater.Instance.OnCompletedLevel += TakeGem.Instance.TakeGems;
    }

    public void StopTimer()
    {
        StopCoroutine(_timerSliderCoroutine);
        RemainingTimeInProcent = _timerSlider.value;
        Debug.Log("RemainingTimeInProcent " + RemainingTimeInProcent);
        LevelProgressUpdater.Instance.OnCompletedLevel -= TakeGem.Instance.TakeGems;
        LevelProgressUpdater.Instance.OnCompletedLevel -= StopTimer;
    }

    private IEnumerator TimerUpdate()
    {
        yield return new WaitForSeconds(1);
        _time -= 1;
        if (_time <= 0)
        {
            _timerSlider.value = 0;
            yield break;
        }
        _timerSlider.value = 1 - ((_startTime - _time) / _startTime);
        _timerSliderCoroutine = StartCoroutine(TimerUpdate());
    }

    private void OnDestroy()
    {
        LevelProgressUpdater.Instance.OnCompletedLevel -= StopTimer;
    }
}
