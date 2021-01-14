
using UnityEngine;



public class SmoothTranslate : MonoBehaviour
{
    float t = 0;

    Vector3 targetPos, lastPos;

    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
            float progress = 1 - Tool.Progress(t, STMan.inst.translateTime);
            if (progress >= 1) transform.position = targetPos;
            else transform.position = lastPos + (targetPos - lastPos) * STMan.inst.translateCurve.Evaluate(progress);
        }
    }

    public void SetTarget(Vector3 targetPos)
    {
        if (gameObject.active)
        {
            this.targetPos = targetPos;
            lastPos = transform.position;
            t = STMan.inst.translateTime;
        }
        else transform.position = targetPos;
    }
}
