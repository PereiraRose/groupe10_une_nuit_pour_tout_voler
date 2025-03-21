using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckMission : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Inventory inv = Inventory.instance;

        List<string> forbiddenPaintings;
        bool missionCompleted = inv.HasCompletedMission(out forbiddenPaintings);

        if (forbiddenPaintings.Count > 0)
        {
            string forbiddenList = string.Join(", ", forbiddenPaintings);
            Debug.Log("❌ Mission échouée ! Tu as volé des œuvres interdites : " + forbiddenList);
        }
        else if (missionCompleted)
        {
            Debug.Log("✅ Mission réussie ! Tu as volé toutes les œuvres demandées !");
        }
        else
        {
            Debug.Log("❌ Mission incomplète... Il manque des œuvres !");
        }
    }
}

}
