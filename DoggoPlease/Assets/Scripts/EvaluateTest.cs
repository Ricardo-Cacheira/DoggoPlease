using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvaluateTest : MonoBehaviour
{
    public TraitsDatabase data;

    public List<Trait> dog;
    public List<Trait> family;
    public List<Trait> preferences;

    private void Start() {
        Debug.Log(data.EvaluteMatch(dog,family,preferences));
    }

}
