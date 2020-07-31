using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

	public Transform mainCam;
    public Transform portalIn, portalOut;

	// Use this for initialization
	void Start () {
        SetupRenderTexture();
	}
	
	// Update is called once per frame
	void Update () {
        Offset();
    }

    void SetupRenderTexture ()
    {
        Camera cam = GetComponent<Camera>();
        if (cam.targetTexture != null)
            cam.targetTexture.Release();

        RenderTexture tex = new RenderTexture(Screen.width, Screen.height, 24);
        cam.targetTexture = tex;
        
        Renderer[] renderers = portalIn.GetComponentsInChildren<Renderer>();
        renderers[renderers.Length - 1].material.mainTexture = tex;
    }

    void Offset ()
    {
        Vector3 offset = portalIn.position - mainCam.position;

        transform.position = portalOut.position - offset;
        transform.rotation = mainCam.rotation;
    }
}
