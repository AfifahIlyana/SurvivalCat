using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerNum : MonoBehaviour {

    public static int CharacterNum;
    public void playerselect(int selectedNum)
    {
        CharacterNum = selectedNum;
        SceneManager.LoadScene(0); //load main menu scene
    }
}
