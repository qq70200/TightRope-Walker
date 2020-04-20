using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour {

    public PlaneCollider foot;
    public bool endR,endL;
    public GameObject success;
    public GameObject happy;
    public GameObject background;

    public float delay = 5f;
    [SerializeField]
    public float timeElapsed;

    // Use this for initialization
    void Start()
    {
        endR = false;
        endL = false;
        success.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(endR && endL)
        {
            foot.arrived = true;

            success.SetActive(true);
            Destroy(background);
            happy.SetActive(true);


            timeElapsed += Time.deltaTime;

            if(timeElapsed > delay)
            {
                SceneManager.LoadScene("Menu");
            }
            
        }
    }

   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Tracker 1(9)")
        {
            foot.Right = true;
            endR = true;
        }
        if (other.gameObject.name == "Tracker 2(7)")
        {
            foot.Left = true;
            endL = true;
        }
    }
}
