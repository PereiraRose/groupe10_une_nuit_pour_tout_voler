using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes

public class SceneChangerRejouer : MonoBehaviour
{
    public void ReloadGame()
    {
        SceneManager.LoadScene("Museum TEST");
    }
}
