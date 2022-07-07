using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    /// <summary>生成されてから削除までの秒数</summary>
    [SerializeField]
    private float deleteSeconds;

    public void Start()
    {
        Destroy(gameObject, deleteSeconds);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}