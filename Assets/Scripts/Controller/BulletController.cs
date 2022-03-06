using UnityEngine;

public class BulletController : MonoBehaviour
{
    /// <summary>
    /// ��������
    /// </summary>
    [SerializeField]
    private float deleteTime;

    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField]
    private float speed;

    public GameObject ExplodePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        // deleteTime�b��ɔj��\��
        Destroy(gameObject, deleteTime);
    }

    // Update is called once per frame
    private void Update()
    {
        // �ړ�
        transform.Translate(speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        // �j��
        Destroy(gameObject);
    }
}