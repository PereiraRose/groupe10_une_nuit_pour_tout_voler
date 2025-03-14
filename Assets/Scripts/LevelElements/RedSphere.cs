using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSphere : MonoBehaviour
{
 
 [SerializeField] private int degats = 25;

    private bool active = true;

    void OnTriggerEnter(Collider col){
        HudManager hud = HudManager.instance;
        if(col.gameObject.tag == "Player" && active){
            active = false;
            hud.subPV(degats);
            Debug.Log("Joueur touché");
            Destroy(this.gameObject);
        }
    }
}
