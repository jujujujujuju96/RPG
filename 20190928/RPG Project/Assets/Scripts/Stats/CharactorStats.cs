
using UnityEngine;


public class CharactorStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat armor;
    public Stat damage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            takeDamage(10);
        }
    }

    public void takeDamage(int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes damage: " + damage);

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        //死亡
        Debug.Log(transform.name + " Died.");
    }
}
