using UnityEngine;
using System;

public class OtherAttack : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float DetectionRadius = 100f;
    public float AttackRange = 2f;
    public float Damage = 10f;
    public float Health = 100f;

    private Transform _target;
    private bool _attacking = false;
    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        DetectTargetsWithTags(new[] { "warrior", "farmer" });
        ChaseTarget();
        PerformAttack();
    }

    private void OnDrawGizmos()
    {
    }

    private void DetectTargetsWithTags(string[] tags)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, DetectionRadius);
        foreach (var collider in targets)
        {
            foreach (var tag in tags)
            {
                if (collider.CompareTag(tag))
                {
                    _target = collider.transform;
                    return;
                }
            }
        }
    }

    private void ChaseTarget()
    {
        if (_target != null && !_attacking)
        {
            Vector2 direction = (Vector2)_target.position - (Vector2)transform.position;
            transform.Translate(direction.normalized * MoveSpeed * Time.deltaTime);
        }
    }

    private void PerformAttack()
    {
        if (_target != null && Vector2.Distance(transform.position, _target.position) <= AttackRange)
        {
            _attacking = true;
            _target.SendMessageUpwards("TakeDamage", Damage);
        }
        else
        {
            _attacking = false;
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
        Debug.Log(name + " умер.");
        if (_gameController != null)
        {
            _gameController.OnEnemyDestroyed(gameObject);
        }
        Destroy(gameObject);
    }
}