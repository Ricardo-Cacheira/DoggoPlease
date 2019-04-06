using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dog
{
    public string name;
    public Sprite image;
    public int age;
    public string size;
    public bool male;
    public Trait[] traits;

    public Dog(string name_, Sprite image_, int age_, string size_, bool gender_, Trait[] traits_)
    {
        name = name_;
        image = image_;
        age = age_;
        size = size_;
        male = gender_;
        traits = traits_;
    }
}
