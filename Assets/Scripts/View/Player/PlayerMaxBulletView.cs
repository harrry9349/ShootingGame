using UnityEngine;
using UnityEngine.UI;

public class PlayerMaxBulletView : MonoBehaviour
{
    // Start is called before the first frame update
    public void UpdateCurrentBullet(int currentAmmo)
    {
        GetComponent<Text>().text = currentAmmo.ToString();
    }
}