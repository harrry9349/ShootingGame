using UnityEngine;

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    public string weaponName;
    public string weaponViewName;
    public GameObject bulletPrefab;
    public int power;
    public int interval;
    public int maxAmmo;
    public float sustain;
    public int currentAmmo;
    public int loadingAmmo;
    public float reloadTime;
    public float bulletSpeed;
    public int cntBurst;
    public int burstInterval;
}