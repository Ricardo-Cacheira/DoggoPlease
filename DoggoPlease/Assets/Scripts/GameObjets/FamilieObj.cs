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
    private void Start()
    {
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
        preferencesComp.text = "";
        for (int i = 0; i < preferences.Count; i++) {
            if (i > 0)
                preferencesComp.text += " " + preferences[i];
            else
                preferencesComp.text += preferences[i];
        }
        currentFam = fam;

    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.CompareTag("Dawg"))
        {
            testCycle cycle = collision.transform.GetComponent<DogImageScript>().Cycle;
            cycle.hovering = true;
            if (!cycle.picked){
                cycle.GenerateDog("Another Doggo");
                if (cycle.pickednumber == 1)
                    transform.position = cycle.previousPos;
                if (cycle.pickednumber == 2)
                    transform.position = cycle.previousPos2;
                if (cycle.pickednumber == 3)
                    transform.position = cycle.previousPos3;
                if (cycle.pickednumber == 4)
                    transform.position = cycle.previousPos4;
                cycle.GenerateFamily(transform);
            }
        }
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
