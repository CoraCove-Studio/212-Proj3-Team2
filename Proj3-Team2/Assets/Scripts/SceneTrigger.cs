using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    [Header("Assigned In Inspector")]
    [SerializeField] private GameObject player;
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In, sceneName));
    }

    public void OnClickReset()
    {
        SceneManager.LoadScene(sceneName);
    }
}
