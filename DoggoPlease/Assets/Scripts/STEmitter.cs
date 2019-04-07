using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STEmitter : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string soundtrackEvent;
	FMOD.Studio.EventInstance soundtrack;
	
	[Range(0,100)]
	public int volume;
	
    void Start()
    {
        soundtrack = FMODUnity.RuntimeManager.CreateInstance(soundtrackEvent);
        soundtrack.start();
		
		soundtrack.setParameterValue("STVolume", volume);
    }
	
	void Update(){
		soundtrack.setParameterValue("STVolume", volume);
	}
	
	void OnDestroy()
    {
        soundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
		soundtrack.release();
    }
	/*
	void OnDisable()
    {
		soundtrack.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        soundtrack.release();
    }
	*/
}
