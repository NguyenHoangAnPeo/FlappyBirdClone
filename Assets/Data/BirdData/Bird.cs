using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<Animator>().Play("BirdFlap");
        Debug.Log("Bird Start Flap");
    }
}
