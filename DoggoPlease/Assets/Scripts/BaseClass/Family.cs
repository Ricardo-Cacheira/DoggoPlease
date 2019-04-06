using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Family
{
    public int aggregate;
    public string residence;
    public Sprite image;
    public Trait[] prefencers;

    public Family(int aggregate_, string residence_, Sprite image_, Trait[] traits_)
    {
        aggregate = aggregate_;
        residence = residence_;
        image = image_;
        prefencers = traits_;
    }
}
