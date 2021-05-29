using UnityEngine;

public class PlayerHealth : Health 
{
    public override void TakeDamage(int amount)
    {
        print("OW! The player took " + amount + " damage");

        base.TakeDamage(amount);
    }

    public override void Die()
    {
        print("Martin Died");
    }
}
