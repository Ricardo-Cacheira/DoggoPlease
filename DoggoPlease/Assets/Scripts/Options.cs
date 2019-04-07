using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public bool on = false;
    public bool cr = false;
    public GameObject panel;
    public GameObject credits;
    public SoundManager soundManager;
    public Slider st;
    public Slider sfx;

    void Start()
    {
        st.value = soundManager.volume1;
        sfx.value = soundManager.volume3;
    }

    public void Toggle()
    {
        on = !on;
        panel.SetActive(on);
    }

    public void Credits()
    {
        cr = !cr;
        credits.SetActive(cr);
    }

    public void UpdateValues()
    {
        soundManager.volume1 = (int)st.value;
        soundManager.volume2 = (int)st.value;
        soundManager.volume3 = (int)sfx.value;
    }
}
