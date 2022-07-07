using System;
using UniRx;
using UnityEngine;

public class OneShotWeapon : MonoBehaviour, IWeapon
{
    private readonly IntReactiveProperty power = new(100);
    private readonly IntReactiveProperty interval = new(100);
    private readonly IntReactiveProperty maxAmmo = new(100);
    private readonly IntReactiveProperty sustain = new(100);
    private readonly IntReactiveProperty currentAmmo = new(100);
    private readonly IntReactiveProperty loadingAmmo = new(100);
    private readonly IntReactiveProperty reloadTime = new(100);

    public ReadOnlyReactiveProperty<int> Power => power.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> Interval => interval.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> MaxAmmo => maxAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> Sustain => sustain.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> CurrentAmmo => currentAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> LoadingAmmo => loadingAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> ReloadTime => reloadTime.ToReadOnlyReactiveProperty();

    public OneShotWeapon(int power, int interval, int maxAmmo, int sustain, int currentAmmo, int loadingAmmo, int reloadTime)
    {
        this.power.Value = power;
        this.interval.Value = interval;
        this.maxAmmo.Value = maxAmmo;
        this.sustain.Value = sustain;
        this.currentAmmo.Value = currentAmmo;
        this.loadingAmmo.Value = loadingAmmo;
        this.reloadTime.Value = reloadTime;

        IDisposable subscriptionPower = Power.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionInterval = Interval.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionMaxAmmo = MaxAmmo.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionSustain = Sustain.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionCurrentAmmo = CurrentAmmo.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionLoadingAmmo = LoadingAmmo.Subscribe(x => Debug.Log(x));
        IDisposable subscriptionReloadTime = ReloadTime.Subscribe(x => Debug.Log(x));
    }

    public void Fire()
    {
        Debug.Log("OneShotWeapon:Fire");
        loadingAmmo.Value -= 1;
    }

    public void Reload()
    {
        Debug.Log("OneShotWeapon:Reload");
        currentAmmo.Value -= maxAmmo.Value;
        currentAmmo.Value += loadingAmmo.Value;
        loadingAmmo.Value = maxAmmo.Value;
    }

    public void AddPower(int power) => this.power.Value += power;

    public void SubtractInterval(int interval) => this.interval.Value -= interval;

    public void AddMaxAmmo(int maxAmmo) => this.maxAmmo.Value += maxAmmo;

    public void AddSustain(int sustain) => this.sustain.Value += sustain;
}