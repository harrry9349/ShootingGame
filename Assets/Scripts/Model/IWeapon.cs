public interface IWeapon
{
    void Fire();

    void Reload();

    void AddPower(int power);

    void SubtractInterval(int interval);

    void AddMaxAmmo(int maxAmmo);

    void AddSustain(int sustain);
}