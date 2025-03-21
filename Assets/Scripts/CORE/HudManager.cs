using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HudManager : MonoBehaviour
{
	[SerializeField] private GameObject canvasAlerte; // 🎨 Canvas qui affiche le message d'alarme
	[SerializeField] private TMP_Text alerteMessageText; // 📝 Texte qui affichera l'alarme

	public static HudManager instance = null;
	
	private int pv_max = 100;
	private int pv = 100;
	private Item item = Item.None;
	
	[SerializeField] private GameObject hud_message;
	[SerializeField] private GameObject panel_pause;
	
	[SerializeField] private float delay_message = 3.0f; //Temps où le message reste à l'écran
	private bool has_message = false;
	private float timer_message = 0f;
	
	public static bool pause = false;
	public void ShowAlarmMessage()
{
    if (canvasAlerte != null && alerteMessageText != null)
    {
        canvasAlerte.SetActive(true); // ✅ Active le Canvas
        alerteMessageText.text = "Retournez à l'entrée pour désactiver l'alarme !"; // 📝 Met à jour le texte
        StartCoroutine(HideAlarmAfterDelay(10f)); // ⏳ Cache après 30s
    }
}

public void HideAlarmMessage()
{
    if (canvasAlerte != null)
    {
        canvasAlerte.SetActive(false); // ❌ Cache le Canvas
    }
}

// ⏳ Coroutine pour cacher l’alarme après un délai
private IEnumerator HideAlarmAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    HideAlarmMessage();
}

	//Ajouter les sprites des items ici
	[SerializeField] private Sprite[] item_sprites;
	
	//Pattern singleton, pour récupérer facilement un objet unique dans le jeu
	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
        if(hud_message == null){
			Debug.Log("hud mal configuré");
		}
		
		hud_message.SetActive(false);
		
		AudioManager am = AudioManager.instance;
		am.PlayMusic(am.music_list.music1);
		
		panel_pause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(has_message){
			//Si le temps d'affichage est terminé, on enlève le message de l'écran
			if(timer_message <= 0){
				timer_message = 0;
				has_message = false;
				hud_message.SetActive(false);
			} else {
				//On enlève le temps écoulé à chaque appel d'Update
				timer_message -= Time.deltaTime;
			}
		}
		
		//Si on appuie sur P
		if(Input.GetKeyDown(KeyCode.P)){
			pause = !pause;
			panel_pause.SetActive(pause);
			if(pause){
				Time.timeScale = 0.0f;
			} else {
				Time.timeScale = 1.0f;
			}
		}
    }
	//Afficher un message momentanément
	public void showMessage(string message){
		hud_message.SetActive(true);
		hud_message.GetComponent<TMP_Text>().SetText(message);
		has_message = false;
		timer_message = 0;
	}
	
	public void eraseMessage(){
		hud_message.SetActive(false);
	}
	
	public void showTimedMessage(string message){
		hud_message.SetActive(true);
		hud_message.GetComponent<TMP_Text>().SetText(message);
		
		timer_message = delay_message;
		has_message = true;
	}
}

//Liste des items du jeu
public enum Item
{
	None,
	ClassicKey,
}



