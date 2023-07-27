using UnityEngine;

namespace Game {
    public class FunctionsOnGame : Player {

        static public float Distance (Transform transform1, Transform transform2){
            return Vector3.Distance (transform1.position, transform2.position);
        }

        static public void ActiveHUD (GameObject hud, Transform transform1, Transform transform2, float MinDistance){
            if (Distance (transform1, transform2) <= MinDistance){
                hud.SetActive (true);
            }else {
                hud.SetActive (false);
            }
        }
    }
}
