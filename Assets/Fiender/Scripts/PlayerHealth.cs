using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
    [SerializeField]
    private GameObject DeathParticles;
    public bool hasTakenDamage = false;

    public override void TakeDamage(int amount)
    {
        print("OW! The player took " + amount + " damage");

        base.TakeDamage(amount);
        FindObjectOfType<CameraShake>().Shake(10f, 5f, 4f);
    }

    public override void Die()
    {
        print("Martin Died");
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);

    }

    
}
