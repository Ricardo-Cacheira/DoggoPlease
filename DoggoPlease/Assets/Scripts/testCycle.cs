using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    internal List<Dog> dogqueue = new List<Dog>();
    private List<Dog> dogs = new List<Dog>();
    private Transform dogObj;
    private Transform familyObj;
    public Sprite[] spritesD;
    public Sprite[] spritesH;
    internal Vector3 previousPos;
    internal Vector3 previousPos2;
    internal Vector3 previousPos3;
    internal Vector3 previousPos4;
    internal bool picked;
    internal bool hovering;
    internal int pickednumber;
    internal int currentindex;
    [SerializeField]
    internal int numberofdogsperday;
    [SerializeField]
    internal int numberofpeopleperday;
    [SerializeField]
    internal int maximumnumberofdogs;
    internal int dogsinthisday;
    int numberofsprite;

    // Start is called before the first frame update
    void Start()
    {
        maximumnumberofdogs = 10;
        numberofdogsperday = 5;
        numberofpeopleperday = 20;
        familyObj = canvas.transform.GetChild(4);
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
        int numberofpeople = Random.Range(1, 5);

        if (numberofpeople == 1)
        {
            numberofsprite = Random.Range(0, 3);
        }

        if (numberofpeople == 2)
        {
            numberofsprite = Random.Range(3, 7);
        }

        if (numberofpeople == 3)
        {
            numberofsprite = Random.Range(7, 9);
        }

        if (numberofpeople == 4)
        {
            numberofsprite = Random.Range(9, 11);
        }
        Family currentFam = new Family(numberofpeople, getRandomSize(), spritesH[numberofsprite], data.GetList(false,2), data.GetList(true,1));
        FamilieObj familyObjScript = t.GetComponent<FamilieObj>();
        familyObjScript.Setup(currentFam);
        families.Add(currentFam);
    }

    public void GenerateDog(string name)
    {
        Dog currentDog = new Dog(name, spritesD[Random.Range(0, 5)], Random.Range(0, 20), getRandomSize(), true, data.GetList(true, 2));
        DogObj dogObjScript = dogObj.GetComponent<DogObj>();
        dogqueue.Add(currentDog);
        currentindex = dogqueue.Count - 1;
        
        dogObjScript.Setup(dogqueue[currentindex]);
      
    }
    
    public void AddDogToQueue()
    {
        if (dogqueue.Count < numberofdogsperday)
        {
            Dog currentDog = new Dog(name, spritesD[Random.Range(0, 8)], Random.Range(0, 20), getRandomSize(), true, data.GetList(true, 2));
            DogObj dogObjScript = dogObj.GetComponent<DogObj>();
            dogsinthisday += 1;
            dogqueue.Add(currentDog);
            currentindex = dogqueue.Count - 1;
            dogObjScript.Setup(dogqueue[currentindex]);
        }
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
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitinfo))
            {
                if (hitinfo.transform.CompareTag("Dog") && !picked)
                {
                    pickednumber = 1;
                    picked = true;
                    family1.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family1.transform.position.z);
					FMODUnity.RuntimeManager.PlayOneShot("event:/paperPickUp", transform.position);
                }
                if (hitinfo.transform.CompareTag("Family1") && !picked)
                {
                    pickednumber = 2;
                    picked = true;
                    family2.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family2.transform.position.z);
					FMODUnity.RuntimeManager.PlayOneShot("event:/paperPickUp", transform.position);
                }
                if (hitinfo.transform.CompareTag("Family2") && !picked)
                {
                    pickednumber = 3;
                    picked = true;
                    family3.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family3.transform.position.z);
					FMODUnity.RuntimeManager.PlayOneShot("event:/paperPickUp", transform.position);
                }
                if (hitinfo.transform.CompareTag("Family3") && !picked)
                {
                    pickednumber = 4;
                    picked = true;
                    family4.transform.position = new Vector3(hitinfo.point.x, hitinfo.point.y, family4.transform.position.z);
					FMODUnity.RuntimeManager.PlayOneShot("event:/paperPickUp", transform.position);
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
            picked = false;
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
