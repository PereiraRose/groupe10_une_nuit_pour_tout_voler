using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject target;
    private bool isVisible = true;
    private bool isPlayerNearby = false; // Le joueur est proche ou non
    public string itemName; // 🔹 Ajout : Nom de l'objet à ajouter à l'inventaire

    // Start is called before the first frame update
    void Start()
    {}
    // Update is called once per frame
    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E)) // Si le joueur est proche et appuie sur E
        {

            Inventory inv = Inventory.instance; //On récupère le hud

            if (!isVisible) {
                inv.DeleteItem(itemName); 
                isVisible = !isVisible; // Inverse l'état de visibilité
            } else {
                if (inv.isInventoryFull()){
                    HudManager hud = HudManager.instance; //On récupère le hud
                    hud.showMessage("Inventaire plein");
                }
                else {
                    inv.AddItem(itemName); // Ajoute l'œuvre à l'inventaire
                    isVisible = !isVisible; // Inverse l'état de visibilité
                }
            }
            
            target.SetActive(isVisible); // Cache ou affiche l'œuvre
        }
    }

    // Détection quand le joueur entre dans la zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si c'est bien le joueur
        {
            isPlayerNearby = true;
            HudManager hud = HudManager.instance; //On récupère le hud
            hud.showMessage("Intéragir : E");
        }
    }

    // Détection quand le joueur sort de la zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNearby = false;
            HudManager hud = HudManager.instance; //On récupère le hud
            hud.eraseMessage();
        }
    }
}
