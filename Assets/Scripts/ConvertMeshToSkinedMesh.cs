using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertMeshToSkinedMesh : MonoBehaviour
{
    [ContextMenu("Convert to Skined mesh")]
    void Convert()
    {
        if (GetComponent<MeshRenderer>())
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            MeshFilter filter = GetComponent<MeshFilter>();
            SkinnedMeshRenderer skinnedMeshRenderer = gameObject.AddComponent<SkinnedMeshRenderer>();



            skinnedMeshRenderer.sharedMesh = filter.mesh;
            skinnedMeshRenderer.sharedMaterials = meshRenderer.sharedMaterials;
            DestroyImmediate(filter);
            DestroyImmediate(meshRenderer);
            DestroyImmediate(this);

        }
    }

}

