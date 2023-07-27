using UnityEngine;

namespace Game {
        public class AutoOnOffHUD : MonoBehaviour{

            public float MinDistance;
            public GameObject Hud;

        void Update(){
            FunctionsOnGame.ActiveHUD(Hud, transform, FunctionsOnGame.PlayerTransform, MinDistance);
        }
    }
}
