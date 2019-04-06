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

    public List<Trait> conflicting;

    public virtual Trait GetCopy()
	{
		return this;
    }
}
