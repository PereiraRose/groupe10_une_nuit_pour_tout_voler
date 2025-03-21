using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    private bool alarmTriggered = false;
    public AudioSource alarmSound;
    public GameObject alarmLight;
    // Start is called before the first frame update
    void Start()
    {
        if (alarmLight != null)
            alarmLight.SetActive(false);
    }

    public bool IsAlarmActive()
    {
        return alarmTriggered;
    }

    public void activateAlarm() {
            alarmTriggered = true;
            Debug.Log("🚨 Alarme activée !");
            
            HudManager.instance.ShowAlarmMessage(); // ✅ Affiche le message et le timer de 30s

            if (alarmSound != null)
                alarmSound.Play();

            if (alarmLight != null)
                alarmLight.SetActive(true);
    }

    public void DisableAlarm()
    {
        alarmTriggered = false;
        HudManager.instance.HideAlarmMessage(); // ✅ Cache le message quand l’alarme est désactivée

        if (alarmSound != null)
            alarmSound.Stop();

        if (alarmLight != null)
            alarmLight.SetActive(false);
    }
}
