using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;
    private List<string> PaintingsToSteal = new List<string>();
    public List<string> PlayerInventory = new List<string>();
    public List<string> GetPaintingsToSteal()
    {
        if(PaintingsToSteal.Count ==0)
        {
            SelectRandomPaintings();
        }
        return PaintingsToSteal;
    }
    public delegate void OnInventoryChanged();
    public event OnInventoryChanged InventoryChanged;


    // 📌 Liste des œuvres interdites
    private List<string> ForbiddenPaintings = new List<string>
    {
        "La Joconde",
        "Le portrait de Napoléon en costume de sacre",
        "Portrait de Vincent Van Gogh",
        "Le fils de l’homme",
        "Les 4 saisons",
        "Le rêve",
    };

    [SerializeField] private GameObject inventoryCanvas;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
{
    if (inventoryCanvas != null)
    {
        inventoryCanvas.SetActive(false);
    }
}

    void SelectRandomPaintings()
{
    PaintingsToSteal.Clear(); // Réinitialise la liste
    List<string> allPossiblePaintings = new List<string>
    {
        "La jeune fille à la perle",
        "Les 4 saisons",
        "Le rêve",
        "La Dame en bleu",
        "La Joconde",
        "Les Ménines",
        "Madame de Pompadour",
        "Autoportrait au collier d'épines et colibri",
        "Le fils de l'homme",
        "Portrait d’un homme au turban rouge",
        "Portrait de Napoléon en costume de sacre",
        "Portrait de Vincent van Gogh",
    };

    for (int i = 0; i < 3; i++)
    {
        if (allPossiblePaintings.Count == 0) break; // Sécurité

        int randomIndex = Random.Range(0, allPossiblePaintings.Count);
        PaintingsToSteal.Add(allPossiblePaintings[randomIndex]);
        allPossiblePaintings.RemoveAt(randomIndex); // Empêche les doublons
    }

    Debug.Log("🖼️ Nouveaux tableaux à voler : " + string.Join(", ", PaintingsToSteal));
}


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleInventory();
        }
    }

    void ToggleInventory()
    {
        if (inventoryCanvas != null)
        {
            bool isActive = inventoryCanvas.activeSelf;
            inventoryCanvas.SetActive(!isActive);
        }
    }

    public void AddItem(string item)
{
    if (!isInventoryFull())
    {
        if (!string.IsNullOrEmpty(item))
        {
            PlayerInventory.Add(item);
            Debug.Log("📦 Ajouté à l'inventaire : " + item);
            Debug.Log("📋 Contenu actuel de l'inventaire : " + string.Join(", ", PlayerInventory));

            InventoryChanged?.Invoke(); // Notifie l'UI que l'inventaire a changé
        }
    }
}



    public void DeleteItem(string item)
    {
        int id = PlayerInventory.FindIndex(x => x == item);
        if (id != -1)
        {
            PlayerInventory.RemoveAt(id);
            Debug.Log(item + " supprimé de l'inventaire");
        }
    }

    public bool isInventoryFull()
    {
        return PlayerInventory.Count >= 3;
    }

    // ✅ Vérifie si la mission est réussie ou échouée
    public bool HasCompletedMission(out List<string> forbiddenCollected)
{
    forbiddenCollected = new List<string>();

    Debug.Log("📌 Vérification des œuvres interdites...");
    foreach (string painting in ForbiddenPaintings)
    {
        if (PlayerInventory.Contains(painting))
        {
            forbiddenCollected.Add(painting);
        }
    }

    // Affiche les œuvres interdites détectées
    if (forbiddenCollected.Count > 0)
    {
        Debug.Log("❌ Œuvres interdites trouvées : " + string.Join(", ", forbiddenCollected));
        return false;
    }

    Debug.Log("✅ Aucun tableau interdit volé. Vérification des tableaux requis...");

    foreach (string painting in PaintingsToSteal)
    {
        if (!PlayerInventory.Contains(painting))
        {
            Debug.Log("❌ Il manque : " + painting);
            return false; // Si une œuvre manque, la mission est incomplète
        }
    }

    Debug.Log("✅ Mission réussie : toutes les œuvres requises ont été volées !");
    return true;
}


}
