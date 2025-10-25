using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;

    public float attackCooldown = 1f;
    private float nextAttack = 0f;
    private float cooldown = 0;
    private float maxCooldown = 3;
    private bool isOnCooldown = false;


    void Update()
    {
        if (Input.GetMouseButton(0) && cooldown == 0)
        {
            animator.SetTrigger("AttackTrigger");

            isOnCooldown = true;

        }

        if (isOnCooldown == true)
        {
            cooldown = Time.time;


        }
        if (cooldown >= maxCooldown)
        {
            cooldown = 0;
        }

        //void OnTriggerEnter(Collider other)
        //{
        //    if(other.CompareTag("Enemy"))
        //    {
        //        other.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
        //    }
        //}
    }


}