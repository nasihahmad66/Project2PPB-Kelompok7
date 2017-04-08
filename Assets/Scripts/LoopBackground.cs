using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopBackground : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime / 7.5f;
        mat.mainTextureOffset = offset;
    }
}
