using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anima;
    public static bool isDefence = false;

    private void Awake()
    {
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        Defence();
    }

    public void Defence()
    {
        if (isDefence)
        {
            anima.SetBool("Defence", true);
        }        
    }
}
