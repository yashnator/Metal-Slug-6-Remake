using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            SceneManager.LoadScene(1);
        }
    }
}
