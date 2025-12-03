using UnityEngine;

public class OtherAttack : MonoBehaviour
{
    public float moveSpeed = 3f;                   
    public float detectionRadius = 10f;              
    public float attackRange = 2f;                  
    public float damage = 10f;                     
    public float health = 100f;                      

    private Transform target;                       
    private bool attacking = false;                  

    void Update()
    {
        DetectTargetsWithTags(new[] { "warrior", "farmer" }); 
        ChaseTarget();                              
        PerformAttack();                            
    }

    private void DetectTargetsWithTags(string[] tags)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var collider in targets)
        {
            foreach (var tag in tags)
            {
                if (collider.CompareTag(tag))
                {
                    target = collider.transform;     
                    return;
                }
            }
        }
    }

    private void ChaseTarget()
    {
        if (target != null && !attacking)
        {
            Vector2 direction = (Vector2)target.position - (Vector2)transform.position;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime); 
        }
    }

    private void PerformAttack()
    {
        if (target != null && Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            attacking = true;
            target.SendMessageUpwards("TakeDamage", damage);
        }
        else
        {
            attacking = false;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();                                  
        }
    }

    private void Die()
    {
        Debug.Log(name + " умер.");                 
        Destroy(gameObject);                       
    }
}
