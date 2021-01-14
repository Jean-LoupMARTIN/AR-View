
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class InteractionMan : MonoBehaviour
{
    public static InteractionMan inst;

    public Transform target;
    public float rotSpeed = 1, scaleSpeed = 1, scaleMin = 0.5f, scaleMax = 2;

    bool fingers;
    Vector2 finger1, finger2;



    void Awake()
    {
        inst = this;
    }




    void Update()
    {
        if (target) {

            UpdateFingers();

            if (fingers)
            {
                Vector2 newFinger1 = Input.GetTouch(0).position;
                Vector2 newFinger2 = Input.GetTouch(1).position;
                Vector2 dNewFinger = newFinger1 - newFinger2;
                Vector2 dLastFinger = finger1 - finger2;


                // scale
                float lastDist = dLastFinger.magnitude;
                float newDist = dNewFinger.magnitude;
                float dDist = newDist - lastDist;
                float scale = target.localScale.x + dDist / 1000 * scaleSpeed;
                scale = Mathf.Clamp(scale, scaleMin, scaleMax);
                target.localScale = scale * Vector3.one;

                // rotation
                float lastAngle = Tool.Angle(dLastFinger);
                float newAngle = Tool.Angle(dNewFinger);
                float rot = newAngle - lastAngle;
                target.Rotate(0, rot * rotSpeed * 2, 0);


                finger1 = newFinger1;
                finger2 = newFinger2;
            }
        }
    }


    // met à jour fingers : true si deux doigts sur l'ecran, false sinon
    void UpdateFingers() {

        if (!fingers)
        {
            if (Input.touchCount >= 2)
            {
                fingers = true;
                finger1 = Input.GetTouch(0).position;
                finger2 = Input.GetTouch(1).position;
            }
        }
        else if (Input.touchCount < 2)
            fingers = false;
    }
}
