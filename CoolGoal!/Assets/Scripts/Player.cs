using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{    
    public Ball ball;

    private void OnTriggerEnter(Collider other)
    {
        ball.isKick = true;
    }
}
