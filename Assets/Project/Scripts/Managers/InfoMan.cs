
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class InfoMan : MonoBehaviour
{
    public static InfoMan inst;

    public float distDisplay = 1;
    public TMP_Text txtInfo;
    Info crtInfo = null;


    void Awake() { inst = this; }



    void Update()
    {
        Info target = null;

        Transform cam = ProjectMan.inst.cam.transform;

        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit))
            target = hit.collider.GetComponent<Info>();

        if (target && Tool.Dist(cam, target) < distDisplay)
        {
            if (target != crtInfo) {
                if (crtInfo) crtInfo.Hide();
                crtInfo = target;
                crtInfo.Display();
            }
        }

        else if (crtInfo) {
            crtInfo.Hide();
            crtInfo = null;
        }
    }
}
