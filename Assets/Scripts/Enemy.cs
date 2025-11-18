using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float attackRange = 5f; 
    public float attackDamage = 10f;
    public float attackCooldown = 2f;
    public float Health = 100f;

    private float lastAttackTime;

    void Update()
    {
        GameObject[] houses = GameObject.FindGameObjectsWithTag("HOUSE");
        foreach (GameObject house in houses)
        {
            float distance = Vector3.Distance(transform.position, house.transform.position);
            if (distance <= attackRange)
            {
                Attack(house);
                break;
            }
        }
    }

    void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log($"Enemy attacked {target.name} for {attackDamage} damage.");
            lastAttackTime = Time.time;
        }
    }
        public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy died.");
        Destroy(gameObject);
    }
}
