using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTexture : MonoBehaviour{

    public bool X, Y;
    public float Speed;
    public Vector2 Offset;
    float _offset;
    MeshRenderer _renderer;

    void Start(){
        _renderer = GetComponent<MeshRenderer>();
    }

    void Update(){
        
        if (X){ Offset.x += Speed * Time.deltaTime; }
        if (Y){ Offset.y += Speed * Time.deltaTime; }

        _renderer.material.SetTextureOffset("_MainTex", Offset);
    }
}
