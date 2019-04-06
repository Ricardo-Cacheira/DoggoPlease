using Olisipo.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager: PersistentSingleton<SoundManager>
{
    [FMODUnity.EventRef]
    public string soundtrackEvent;
    public FMOD.Studio.EventInstance soundtrack;
    [Range(0, 100)]
    public int volume1;

    [FMODUnity.EventRef]
    public string soundtrackEvent2;
    public FMOD.Studio.EventInstance soundtrack2;
    [Range(0, 100)]
    public int volume2;

    [FMODUnity.EventRef]
    public string ambientEvent;
    public FMOD.Studio.EventInstance ambient;
    [Range(0, 100)]
    public int volume3;

    // Start is called before the first frame update
    void Start()
    {
        soundtrack = FMODUnity.RuntimeManager.CreateInstance(soundtrackEvent);
        soundtrack2 = FMODUnity.RuntimeManager.CreateInstance(soundtrackEvent2);
        ambient = FMODUnity.RuntimeManager.CreateInstance(ambientEvent);

        soundtrack.setParameterValue("STVolume", volume1);
        soundtrack2.setParameterValue("STVolume", volume2);
        ambient.setParameterValue("SFXVol", volume3);

        soundtrack.start();

    }
    public virtual void ChangeToOtherMusic() {

        FMODUnity.RuntimeManager.PlayOneShot("event:/gameEnter");

        soundtrack.setParameterValue("menuEnd", 1);

        soundtrack2.start();
        ambient.start();
    }

    private void Update()
    {
        soundtrack.setParameterValue("STVolume", volume1);
        soundtrack2.setParameterValue("STVolume", volume2);
        ambient.setParameterValue("SFXVol", volume3);
    }

    public void playOnHover()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/paperPickUp");
    }

    public void buttonClick()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/buttonClick");
    }

    /*
    public virtual void ChangeTo(string myParameter, int secondValue)
    {
        soundtrack.setParameterValue(myParameter, secondValue);
    }
    */
}
