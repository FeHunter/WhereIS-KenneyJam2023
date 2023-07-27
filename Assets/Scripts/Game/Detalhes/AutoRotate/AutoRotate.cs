using UnityEngine;

public class AutoRotate : MonoBehaviour{

    public bool X, Y, Z;
    public float Speed;

    void Start(){
        
    }

    void Update(){
        
        if (X){ transform.Rotate (Speed, 0, 0); }
        if (Y){ transform.Rotate (0, Speed, 0); }
        if (Z){ transform.Rotate (0, 0, Speed); }
    }
}
