using System;
using UniRx;
using UnityEngine;

public class OneShotWeapon : MonoBehaviour, IWeapon
{
    private readonly IntReactiveProperty power = new(0);
    private readonly IntReactiveProperty interval = new(0);
    private readonly IntReactiveProperty maxAmmo = new(0);
    private readonly FloatReactiveProperty sustain = new(0);
    private readonly IntReactiveProperty currentAmmo = new(0);
    private readonly IntReactiveProperty loadingAmmo = new(0);
    private readonly FloatReactiveProperty reloadTime = new(0);

    private bool shotAble = true;
    public ReadOnlyReactiveProperty<int> Power => power.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> Interval => interval.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> MaxAmmo => maxAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<float> Sustain => sustain.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> CurrentAmmo => currentAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> LoadingAmmo => loadingAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<float> ReloadTime => reloadTime.ToReadOnlyReactiveProperty();

    public OneShotWeapon(WeaponScriptableObject weaponData)
    {
        this.power.Value = weaponData.power;
        this.interval.Value = weaponData.interval;
        this.maxAmmo.Value = weaponData.maxAmmo;
        this.sustain.Value = weaponData.sustain;
        this.currentAmmo.Value = weaponData.currentAmmo;
        this.loadingAmmo.Value = weaponData.loadingAmmo;
        this.reloadTime.Value = weaponData.reloadTime;
    }

    public bool Fire()
    {
        if (loadingAmmo.Value == 0 || !shotAble)
        {
            return false;
        }
        shotAble = false;
        Debug.Log("OneShotWeapon:Fire");
        loadingAmmo.Value -= 1;
        Observable.TimerFrame(interval.Value)
        .Subscribe(_ => shotAble = true);
        return true;
    }

    public void Reload()
    {
        if (currentAmmo.Value == 0) return;
        shotAble = false;
        Observable.Timer(TimeSpan.FromSeconds(reloadTime.Value))
        .Subscribe(_ => _Reload());
    }

    private void _Reload()
    {
        Debug.Log("OneShotWeapon:Reload");
        if (currentAmmo.Value + loadingAmmo.Value >= maxAmmo.Value)
        {
            currentAmmo.Value -= maxAmmo.Value;
            currentAmmo.Value += loadingAmmo.Value;
            loadingAmmo.Value = maxAmmo.Value;
        }
        else
        {
            loadingAmmo.Value += currentAmmo.Value;
            currentAmmo.Value = 0;
        }
        shotAble = true;
    }

    public void AddPower(int power) => this.power.Value += power;

    public void SubtractInterval(int interval) => this.interval.Value -= interval;

    public void AddMaxAmmo(int maxAmmo) => this.maxAmmo.Value += maxAmmo;

    public void AddSustain(int sustain) => this.sustain.Value += sustain;
}