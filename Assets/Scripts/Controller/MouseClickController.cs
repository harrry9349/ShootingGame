using UnityEngine;
using UnityEngine.UI;

public class MouseClickController : MonoBehaviour
{
    /// <summary>�e�ێc��\��</summary>
    [SerializeField]
    public Text BulletRemainsText;

    /// <summary>
    /// �t���b�N�V���b�g�p�e�ۃv���n�u
    /// </summary>
    [SerializeField]
    public GameObject FlickShotPrefab;

    /// <summary>
    /// �t���b�N�V���b�g�p�e�ێc��\��
    /// </summary>
    [SerializeField]
    public int remainsFlickshot;

    // Start is called before the first frame update
    private void Start()
    {
        // �t���b�N�V���b�g�p�e�ۂ̎c�萔�\��
        BulletRemainsText.text = remainsFlickshot.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (remainsFlickshot > 0)
            {
                // �T�E���h
                Sound.PlaySE("Explode");
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 10.0f;
                Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

                // �e����
                Instantiate(FlickShotPrefab, objPos, Quaternion.identity);

                // �t���b�N�V���b�g�p�e�ۂ̎c�萔�X�V
                remainsFlickshot--;
                BulletRemainsText.text = remainsFlickshot.ToString();
            }
            else
            {
                // �T�E���h�̂ݍĐ�
                Sound.PlaySE("unableshot");
            }
        }
    }

    public void AddAmmo(int ammo)
    {
        // �t���b�N�V���b�g�p�e�ۂ̎c�萔�X�V
        remainsFlickshot += ammo;
        BulletRemainsText.text = remainsFlickshot.ToString();
    }
}