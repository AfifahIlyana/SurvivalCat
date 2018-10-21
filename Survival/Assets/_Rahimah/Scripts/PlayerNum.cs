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
        SceneManager.LoadScene(1); //load main menu scene
    }
}
