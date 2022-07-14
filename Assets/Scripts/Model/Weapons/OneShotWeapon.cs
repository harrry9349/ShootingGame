using System;
using UniRx;
using UnityEngine;

public class OneShotWeapon : IWeapon
{
    private readonly IntReactiveProperty weaponNO = new(0);
    private readonly StringReactiveProperty weaponViewName = new();
    private readonly IntReactiveProperty power = new(0);
    private readonly IntReactiveProperty interval = new(0);
    private readonly IntReactiveProperty maxAmmo = new(0);
    private readonly FloatReactiveProperty sustain = new(0);
    private readonly IntReactiveProperty currentAmmo = new(0);
    private readonly IntReactiveProperty loadingAmmo = new(0);
    private readonly FloatReactiveProperty reloadTime = new(0);
    private readonly FloatReactiveProperty bulletSpeed = new(0);
    private readonly IntReactiveProperty cntBurst = new(0);
    private readonly IntReactiveProperty burstInterval = new(0);
    private readonly BoolReactiveProperty isAuto = new(false);
    private bool shotAble = true;
    public ReadOnlyReactiveProperty<int> WeaponNO => weaponNO.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<string> WeaponViewName => weaponViewName.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> Power => power.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> Interval => interval.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> MaxAmmo => maxAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<float> Sustain => sustain.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> CurrentAmmo => currentAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> LoadingAmmo => loadingAmmo.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<float> ReloadTime => reloadTime.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<float> BulletSpeed => bulletSpeed.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> CntBurst => cntBurst.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<int> BurstInterval => burstInterval.ToReadOnlyReactiveProperty();
    public ReadOnlyReactiveProperty<bool> IsAuto => isAuto.ToReadOnlyReactiveProperty();

    public OneShotWeapon(WeaponScriptableObject weaponData)
    {
        weaponNO.Value = weaponData.weaponNO;
        weaponViewName.Value = weaponData.weaponViewName;
        power.Value = weaponData.power;
        interval.Value = weaponData.interval;
        maxAmmo.Value = weaponData.maxAmmo;
        sustain.Value = weaponData.sustain;
        currentAmmo.Value = weaponData.currentAmmo;
        loadingAmmo.Value = weaponData.loadingAmmo;
        reloadTime.Value = weaponData.reloadTime;
        bulletSpeed.Value = weaponData.bulletSpeed;
        cntBurst.Value = weaponData.cntBurst;
        burstInterval.Value = weaponData.burstInterval;
        isAuto.Value = weaponData.IsAuto;
    }

    public bool Fire()
    {
        if (loadingAmmo.Value == 0 || !shotAble)
        {
            return false;
        }
        shotAble = false;
        Debug.Log("OneShotWeapon:Fire");
        loadingAmmo.Value -= cntBurst.Value;
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