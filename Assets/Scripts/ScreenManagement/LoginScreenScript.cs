using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreenScript : MonoBehaviour {

    public void CreateNewAccount_Click()
    {
        SceneManager.LoadScene("RegisterScreen");
    }
}
