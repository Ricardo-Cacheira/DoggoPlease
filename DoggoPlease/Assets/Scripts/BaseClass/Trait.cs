using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Trait")]
[Serializable]
public class Trait : ScriptableObject
{
    public string name;
    public int value;
    [Space]
    public List<Trait> conflicting;
    [Space]
    public List<Trait> bestMatches;
    [Space]
    public List<Trait> badMatches;

    public virtual Trait GetCopy()
	{
		return this;
    }
}
