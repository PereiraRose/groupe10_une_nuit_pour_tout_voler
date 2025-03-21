using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Référence au texte UI
    private float timeRemaining = 300f; // 5 minutes (300 secondes)
    private bool isRunning = true; // Pour savoir si le timer est en cours

    void Start()
    {
        StartCoroutine(StartCountdown()); // Démarrer le décompte
    }

    IEnumerator StartCountdown()
    {
        Debug.Log("⏳ Démarrage du timer...");
        while (timeRemaining > 0) // Tant que le temps n'est pas écoulé
        {
            timeRemaining -= 1; // Diminue de 1 seconde
            UpdateTimerDisplay(); // Met à jour l'affichage
            yield return new WaitForSeconds(1); // Attend 1 seconde
        }

        isRunning = false; // Timer terminé
        timerText.text = "Temps écoulé !"; // Affiche un message
        SceneManager.LoadScene("GameOver"); // Charge la scène "Game Over"
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}"; // Format 00:00
    }

    public void RemoveTime(int seconds)
    {
    timeRemaining -= seconds; // Enlève du temps
    if (timeRemaining < 0) timeRemaining = 0; // Empêche d'avoir un temps négatif
    UpdateTimerDisplay(); // Met à jour le texte
    }
}
