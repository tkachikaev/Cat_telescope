using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float Health;

    private float currentHealth;

    private void Awake()
    {
        currentHealth = Health;
    }

    /// <summary>
    /// Восстановить здоровье на Value
    /// </summary>
    /// <param name=""></param>
    public void AddHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > Health)
        {
            currentHealth = Health;
        }
    }

    /// <summary>
    /// Отнять здоровье на Value
    /// </summary>
    /// <param name=""></param>
    private void TakeHealth(float value)
    {
        currentHealth -= value;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    private void CheackIsAlive(float heals)
    {
        if (heals.Equals(0))
        {
            Debug.Log($"Is Dead - you heals = {currentHealth}");
        }
    }
}
