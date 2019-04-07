using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family
{
    public int aggregate;
    public string residence;
    public Sprite image;
    public List<Trait> prefenrences;
    public List<Trait> traits;

    public Family(int aggregate_, string residence_, Sprite image_, List<Trait> traits_, List<Trait> prefenrences_)
    {
        aggregate = aggregate_;
        residence = residence_;
        image = image_;
        prefenrences = prefenrences_;
        traits = traits_;
    }
}
