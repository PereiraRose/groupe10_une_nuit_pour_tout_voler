using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes

public class SceneLoadSettings : MonoBehaviour
{
    public void LoadSettings()
    {
        SceneManager.LoadScene("Réglages");
    }
}
