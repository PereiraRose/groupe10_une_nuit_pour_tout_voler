using UnityEngine;

public class AlarmButton : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private LaserManager laserManager; // Référence à la gestion de l'alarme

    private void Start()
    {
        laserManager = FindObjectOfType<LaserManager>(); // Trouve le LaserManager dans la scène
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            if (laserManager != null && laserManager.IsAlarmActive()) // Vérifie si l'alarme est activée
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
                hud.eraseMessage(); // Efface le message quand le joueur quitte la zone
            }
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) // Si le joueur est à proximité et appuie sur "E"
        {
            if (laserManager != null && laserManager.IsAlarmActive()) // Vérifie si l'alarme est activée
            {
                laserManager.DisableAlarm(); // Désactive l'alarme
                HudManager hud = HudManager.instance;
                if (hud != null)
                {
                    hud.showMessage("Alarme Désactivée"); // Affiche un message de confirmation
                }
            }
        }
    }
}
