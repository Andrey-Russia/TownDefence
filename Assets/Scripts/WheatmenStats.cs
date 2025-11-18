using UnityEngine;

public class WheatmenStats : MonoBehaviour
{
 public float health = 10; 
    public float attackDamage = 1; 
    public float attackRange = 5; 
    public float attackCooldown = 2f; 

    private float lastAttackTime;

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange)
            {
                Attack(enemy);
                break;
            }
        }
    }

    void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log($"Item attacked {target.name} for {attackDamage} damage.");
            lastAttackTime = Time.time;
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

    void Die()
    {
        Debug.Log("Item died.");
        Destroy(gameObject);
    }
}
