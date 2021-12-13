using UnityEngine;

public class BulletController : MonoBehaviour
{
    private int count;
    private int susutain;

    // Start is called before the first frame update
    private void Start()
    {
        count = 0;
        susutain = 120;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(5f, 0, 0);
        count++;
        if (count >= susutain)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(coll.gameObject);
        Destroy(gameObject);
    }
}