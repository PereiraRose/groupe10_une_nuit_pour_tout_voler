using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes

public class SceneChangerMenu : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
