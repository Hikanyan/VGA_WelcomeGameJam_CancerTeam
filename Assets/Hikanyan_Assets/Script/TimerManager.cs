using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TimerManager
{
    private FloatReactiveProperty _timer = new FloatReactiveProperty(0f);
    private CompositeDisposable _disposable = new CompositeDisposable();

    public IReadOnlyReactiveProperty<float> Timer => _timer;

    public async UniTask StartTimer(float duration)
    {
        _timer.Value = duration;

        while (_timer.Value > 0f)
        {
            await UniTask.DelayFrame(1);
            _timer.Value -= Time.deltaTime;
        }

        _timer.Value = 0f;
    }

    public void ResetTimer()
    {
        _timer.Value = 0f;
    }

    public void StopTimer()
    {
        _disposable.Clear();
    }
}
