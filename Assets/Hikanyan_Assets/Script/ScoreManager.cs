using UniRx;

public class ScoreManager
{
    private IntReactiveProperty _score = new IntReactiveProperty(0);

    public IReadOnlyReactiveProperty<int> Score => _score;

    public void AddScore(int points)
    {
        _score.Value += points;
    }

    public void ResetScore()
    {
        _score.Value = 0;
    }
}
