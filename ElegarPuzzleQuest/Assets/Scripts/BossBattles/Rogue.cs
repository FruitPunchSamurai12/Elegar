using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rogue : MonoBehaviour
{
    [SerializeField]
    GameObject arrows;

    [SerializeField]
    Animator animator;

    bool drown = false;

    bool fired = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Movable")
        {
            animator.SetTrigger("Death");
            AudioManager.Instance.PlaySoundEffect("Water", 0.5f);
        }
    }

    public void DestroyRogue()
    {
        Destroy(gameObject);
    }

    public void FireArrow()
    {
        if (!fired)
        {
            fired = true;
            Vector2 playerpos = ElegarPuzzleQuestManager.Instance.PlayerTransform().position;
            Vector2 startPos = transform.position;
            float distance = Vector2.Distance(startPos, playerpos);
            Vector2 direction = (playerpos - startPos).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x);
            //turn it into degrees
            angle = (180 / Mathf.PI) * angle;
            float angle1 = (angle-10f) * (Mathf.PI / 180f);
            float angle2 = (angle + 10f) * (Mathf.PI / 180f);
            float angle3 = (angle - 20f) * (Mathf.PI / 180f);
            float angle4 = (angle + 20f) * (Mathf.PI / 180f);
            Vector2 direction1 = new Vector2(Mathf.Cos(angle1), Mathf.Sin(angle1));
            Vector2 direction2 = new Vector2(Mathf.Cos(angle2), Mathf.Sin(angle2));
            Vector2 direction3 = new Vector2(Mathf.Cos(angle3), Mathf.Sin(angle3));
            Vector2 direction4 = new Vector2(Mathf.Cos(angle4), Mathf.Sin(angle4));
            Vector2 target1 = startPos + direction1 * distance;
            Vector2 target2 = startPos + direction2 * distance;
            Vector2 target3 = startPos + direction3 * distance;
            Vector2 target4 = startPos + direction4 * distance;

            GameObject a = Instantiate(arrows, transform.position, Quaternion.identity);
            a.GetComponent<Arrows>().Initialize(ElegarPuzzleQuestManager.Instance.PlayerTransform().position);
            GameObject a1 = Instantiate(arrows, transform.position, Quaternion.identity);
            a1.GetComponent<Arrows>().Initialize(target1);
            GameObject a2 = Instantiate(arrows, transform.position, Quaternion.identity);
            a2.GetComponent<Arrows>().Initialize(target2);
            GameObject a3 = Instantiate(arrows, transform.position, Quaternion.identity);
            a3.GetComponent<Arrows>().Initialize(target3);
            GameObject a4 = Instantiate(arrows, transform.position, Quaternion.identity);
            a4.GetComponent<Arrows>().Initialize(target4);
        }
    }

    public bool Drowned() { return drown; }
    public void RogueDrowned() { drown = true; }
    public void Ready()
    {
        fired = false;
    }
}
