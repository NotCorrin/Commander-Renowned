using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EnchantedMeshApply : MonoBehaviour
{
    public Transform EnchantPoint;
    public Material EnchantMaterial;

    private List<Material> rendererMaterials = new List<Material>();
    private MeshRenderer[] meshRenderers;

    void Start()
    {
        rendererMaterials.Clear();

        meshRenderers = this.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            bool haveEffect = false;
            foreach (Material mat in meshRenderer.sharedMaterials)
            {
                rendererMaterials.Add(mat);
                if (mat == EnchantMaterial)
                {
                    haveEffect = true;
                }
            }
            if (haveEffect != true)
            {
                rendererMaterials.Add(EnchantMaterial);
                meshRenderer.sharedMaterials = rendererMaterials.ToArray();
            }
        }
    }

    void Update()
    {
        foreach (MeshRenderer mr in meshRenderers)
        {
            var mats = mr.sharedMaterials;
            if (Application.isPlaying)
            {
                mats = mr.materials;
            }
            foreach (Material mat in mats)
            {
                mat.SetVector("_EnchantPoint", EnchantPoint.position);
                mat.SetFloat("_DistanceOffsetScale", EnchantPoint.transform.localScale.x);
            }
        }

    }
}