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

    private Image imageComp;
    private Text nameComp;
    private Text sizeComp;
    private Text ageComp;
    private Text genderComp;
    private Text traitsComp;

    private void Start()
    {
        imageComp = transform.GetChild(0).GetComponent<Image>();
        nameComp = transform.GetChild(1).GetComponent<Text>();
        ageComp = transform.GetChild(2).GetComponent<Text>();
        sizeComp = transform.GetChild(3).GetComponent<Text>();
        genderComp = transform.GetChild(4).GetComponent<Text>();
        traitsComp = transform.GetChild(5).GetComponent<Text>();
        //    traits = GetComponentInChildren<Text>().text;


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
        }

    }
}
