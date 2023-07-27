using UnityEngine;

namespace Game {
    public class BrokeFence : MonoBehaviour{

        bool _broke, _destroy;

        void Start(){
            
        }

        void Update(){
            
            if (!_broke){
                Broke ();
            }
        }

        void Broke (){
            if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) <= 1 && !_destroy){
                if (FunctionsOnGame.PlayerScript.attacking){
                    transform.GetChild(0).gameObject.SetActive (false);
                    transform.GetChild(1).GetComponent<ParticleSystem>().Play ();
                    transform.GetChild(1).GetComponent<AudioSource>().Play ();
                    _broke = true;
                }
            }
        }
    }
}
