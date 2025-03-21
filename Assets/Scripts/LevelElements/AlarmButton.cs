using UnityEngine;

public class AlarmButton : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private LaserManager laserManager; // Référence à l’alarme

    private void Start()
    {
        laserManager = FindObjectOfType<LaserManager>(); // Trouve l'alarme dans la scène
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (laserManager != null && laserManager.IsAlarmActive()) // ✅ Vérifie si l'alarme est activée
            {
                HudManager hud = HudManager.instance;

                if (hud != null)
                {
                    hud.showMessage("Désactiver l'alarme : E");
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            HudManager hud = HudManager.instance;
            if (hud != null)
            {
                hud.eraseMessage();
            }
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (laserManager != null && laserManager.IsAlarmActive()) // ✅ Vérifie si l’alarme est bien activée avant d'autoriser l'interaction
            {
                laserManager.DisableAlarm();
                HudManager hud = HudManager.instance;
                if (hud != null)
                {
                    hud.showMessage("Alarme Désactivée");
                }
            }
        }
    }
}
