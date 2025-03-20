using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneChanger : MonoBehaviour
{
    public UIDocument uiDocument;
    public string sceneName = "Scene Rose";

    void OnEnable()
    {
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument n'est pas assigné !");
            return;
        }

        var root = uiDocument.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("Le rootVisualElement est null. Vérifiez votre UIDocument.");
            return;
        }

        Button playButton = root.Q<Button>("playButton");
        if (playButton == null)
        {
            Debug.LogError("Bouton 'playButton' non trouvé ! Vérifiez son ID dans UI Builder.");
            return;
        }

        playButton.clicked += ChangeScene;
        Debug.Log("Bouton 'playButton' correctement assigné !");
    }

    void ChangeScene()
    {
        Debug.Log("Changement vers la scène : " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
