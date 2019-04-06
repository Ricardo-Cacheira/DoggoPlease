using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testCycle : MonoBehaviour
{
    public Canvas canvas;
    public TraitsDatabase data;
    public GameObject dogImage;
    internal List<Family> families = new List<Family>();
    private List<Dog> dogs = new List<Dog>();
    private Transform dogObj;
    private Transform familyObj;
    public Sprite[] sprites;
    internal Vector3 previousPos;
    internal bool picked;
    internal bool hovering;
    // Start is called before the first frame update
    void Start()
    {
        familyObj = canvas.transform.GetChild(0);
        dogObj = canvas.transform.GetChild(1);
        previousPos = dogImage.transform.position; 

        foreach(Transform t in familyObj.GetComponentInChildren<Transform>())
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
                    picked = true;
                    dogImage.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, dogImage.transform.position.z);
                }
                else if (picked)
                {
                    dogImage.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, dogImage.transform.position.z);
                }
            }
        }
        else if (!hovering)
        {
            dogImage.transform.position = previousPos;
        }
        else
            picked = false;

    }
}
