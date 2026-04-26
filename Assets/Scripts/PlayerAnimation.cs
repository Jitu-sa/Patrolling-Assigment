using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("MoveX", x);
        anim.SetFloat("MoveY", y);

        if (x==1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (x == -1) 
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}