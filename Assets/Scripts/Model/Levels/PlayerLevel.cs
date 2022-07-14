using UniRx;

public class PlayerLevel
{
    private readonly IntReactiveProperty level = new(1);
    private readonly IntReactiveProperty exp = new(0);
    private readonly IntReactiveProperty nextLevelExp = new(100);

    public ReadOnlyReactiveProperty<int> Level => level.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> EXP => exp.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> NextLevelExp => nextLevelExp.ToReadOnlyReactiveProperty();

    public void GainExp(int gainExp)
    {
        exp.Value += gainExp;
    }
}