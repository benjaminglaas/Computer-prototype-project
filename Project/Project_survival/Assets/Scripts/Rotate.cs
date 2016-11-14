using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    public float tumble;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
    }

}
