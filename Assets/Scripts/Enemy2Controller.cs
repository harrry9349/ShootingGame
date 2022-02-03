using UnityEngine;

public class Enemy2Controller : MonoBehaviour
{
    private float moveSpeed;
    public GameObject ExplodePrefab;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeed = 1f + 1f * Random.value;
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
        Destroy(coll.gameObject);
        Instantiate(ExplodePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}