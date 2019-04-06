using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
  


        public void GotoMainScene()
        {
        Invoke("LoadScene", 0.25f);        
        }

        public void LoadScene()
        {
        SceneManager.LoadScene("DiogoScene");
        }
    
}
