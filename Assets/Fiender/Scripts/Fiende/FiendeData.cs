using UnityEngine;

[CreateAssetMenu(menuName = "Fiende/Fiende Data", fileName = "New Fiende Data")]
public class FiendeData : ScriptableObject
{
    public float MovementSpeed = 1;

    public int MaxHealth = 10;

    public int Damage = 1;
    public float AttackSpeed = 1;

    /*public float HealthScaling = 0.5f;
    public float DamageScaling = 0.5f;
    public float AttackSpeedScaling = 0.5f;
    public float MovementSpeedScaling = 0.5f;*/
}
