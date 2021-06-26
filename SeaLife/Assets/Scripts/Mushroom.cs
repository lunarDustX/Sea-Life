using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Creature"))
        {
            anim.SetTrigger("sway");

        }
    }
}
