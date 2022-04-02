using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject successPanel;
    [SerializeField] private GameObject failPanel;

    private void Awake()
    {
        instance = this;
    }

    public void Retry()
    {
        Enemy.isDefence = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SuccessPanel()
    {
        StartCoroutine(SuccesPanelDelay());
    }

    public void FailPanel()
    {
        StartCoroutine(FailPanelDelay());
    }

    IEnumerator SuccesPanelDelay()
    {
        yield return new WaitForSeconds(2f);
        successPanel.SetActive(true);
    }

    IEnumerator FailPanelDelay()
    {
        yield return new WaitForSeconds(2f);
        failPanel.SetActive(true);
    } 
}
