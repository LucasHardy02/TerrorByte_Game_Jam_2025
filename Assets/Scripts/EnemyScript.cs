using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public Transform playerTransform;
    public Health healthScript;
    private NavMeshAgent navMeshAgent;

    public float attackCooldown = 1f;
    public float cooldownTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (healthScript == null)
        {
            healthScript = FindObjectOfType<Health>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            else
            {
                healthScript.TakeDamage(1);
                cooldownTimer = attackCooldown;
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

        }
    }
}