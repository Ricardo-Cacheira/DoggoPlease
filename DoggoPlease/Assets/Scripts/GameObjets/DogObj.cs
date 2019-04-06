using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogObj : MonoBehaviour
{
    private Sprite image;
    private string name;
    private string size;
    private string age;
    private string gender;
    private List<string> traits = new List<string>();
    private List<int> values = new List<int>();

    public Image imageComp;
    public Text nameComp;
    public Text sizeComp;
    public Text ageComp;
    public Text genderComp;
    public Text traitsComp;
	
	//FMOD 
	FMOD.Studio.EventInstance bark; 
	private bool hasBarked; 
	private int traitTest; 
	public int typingSecs;

    private void Start()
    {
        imageComp = transform.GetChild(1).GetComponent<Image>();
        nameComp = transform.GetChild(2).GetComponent<Text>();
        ageComp = transform.GetChild(3).GetComponent<Text>();
        sizeComp = transform.GetChild(4).GetComponent<Text>();
        genderComp = transform.GetChild(5).GetComponent<Text>();
        traitsComp = transform.GetChild(6).GetComponent<Text>();
        //    traits = GetComponentInChildren<Text>().text;

		//FMOD 
		hasBarked = false; 
		traitTest = 0;
		
    }

    public void Setup(Dog dog)
    {
        traits.Clear();
        image = dog.image;
        name = dog.name;
        size = dog.size;
        age = dog.age.ToString();
        if (dog.male)
            gender = "Male";
        else
            gender = "Female";

        foreach (Trait t in dog.traits)
        {
           values.Add(t.value);
           traits.Add(t.name);
        }


        imageComp.sprite = image;
        nameComp.text = name;
        sizeComp.text = size;
        ageComp.text = age;
        genderComp.text = gender;
        traitsComp.text = "";
        for (int i = 0; i < traits.Count; i++)
        {
            if (i > 0)
                traitsComp.text += " " + traits[i];
            else
                traitsComp.text += traits[i];
            
            Debug.Log(traits[i]);
        }

       	//FMOD 
		FMODBark(size);  

    }
	
	private void FMODBark(string size){ 
		//FMOD play dog bork. Size must be Large, Medium, or Small 
		//Debug.Log("barkSound"); 
		if(size=="Large"){ 
			bark = FMODUnity.RuntimeManager.CreateInstance("event:/dogs/big"); 
			bark.start(); 
		}else if(size=="Medium"){ 
			bark = FMODUnity.RuntimeManager.CreateInstance("event:/dogs/big"); 
			bark.start(); 
		}else if(size=="Small"){ 
			bark = FMODUnity.RuntimeManager.CreateInstance("event:/dogs/big"); 
			bark.start(); 
		}else{ 
			Debug.Log("Size error - must be 'big','medium',or 'small' - CASE SENSITIVE"); 
		} 
		
		//FMOD bark type relates to trait - has a priority list (there are no playeful agressive mixes, for example)	 
		while(hasBarked==false){ 
			if(traits[traitTest]=="Agressive"){ 
			bark.setParameterValue("trait",0); 
			Debug.Log("Barking as agressive"); 
			hasBarked = true; 
			} else if(traits[traitTest]=="Energetic"){ 
			bark.setParameterValue("trait",1); 
			Debug.Log("Barking as enegertic"); 
			hasBarked = true; 
			} else if(traits[traitTest]=="Calm"){ 
			bark.setParameterValue("trait",2); 
			Debug.Log("Barking as calm"); 
			hasBarked = true; 
			} else if(traits[traitTest]=="Playful"){ 
			bark.setParameterValue("trait",3); 
			Debug.Log("Barking as playful"); 
			hasBarked = true; 
			} else if(traits[traitTest]=="Noisy"){ 
			bark.setParameterValue("trait",4); 
			Debug.Log("Barking as noisy"); 
			hasBarked = true; 
			} else { 
				Debug.Log("Trait-sound relationship error - Trait may be poorly written (CASE SENSITIVE)"); 
				hasBarked = true; 
			} 
			traitTest=traitTest+1; 
		}
		
		if(hasBarked==true){
			StartCoroutine(waitStop());
		}
			
		
	}
	
	IEnumerator waitStop(){
		yield return new WaitForSeconds(typingSecs);
		bark.setParameterValue("stopType",1);
	}
	
	void OnDestroy() 
    { 
        bark.release(); 	
	}
}
