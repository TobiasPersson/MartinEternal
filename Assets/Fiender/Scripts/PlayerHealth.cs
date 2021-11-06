using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health 
{
    [SerializeField]
    private GameObject DeathParticles;

    public override void Die()
    {
        print("Martin Died");
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);

    }
}
