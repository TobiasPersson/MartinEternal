using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Health : MonoBehaviour, ITakeDamage
{
    public event Action OnHealthChanged = delegate { };

    public HealthData HealthData;

    [SerializeField]
    private PooledMonoBehaviour damageText;

    [SerializeField]
    private Color color; // The color of the object, used for things like damage values etc.

    public bool Alive { get { return HealthData.currentHealth > 0; } }
    
    private Vector3 damageNumberOffset = new Vector3(0, 2f, 0);

    // Sets the HP to max when spawning
    protected virtual void Start()
    {
        HealthData.currentHealth = HealthData.maxHealth;
    }

    public virtual void TakeDamage(int amount)
    {
        if (!Alive) // We don't want anything weird happening when the player is dead, ex. playing the damage sound with a gameover screen up
        {
            return;
        }

        // Creates a damage number at the objects screen position and sets its color to the objects color
        {
            GameObject _damageNumber = damageText.Get<PooledMonoBehaviour>().gameObject;
            TextMeshPro _damageText = _damageNumber.GetComponentInChildren<TextMeshPro>();

            //Position
            _damageNumber.transform.position = this.transform.position + damageNumberOffset;
            /*_damageNumber.gameObject.transform.SetParent(canvas.transform, false);
            (_damageNumber.transform as RectTransform).position = camera.WorldToScreenPoint(this.transform.position + damageNumberOffset);
            _damageNumber.GetComponent<UIDamageNumber>().positionToHold = this.transform.position + damageNumberOffset;*/

            // Color
            _damageText.color = color;

            // Text
            _damageText.text = amount.ToString();

        }


        // Taking the actual damage
        HealthData.currentHealth -= amount;
        HealthData.currentHealth = Mathf.Clamp(HealthData.currentHealth, 0, HealthData.maxHealth); // There is no situation we want the players HP to be negative or above the max, for that we would use shields or extra HP if we want that mechanic

        OnHealthChanged();

        if (HealthData.currentHealth == 0)
        {
            //print(gameObject.name + " has died");
            Die();
        }
    }

    public void Heal(int amount)
    {
        HealthData.currentHealth += amount;
        HealthData.currentHealth = Mathf.Clamp(HealthData.currentHealth, 0, HealthData.maxHealth); // Again, we don't want to go over the max

        OnHealthChanged();
    }

    public abstract void Die(); // Abstract because the player and enemies have a very different death sequence
}

[System.Serializable]
public struct HealthData // A struct to efficiently store the health information. Instead of having 2 variables everywhere, we just need to use one and we can very easily expand should we need it. 
{
    [HideInInspector]
    public int currentHealth;

    public int maxHealth;

    public HealthData(int currentHealth, int maxHealth)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}
