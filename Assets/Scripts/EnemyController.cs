using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float moveSpeed;
    private float rotSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        this.moveSpeed = 1f + 1f * Random.value;
        this.rotSpeed = 0.5f + 0.3f * Random.value;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-moveSpeed, 0, 0, Space.World);
        transform.Rotate(0, 0, rotSpeed);

        if (transform.position.x < -750f)
        {
            Destroy(gameObject);
        }
    }
}