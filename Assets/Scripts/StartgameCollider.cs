using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartgameCollider : MonoBehaviour {

    public PlaneCollider foot;

    // Use this for initialization
    void Start()
    {
        foot.Right = true;
        foot.Left = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tracker 1(9)")
        {
            foot.Right = true;
        }
        if (other.gameObject.name == "Tracker 2(7)")
        {
            foot.Left = true;
        }
    }


}
