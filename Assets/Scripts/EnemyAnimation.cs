using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] Transform player;
    Animator anim;
    float EnemyX, EnemyY;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (PlayerController.PlayerInArea)
        {
            EnemyX = player.transform.position.x - transform.position.x;
            EnemyY = player.transform.position.y - transform.position.y;
        }
        else
        {
            EnemyX = EnemyAI.RoamTargetForAnimation.x - transform.position.x;
            EnemyY = EnemyAI.RoamTargetForAnimation.y - transform.position.y;
        }

        float x = EnemyX > 0 ? 1 : EnemyX < 0 ? -1 : 0;
        float y = EnemyY > 0 ? 1 : EnemyY < 0 ? -1 : 0;

        anim.SetFloat("MoveX", x);
        anim.SetFloat("MoveY", y);

        if (x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
