using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Light directionalLight;
    public ReflectionProbe reflectionProbe;
    public Material daySkyboxMaterial;
    public Material nightSkyboxMaterial;
    public Transform prefabHolder;
    public Text text;

    private Transform[] prefabs;
    private List<Transform> lt;
    private int activeNumber = 0;

	void Start () {

        lt = new List<Transform>();
        prefabs = prefabHolder.GetComponentsInChildren<Transform>(true);

        foreach (Transform tran in prefabs)
        {
            if (tran.parent == prefabHolder)
            {
                lt.Add(tran);
            }
        }

        prefabs = lt.ToArray();
        EnableActive();
    }

    // Turn On active VFX Prefab
    public void EnableActive()
    {
        for (int i = 0; i < prefabs.Length; i++)
        {
            if (i == activeNumber)
            {
                prefabs[i].gameObject.SetActive(true);
                //prefabs[i].gameObject.active = true;

                text.text = prefabs[i].name;
            }
            else
            {
                prefabs[i].gameObject.SetActive(false);
                //prefabs[i].gameObject.active = false;
            }
        }
    }

    // Change active VFX
    public void ChangeEffect(bool bo)
    {
        if (bo == true)
        {
            activeNumber++;
            if (activeNumber == prefabs.Length)
            {
                activeNumber = 0;
            }
        }
        else
        {
            activeNumber--;
            if (activeNumber == -1)
            {
                activeNumber = prefabs.Length - 1;
            }
        }

        EnableActive();
    }

    public void SetDay()
    {
        directionalLight.enabled = true;
        reflectionProbe.RenderProbe();
        RenderSettings.skybox = daySkyboxMaterial;
    }

    public void SetNight()
    {
        directionalLight.enabled = false;
        reflectionProbe.RenderProbe();
        RenderSettings.skybox = nightSkyboxMaterial;
    }


    // TEMP
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetDay();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SetNight();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeEffect(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeEffect(false);
        }
    }
}
