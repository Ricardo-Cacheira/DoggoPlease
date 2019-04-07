﻿using UnityEngine;
using System.Collections.Generic;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class TraitsDatabase : ScriptableObject
{
	public Trait[] dogTraits;
	public Trait[] familyTraits;

	private static System.Random rnd = new System.Random();

	public List<Trait> GetList(bool dog, int amount)
	{
		List<Trait> list = new List<Trait>();
		for (int i = 0; i < amount; i++)
		{
			list.Add(GetNewTrait(list, dog));
		}
		return list;
	}

	public int EvaluteMatch(Dog dog, Family family)
	{
		int points = 0;
		
		if (dog.size.Equals(family.residence) || (dog.size == "Medium" &&  family.residence == "Large") || (dog.size == "Small" &&  (family.residence == "Large" || family.residence == "Medium")))
		{
			points++;
		}

		if (dog.size == "Large" && family.residence == "Small")
		{
			points--;
		}

		//check good
		foreach (var d in dog.traits)
		{
			foreach (var f in family.traits)
			{
				if(d.bestMatches.Contains(f)) {points++;}
				else if(d.badMatches.Contains(f)) {points--;}
					
			}
		}

		foreach (var p in family.prefenrences)
		{
			if(dog.traits.Contains(p)) {points++;}
		}

		return points;
	}

    public Trait GetNewTrait(List<Trait> previous, bool dog)
    {
        Trait n = RandomTrait(dog);
        //Still need to check for opposing traits, like energetic and calm
        while(Impossible(previous, n))
        {
            n = RandomTrait(dog);
        }
        return n;
    }

    private bool Impossible(List<Trait> check, Trait n)
    {
        bool i = false;
        
        foreach (var t in check)
		{
			if(t == n) {i = true; break;}

			if(n.conflicting.Contains(t)){i = true; break;}
		}

        return i;
    }

	private Trait RandomTrait(bool dog)
	{   
        if (dog)
        {
            int r = rnd.Next(dogTraits.Length);
            return dogTraits[r].GetCopy();
        }
        else
        {
            int r = rnd.Next(familyTraits.Length);
            return familyTraits[r].GetCopy();
        }
	}

    #region Editor
	#if UNITY_EDITOR
	private void OnValidate()
	{
		LoadTraits();
	}

	private void OnEnable()
	{
		EditorApplication.projectChanged -= LoadTraits;
		EditorApplication.projectChanged += LoadTraits;
	}

	private void OnDisable()
	{
		EditorApplication.projectChanged -= LoadTraits;
	}

	private void LoadTraits()
	{
		dogTraits = FindAssetsByType<Trait>("Assets/Traits/Dog");
		familyTraits = FindAssetsByType<Trait>("Assets/Traits/Family");
	}

	public static T[] FindAssetsByType<T>(params string[] folders) where T : UnityEngine.Object
	{
		string type = typeof(T).ToString().Replace("UnityEngine.", "");

		string[] guids;
		if (folders == null || folders.Length == 0) {
			guids = AssetDatabase.FindAssets("t:" + type);
		} else {
			guids = AssetDatabase.FindAssets("t:" + type, folders);
		}

		T[] assets = new T[guids.Length];

		for (int i = 0; i < guids.Length; i++)
		{
			string assetPath = AssetDatabase.GUIDToAssetPath(guids[i]);
			assets[i] = AssetDatabase.LoadAssetAtPath<T>(assetPath);
		}
		return assets;
	}
	#endif
    #endregion
}
