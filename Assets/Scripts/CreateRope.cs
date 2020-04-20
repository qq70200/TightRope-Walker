using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Valve.VR;


public class CreateRope : MonoBehaviour
{
    public GameObject rope;

    void Start()
    {
        resizePlatform();
    }

    public void resizePlatform()
    {
        var rect = new HmdQuad_t();
        if (!SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect))
            return;
        var corners = new HmdVector3_t[] { rect.vCorners0, rect.vCorners1, rect.vCorners2, rect.vCorners3 };
        Vector3 temp = transform.localScale;
        temp.x = Mathf.Abs(corners[0].v0 - corners[1].v0);
        temp.z = Mathf.Abs(corners[0].v2 - corners[3].v2);
        transform.localScale = temp;

        rope.transform.localScale = new Vector3(temp.x, (float)0.01, (float)0.05);


        //Used to move objects after the room has changed.
        //GameObject.Find("Level").BroadcastMessage("reposition");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        var rect = new HmdQuad_t();
        if (!SteamVR_PlayArea.GetBounds(SteamVR_PlayArea.Size.Calibrated, ref rect))
            return;
        var corners = new HmdVector3_t[] { rect.vCorners0, rect.vCorners1, rect.vCorners2, rect.vCorners3 };
        for (int i = 0; i < corners.Length; i++)
        {
            if (i == 0)
                Gizmos.color = Color.yellow;
            else if (i == 1)
                Gizmos.color = Color.blue;
            else if (i == 2)
                Gizmos.color = Color.green;
            else if (i == 3)
                Gizmos.color = Color.white;
            var c = corners;
            Gizmos.DrawSphere(new Vector3(c[2].v0, 0.01f, c[2].v2), 0.5f);
        }

    }
    

}
