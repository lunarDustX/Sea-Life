using UnityEngine;

public class Pirate : Creature
{
    public Transform[] wayPoints;
    private Transform wayPointTarget;
    private int index = 0;

    protected override void Start()
    {
        base.Start();
        wayPointTarget = wayPoints[0];
    }

    protected override void Move()
    {
        base.Move();

        if (Vector2.Distance(transform.position, player.position) > distance)
        {
            if (Vector2.Distance(transform.position, wayPointTarget.position) < 0.01f)
            {
                index = (index + 1) % wayPoints.Length;
                wayPointTarget = wayPoints[index];
            }
            transform.position = Vector2.MoveTowards(transform.position, wayPointTarget.position, speed * Time.deltaTime);
        }
    }
}
