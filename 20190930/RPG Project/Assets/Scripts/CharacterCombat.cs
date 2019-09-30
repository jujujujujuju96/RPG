using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharactorStats))]
public class CharacterCombat : MonoBehaviour
{
    CharactorStats myStats;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;
    const float combatCoolDown = 5;
    float lastAttackTime;

    public bool InCombat { get; private set; }

    public event System.Action OnAttack;
    private void Start()
    {
        myStats = GetComponent<CharactorStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        if (Time.time - lastAttackTime > combatCoolDown) {
            InCombat = false;
        }
    }
    public void Attack(CharactorStats targetStats) {
        if (attackCooldown <= 0f) {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            if (OnAttack != null) {
                OnAttack();
            }
            attackCooldown = 1f / attackSpeed;
            InCombat = true;
            lastAttackTime = Time.time;
        }
        
    }
    IEnumerator DoDamage(CharactorStats stats, float delay) {
        yield return new WaitForSeconds(delay);
        stats.takeDamage(myStats.damage.GetValue());

        if (stats.currentHealth <= 0) {
            InCombat = false;
        }
    }
}
