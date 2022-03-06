using UnityEngine;

public class ItemController : MonoBehaviour
{
    /// <summary>�ړ����x<summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>�A�C�e���p�^�[���ԍ�<summary>
    [SerializeField]
    private int itemPattern;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeed = moveSpeed + 1f * Random.value;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-moveSpeed, 0, 0, Space.World);

        if (transform.position.x < -750f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(gameObject.name);
        Destroy(gameObject);
    }

    public int GetItemPattern()
    {
        return itemPattern;
    }
}