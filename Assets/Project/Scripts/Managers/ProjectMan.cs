
using UnityEngine;



public class ProjectMan : MonoBehaviour
{
    public static ProjectMan inst;

    // Layer Masks
    public static int LayerMask_NAR_Ground;

    // Device
    public static bool test;
    public string deviceName;
    [SerializeField] GameObject AR, NAR;
    [SerializeField] Camera ARcam, NARcam;
    [HideInInspector] public Camera cam;


    void Awake()
    {
        inst = this;

        LayerMask_NAR_Ground = LayerMask.GetMask("NAR Ground");

        test = SystemInfo.deviceName == deviceName;
        AR.SetActive(!test);
        NAR.SetActive(test);
        if (test) cam = NARcam;
        else cam = ARcam;
    }
}
