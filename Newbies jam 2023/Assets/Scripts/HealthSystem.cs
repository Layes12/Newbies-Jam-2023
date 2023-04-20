
public class HealthSystem
{
    private int health, maxHealth;

    public HealthSystem(int max_Health)
    {
        max_Health = maxHealth;
        health = max_Health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
    }
}
