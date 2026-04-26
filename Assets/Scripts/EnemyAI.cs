using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float roamSpeed = 2f;
    [SerializeField] float chaseSpeed = 4f;
    [SerializeField] float roamRadius = 5f;
    [SerializeField] float detectionRange = 6f;

    [SerializeField] Transform player;

    Vector2 roamTarget;
    Vector2 startPosition;
    bool chasing = false;

    public static Vector2 RoamTargetForAnimation;

    void Start()
    {
        startPosition = transform.position;
        SetNewRoamTarget();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < detectionRange && PlayerController.PlayerInArea)
        {
            chasing = true;
        }
        else
        {
            chasing = false;
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Roam();
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            chaseSpeed * Time.deltaTime
        );
    }

    void Roam()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            roamTarget,
            roamSpeed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, roamTarget) < 0.2f)
        {
            SetNewRoamTarget();
        }
    }

    void SetNewRoamTarget()
    {
        Vector2 randomDirection = Random.insideUnitCircle * roamRadius;
        roamTarget = startPosition + randomDirection;
        RoamTargetForAnimation=roamTarget;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, roamRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}