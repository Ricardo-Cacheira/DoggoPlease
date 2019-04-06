using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXEmitter : MonoBehaviour
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
		
		soundtrack.setParameterValue("SFXVol", volume);
    }
	
	void Update(){
		soundtrack.setParameterValue("SFXVol", volume);
	}
	
	void OnDestroy()
    {
        soundtrack.release();
    }
}
