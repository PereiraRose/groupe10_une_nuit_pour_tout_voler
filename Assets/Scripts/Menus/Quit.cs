using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    public void QuitGame()
    {
        // Quitte l'application
        Application.Quit();
        
        // Fonctionne seulement dans l'éditeur Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
