
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class STMan : MonoBehaviour
{
    public static STMan inst;

    public SmoothTranslate target;

    public float translateTime;
    public AnimationCurve translateCurve;
    public ARRaycastManager arRaycastManager;
    public TMP_Text searchPlane, tapeToPlace;




    void Awake()
    {
        inst = this;
        target.gameObject.SetActive(false);
    }


    void Update()
    {
        if (target) {
            bool test = ProjectMan.test;
            Camera cam = ProjectMan.inst.cam;
            Vector3 pos;

            if ((test && Tool.MouseHit(cam, out pos, ProjectMan.LayerMask_NAR_Ground)) ||
                (!test && Tool.ScreenCenterHitAR(ProjectMan.inst.cam, arRaycastManager, out pos)))
            {
                /*
                // rotation
                Vector3 camProj = cam.transform.position;
                camProj.y = pos.y;
                Tool.LookDir(target, Tool.Dir(camProj, pos, false));
                */

                // position
                target.SetTarget(pos);

                // active
                if (!target.gameObject.active)
                {
                    target.gameObject.SetActive(true);
                    searchPlane.gameObject.SetActive(false);
                    tapeToPlace.gameObject.SetActive(true);
                }
            }


            if (target.gameObject.active && Tool.Click())
            {
                target = null;
                tapeToPlace.gameObject.SetActive(false);
            }
        }
    }


    public void SetTarget(SmoothTranslate target) => this.target = target;
}
