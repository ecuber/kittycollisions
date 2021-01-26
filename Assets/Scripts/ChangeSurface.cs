using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeSurface : MonoBehaviour
{
    public List<PhysicMaterial> materials;
    public int index;
    public static ChangeSurface Instance;
    public Dropdown dropdown;


    void Start()
    {
        index = PlayerPrefs.GetInt("Index", 0);
    }

    void Update()
    {
        index = PlayerPrefs.GetInt("Index");

        if (dropdown.value != index)
        {
            dropdown.value = index;
            dropdown.RefreshShownValue();
        }


        if (materials[index] != GetComponent<BoxCollider>().material)
        {
            GetComponent<BoxCollider>().material = materials[index];
        }
    }

    public void setMaterial(int mat)
    {
        GetComponent<BoxCollider>().material = materials[mat];
        PlayerPrefs.SetInt("Index", mat);
    }
}
