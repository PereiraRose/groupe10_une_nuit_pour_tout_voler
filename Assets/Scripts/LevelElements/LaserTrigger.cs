using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private HudManager hudManager; // Référence au HUD
    private LaserManager laserManager; // Référence à la gestion de l'alarme

    void Start()
    {
        hudManager = FindObjectOfType<HudManager>(); // Trouve le HUD dans la scène
        laserManager = FindObjectOfType<LaserManager>(); // Trouve le LaserManager dans la scène
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si le joueur entre en contact avec le laser et que l'alarme n'est pas encore activée
        if (other.CompareTag("Player") && !laserManager.IsAlarmActive())
        {
            laserManager.ActivateLaserAlarm(); // Active l'alarme et démarre le timer
        }
    }
}
