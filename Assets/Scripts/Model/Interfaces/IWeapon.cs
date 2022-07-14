using System;
using UniRx;

public interface IWeapon
{
    public ReadOnlyReactiveProperty<int> WeaponNO { get; }
    public ReadOnlyReactiveProperty<String> WeaponViewName { get; }
    public ReadOnlyReactiveProperty<int> Power { get; }
    public ReadOnlyReactiveProperty<int> LoadingAmmo { get; }
    public ReadOnlyReactiveProperty<int> CurrentAmmo { get; }
    public ReadOnlyReactiveProperty<float> Sustain { get; }
    public ReadOnlyReactiveProperty<float> BulletSpeed { get; }
    public ReadOnlyReactiveProperty<int> BurstInterval { get; }
    public ReadOnlyReactiveProperty<int> CntBurst { get; }
    public ReadOnlyReactiveProperty<bool> IsAuto { get; }

    bool Fire();

    void Reload();

    void AddPower(int power);

    void SubtractInterval(int interval);

    void AddMaxAmmo(int maxAmmo);

    void AddSustain(int sustain);
}