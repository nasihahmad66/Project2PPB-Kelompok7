using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopXBackground : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime / -9f;
        mat.mainTextureOffset = offset;
    }
}
