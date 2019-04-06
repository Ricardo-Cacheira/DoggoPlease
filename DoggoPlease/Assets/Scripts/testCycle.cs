using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCycle : MonoBehaviour
{
    public Canvas canvas;
    public TraitsDatabase data;
    public GameObject family1;
    public GameObject family2;
    public GameObject family3;
    public GameObject family4;
    internal List<Family> families = new List<Family>();
    private List<Dog> dogs = new List<Dog>();
    private Transform dogObj;
    private Transform familyObj;
    public Sprite[] sprites;
    internal Vector3 previousPos;
    internal Vector3 previousPos2;
    internal Vector3 previousPos3;
    internal Vector3 previousPos4;
    internal bool picked;
    internal bool hovering;
    internal int pickednumber;

    // Start is called before the first frame update
    void Start()
    {
        familyObj = canvas.transform.GetChild(2);
        dogObj = canvas.transform.GetChild(1);
        previousPos = family1.transform.position;
        previousPos2 = family2.transform.position;
        previousPos3 = family3.transform.position;
        previousPos4 = family4.transform.position;

        foreach (Transform t in familyObj.GetComponentInChildren<Transform>())
        {
            GenerateFamily(t);
        }

        GenerateDog("Doggo");
      //  dogs.Add(currentDog);
    }

    public void GenerateFamily(Transform t)
    {
        Family currentFam = new Family(Random.Range(1, 5), getRandomSize(), sprites[Random.Range(0, 4)], data.familyTraits);
        FamilieObj familyObjScript = t.GetComponent<FamilieObj>();
        familyObjScript.Setup(currentFam);
        families.Add(currentFam);
    }

    public void GenerateDog(string name)
    {
        Dog currentDog = new Dog(name, sprites[Random.Range(0, 4)], Random.Range(0, 20), getRandomSize(), true, data.GetList(true, 2));
        DogObj dogObjScript = dogObj.GetComponent<DogObj>();
        dogObjScript.Setup(currentDog);
    }

    string getRandomSize()
    {
        int r = Random.Range(0, 3);
        switch (r)
        {
            case 0:
                return "Small";
            case 1:
                return "Medium";
            case 2:
                return "Large";
        }
        return null;
            
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitinfo))
            {
                if (hitinfo.transform.CompareTag("Dog"))
                {
                    pickednumber = 1;
                    picked = true;
                    family1.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family1.transform.position.z);
                }
                if (hitinfo.transform.CompareTag("Family1"))
                {
                    pickednumber = 2;
                    picked = true;
                    family2.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family2.transform.position.z);
                }
                if (hitinfo.transform.CompareTag("Family2"))
                {
                    pickednumber = 3;
                    picked = true;
                    family3.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family3.transform.position.z);
                }
                if (hitinfo.transform.CompareTag("Family3"))
                {
                    pickednumber = 4;
                    picked = true;
                    family4.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family4.transform.position.z);
                }
                if (picked)
                {   if(pickednumber == 1)
                        family1.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family1.transform.position.z);
                    if (pickednumber == 2)
                        family2.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family2.transform.position.z);
                    if (pickednumber == 3)
                        family3.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family3.transform.position.z);
                    if (pickednumber == 4)
                        family4.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family4.transform.position.z);
                }
            }
        }
        else if (!hovering)
        {
            if (pickednumber == 1)
                family1.transform.position = previousPos;
            if (pickednumber == 2)
                family2.transform.position = previousPos2;
            if (pickednumber == 3)
                family3.transform.position = previousPos3;
            if (pickednumber == 4)
                family4.transform.position = previousPos4;
        }
        else
            picked = false;

    }
}
