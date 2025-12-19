using UnityEngine;

public class Stats : MonoBehaviour
{
    public float moveSpeed = 3f;                    
    public float detectionRadius = 1000f;             
    public float attackRange = 2f;                   
    public float damage = 50f;                      
    public float health = 100f;                      

    private Transform _target;                       
    private bool _attacking = false;                 

    void Update()
    {
        DetectTargetWithTag("enemy");                
        ChaseTarget();                              
        PerformAttack();                            
    }

    private void DetectTargetWithTag(string tag)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var collider in targets)
        {
            if (collider.CompareTag(tag))
            {
                _target = collider.transform;         
                break;
            }
        }
    }

    private void ChaseTarget()
    {
        if (_target != null && !_attacking)
        {
            Vector2 direction = (Vector2)_target.position - (Vector2)transform.position;
            transform.Translate(direction.normalized * moveSpeed * Time.deltaTime); 
        }
    }

    private void PerformAttack()
    {
        if (_target != null && Vector2.Distance(transform.position, _target.position) <= attackRange)
        {
            _attacking = true;
            _target.SendMessageUpwards("TakeDamage", damage); 
        }
        else
        {
            _attacking = false;
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
        Destroy(gameObject);                       
    }
}