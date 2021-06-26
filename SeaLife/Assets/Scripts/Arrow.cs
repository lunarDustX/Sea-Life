using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    [HideInInspector] public Vector3 dir;

    void Update()
    {
        transform.position = transform.position + dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);

        if (other.tag == "Creature")
        {
            other.GetComponent<Creature>().TakenDamage();
            other.transform.position = transform.position + dir * 1.6f;
        }
    }
}
