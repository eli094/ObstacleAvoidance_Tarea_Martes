using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    public float npcRadius = 5f;
    public float npcSpeed = 5f;
    public float groundCheckDistance = 1.5f;

    public LayerMask obstaclesLayer;
    public LayerMask groundLayer;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
            AvoidObstacles();
    }

    //private bool IsOnGround()
    //{
    //    RaycastHit hit;

    //    return Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer);
    //}

    private void AvoidObstacles()
    {
        Collider[] obstacles = Physics.OverlapSphere(transform.position, npcRadius, obstaclesLayer);

        if (obstacles.Length > 0)
        {
            Vector3 avoidanceDirection = GetAvoidDirection(obstacles);

            rb.MovePosition(transform.position + avoidanceDirection * npcSpeed * Time.deltaTime);
        }
        //else
        //{
        //    MoveFreely();
        //}
    }

    private Vector3 GetAvoidDirection(Collider[] obstacles)
    {
        Collider nearObstacle = obstacles[0];
        float nearDistance = Vector3.Distance(transform.position, nearObstacle.transform.position);

        //foreach (var obstacle in obstacles)
        //{
        //    //float distance = Vector3.Distance(transform.position, obstacle.transform.position);

        //    //if (distance < nearDistance)
        //    //{
        //    //    nearObstacle = obstacle;
        //    //    nearDistance = distance;
        //    //}
        //}

        Vector3 avoidanceDirection = transform.position - nearObstacle.transform.position;

        //avoidanceDirection.y = 0;
        return avoidanceDirection.normalized;
    }

    //private void MoveFreely()
    //{
    //    Vector3 randomDirection = Random.onUnitSphere;
    //    randomDirection.y = 0;

    //    rb.MovePosition(transform.position + randomDirection * npcSpeed * Time.deltaTime);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, npcRadius);
    }
}

