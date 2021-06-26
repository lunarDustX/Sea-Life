using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private float followSpeed; 
    private Transform target;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), followSpeed*Time.deltaTime);
    }
}
