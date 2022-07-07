using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    /// <summary>��������Ă���폜�܂ł̕b��</summary>
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