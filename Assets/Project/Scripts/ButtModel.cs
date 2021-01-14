using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtModel : MonoBehaviour
{
    public List<GameObject> models;
    int i = 0;

    void Start()
    {
        foreach (GameObject model in models)
            model.SetActive(false);

        models[0].SetActive(true);
    }

    
    public void ChangeModel()
    {
        models[i].SetActive(false);
        i++;
        i %= models.Count;
        models[i].SetActive(true);
    }
}
