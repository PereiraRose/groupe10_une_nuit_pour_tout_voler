using UnityEngine;

public class LaserTrigger : MonoBehaviour
{
    private HudManager hudManager; // ✅ Référence au HUD
    private LaserManager laserManager; // ✅ Référence au HUD

    void Start()
    {
        hudManager = FindObjectOfType<HudManager>(); // 🔍 Trouve le HUD dans la scène
        laserManager = FindObjectOfType<LaserManager>(); // 🔍 Trouve le HUD dans la scène
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !laserManager.IsAlarmActive())
        {
            laserManager.activateAlarm();
        }
    }

    
}
