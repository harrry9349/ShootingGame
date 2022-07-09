using UniRx;

public interface IWeapon
{
    public ReadOnlyReactiveProperty<int> LoadingAmmo { get; }
    public ReadOnlyReactiveProperty<int> CurrentAmmo { get; }
    public ReadOnlyReactiveProperty<float> Sustain { get; }

    bool Fire();

    void Reload();

    void AddPower(int power);

    void SubtractInterval(int interval);

    void AddMaxAmmo(int maxAmmo);

    void AddSustain(int sustain);
}