using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilieObj : MonoBehaviour
{
    private Sprite image;
    private string aggregate;
    private string residence;
    private List<string> traits = new List<string>();
    private List<string> preferences = new List<string>();
    // private List<int> traitsValues = new List<int>();

    private Image imageComp;
    private Text aggregateComp;
    private Text residenceComp;
    private Text traitComp;
    private Text preferencesComp;

    private Family currentFam;
    public GameObject dog;
    private Animator dogAnimator;
    private float timer;
    private bool animation;
    private testCycle cycle;
    private Vector3 origPos;
    private Transform parent;

    //FMOD #fudgeMaster
    private bool wooshPlayed;

    private void Start()
    {
        parent = transform.parent;
        origPos = dog.transform.position;
        dogAnimator = dog.GetComponent<Animator>();
        imageComp = transform.GetChild(1).GetComponent<Image>();
        aggregateComp = transform.GetChild(2).GetComponent<Text>();
        residenceComp = transform.GetChild(3).GetComponent<Text>();
        traitComp = transform.GetChild(4).GetComponent<Text>();
    }

    public void Setup(Family fam)
    {
        traits.Clear();
        preferences.Clear();
        image = fam.image;
        aggregate = fam.aggregate.ToString();
        residence = fam.residence;
        foreach (Trait t in fam.traits)
        {
            // traitsValues.Add(t.value);
            traits.Add(t.name);
        }
        foreach (Trait t in fam.prefenrences)
        {
            preferences.Add(t.name);
        }

        
        imageComp.sprite = image;
        aggregateComp.text = aggregate;
        residenceComp.text = residence;
        traitComp.text = "";
        for (int i = 0; i < traits.Count; i++) {
            if (i > 0)
                traitComp.text += " " + traits[i];
            else
                traitComp.text += traits[i];
        }
        //preferencesComp.text = "";
        //for (int i = 0; i < preferences.Count; i++) {
        //    if (i > 0)
        //        preferencesComp.text += " " + preferences[i];
        //    else
        //        preferencesComp.text += preferences[i];
        //}
        currentFam = fam;

        //FMOD #fudgeMaster
        wooshPlayed = false;

    }

    private void Update()
    {
        if (animation)
        {
            timer += 0.1f;
            if (timer > 3f)
            {
                GenerateNewSet(cycle);
                animation = false;
                timer = 0;
            }
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("Dawg"))
        {
            cycle = collision.transform.GetComponent<DogImageScript>().Cycle;
            cycle.hovering = true;
            if (!cycle.picked){
                dogAnimator.Play("MovePaperAnime", 0);
                transform.SetParent(dog.transform, true);
                animation = true;
                //FMOD #fudgeMaster
                if (wooshPlayed == false)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/woosh");
                    wooshPlayed = true;
                }
            }
        }
    }

    void GenerateNewSet(testCycle cycle)
    {
        if (cycle.currentindex != 0)
            cycle.dogqueue.RemoveAt(cycle.currentindex);
        if (cycle.dogqueue.Count < cycle.maximumnumberofdogs)
        {
            if (cycle.dogsinthisday <= 5)
                cycle.GenerateDog(cycle.DoggoName());
            cycle.dogsinthisday += 1;
        }
        if (cycle.pickednumber == 1)
            transform.position = cycle.previousPos;
        if (cycle.pickednumber == 2)
            transform.position = cycle.previousPos2;
        if (cycle.pickednumber == 3)
            transform.position = cycle.previousPos3;
        if (cycle.pickednumber == 4)
            transform.position = cycle.previousPos4;
        if (cycle.families.Count < cycle.numberofpeopleperday)
            cycle.GenerateFamily(transform);
        dog.transform.position = origPos;
        transform.SetParent(parent, true);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Dawg"))
        {
            testCycle cycle = other.transform.GetComponent<DogImageScript>().Cycle;
            cycle.hovering = false;
        }
    }
}
