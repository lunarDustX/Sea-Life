using UnityEngine;

public class Creature : MonoBehaviour
{
    public float distance;
    public float speed;

    protected private Transform player;
    private SpriteRenderer spriteRenderer;

    [Header("Hurt")]
    [SerializeField]private float hurtLength;
    private float hurtCounter;

    protected virtual void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();

        if (hurtCounter <= 0)
            spriteRenderer.material.SetFloat("_FlashAmount", 0);
        else
            hurtCounter -= Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakenDamage();
        //}
    }

    protected virtual void Move()
    {
        if (Vector2.Distance(transform.position, player.position) < distance)
        {
            FollowPlayer();
            Flip();
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void Flip()
    {
        spriteRenderer.flipX = transform.position.x < player.position.x;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distance);
    }

    public void TakenDamage()
    {
        print(name + " taken dmg");
        HurtShader();
    }

    private void HurtShader()
    {
        spriteRenderer.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }

}
