using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Sphere столкнулся с объектом " + other.gameObject.name);
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
