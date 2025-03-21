using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LaserManager : MonoBehaviour
{
    private bool alarmTriggered = false;
    public AudioSource alarmSound;
    public GameObject alarmLight;
    public float alarmDuration = 15f; // Durée de l'alarme (15 secondes)
    
    // Référence au gestionnaire de HUD pour afficher le Game Over
    public HudManager hudManager; 

    // Start is called before the first frame update
    void Start()
    {
        if (alarmLight != null)
            alarmLight.SetActive(false);
    }

    // Méthode pour activer l'alarme et commencer le timer
    public void ActivateLaserAlarm()
    {
        if (!alarmTriggered)
        {
            alarmTriggered = true;
            Debug.Log("🚨 Alarme activée !");
            
            // Afficher le message de l'alarme et démarrer le timer
            HudManager.instance.ShowAlarmMessage(); // Affiche le message de l'alarme et le timer

            if (alarmSound != null)
                alarmSound.Play();

            if (alarmLight != null)
                alarmLight.SetActive(true);

            // Démarrer le timer de 15 secondes
            StartCoroutine(AlarmTimer());
        }
    }

    // Coroutine qui gère le timer
    private IEnumerator AlarmTimer()
    {
        float timer = alarmDuration;
        while (timer > 0)
        {
            timer -= Time.deltaTime; // Décrémenter le timer en fonction du temps passé
            yield return null;
        }

        // Lorsque le timer atteint zéro, Game Over
        GameOver();
    }

    // Méthode pour désactiver l'alarme et réinitialiser
    public void DisableAlarm()
    {
        alarmTriggered = false;
        HudManager.instance.HideAlarmMessage(); // Cache le message quand l'alarme est désactivée

        if (alarmSound != null)
            alarmSound.Stop();

        if (alarmLight != null)
            alarmLight.SetActive(false);
    }

    // Méthode pour afficher Game Over après 15 secondes
    private void GameOver()
    {
        Debug.Log("💥 Game Over!");

        // Afficher le message de "Game Over" dans l'UI
        SceneManager.LoadScene("GameOver"); // Charge la scène "Game Over"

        // Optionnel : vous pouvez ajouter d'autres actions ici pour le Game Over, comme arrêter le jeu ou revenir au menu principal.
    }

    // Vérifier si l'alarme est active
    public bool IsAlarmActive()
    {
        return alarmTriggered;
    }
}
