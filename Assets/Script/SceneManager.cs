using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneManager : MonoBehaviour
{
   public void LoadNewScene(string newScene)
   {
      UnityEngine.SceneManagement.SceneManager.LoadScene(newScene);
   }
}
