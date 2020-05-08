using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    protected Vector3 direction = Vector3.down;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rb2d;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (direction != Vector3.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    protected virtual void FixedUpdate()
    {
        MoveCharacter();
    }

    protected void MoveCharacter()
    {
        rb2d.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    public Vector2 CharacterDirection()
    {
        if(direction == Vector3.zero)
        {
            return Vector2.down;
        }
        return direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       // direction = Vector3.zero;
    }

    public void SetAnimatorTrigger(string triggerName)
    {
        animator.SetTrigger(triggerName);
    }

}
