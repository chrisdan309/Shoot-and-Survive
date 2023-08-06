using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public float ScrollSpeed = 1.18f;
    public float offset;
    private Material mat;
    void Start()
    {
        ScrollSpeed = 1.18f;
        Cursor.visible = true;
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * ScrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
