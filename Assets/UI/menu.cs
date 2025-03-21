using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneChanger : MonoBehaviour
{
    public UIDocument uiDocument; // Référence au document UI Toolkit
    public string sceneName = "Scene Rose"; // Nom de la scène pour le bouton "Jouer"
    public string legalSceneName = "MentionsLégales"; // Nom de la scène pour "Mentions Légales"

    void OnEnable()
    {
        // Vérifie si un UIDocument est assigné
        if (uiDocument == null)
        {
            Debug.LogError("⚠ UIDocument n'est pas assigné !");
            return;
        }

        // Récupère l'élément racine du document UI
        var root = uiDocument.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("⚠ Le rootVisualElement est null. Vérifiez votre UIDocument.");
            return;
        }

        // 🔹 Bouton "Jouer" (Change de scène)
        Button playButton = root.Q<Button>("playButton");
        if (playButton != null)
        {
            playButton.clicked += ChangeScene;
            Debug.Log("✅ Bouton 'playButton' correctement assigné !");
        }
        else
        {
            Debug.LogError("❌ Bouton 'playButton' non trouvé ! Vérifiez son ID dans UI Builder.");
        }

        // 🔹 Bouton "Mentions Légales"
        Button legalButton = root.Q<Button>("legalButton");
        if (legalButton != null)
        {
            legalButton.clicked += ChangeToLegalScene;
            Debug.Log("✅ Bouton 'legalButton' correctement assigné !");
        }
        else
        {
            Debug.LogError("❌ Bouton 'legalButton' non trouvé ! Vérifiez son ID dans UI Builder.");
        }

        // 🔹 Bouton "Quitter" (Ferme le jeu) → Correction du nom ici !
        Button quitButton = root.Q<Button>("quitButton"); // Nom corrigé
        if (quitButton != null)
        {
            quitButton.clicked += QuitGame;
            Debug.Log("✅ Bouton 'quitButton' correctement assigné !");
        }
        else
        {
            Debug.LogError("❌ Bouton 'quitButton' non trouvé ! Vérifiez son ID dans UI Builder.");
        }
    }

    // Fonction pour changer vers la scène principale
    void ChangeScene()
    {
        Debug.Log("🔄 Changement vers la scène : " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    // Fonction pour changer vers la scène des mentions légales
    void ChangeToLegalScene()
    {
        Debug.Log("🔄 Changement vers la scène : " + legalSceneName);
        SceneManager.LoadScene(legalSceneName);
    }

    // Fonction pour quitter le jeu
    void QuitGame()
    {
        Debug.Log("🚪 Fermeture du jeu...");
        Application.Quit();

        // Permet d'arrêter l'exécution si on est dans l'éditeur Unity
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
