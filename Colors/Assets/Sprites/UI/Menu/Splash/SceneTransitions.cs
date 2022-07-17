using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneName;

    public static int signalToChange;

    void Awake(){
        signalToChange = 0;
    }

    void Update(){
        if (signalToChange == 1){
            StartCoroutine(LoadScene());
        }
    }

    IEnumerator LoadScene(){
        if (transitionAnim != null){
            transitionAnim.SetTrigger("fadeIn");
            yield return new WaitForSeconds(2f);
        }
        SceneManager.LoadScene(sceneName);
        yield return null;
    }
}
