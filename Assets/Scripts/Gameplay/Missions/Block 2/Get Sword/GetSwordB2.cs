using UnityEngine;

namespace Game {
    public class GetSwordB2 : MonoBehaviour{

        bool withSword;

        void Start(){
            
        }

        void Update(){
            if (!withSword){
                GetSword ();
            }
        }

        void GetSword (){

            // Rotate sword
            transform.GetChild(0).Rotate (0, 5, 0);

            if (FunctionsOnGame.Distance (FunctionsOnGame.PlayerTransform, transform) <= 1){
                transform.GetChild(1).gameObject.SetActive (true); // Canva
                if (Input.GetKeyDown("e")){
                    FunctionsOnGame.PlayerScript.Sword = true;
                    transform.GetChild(0).gameObject.SetActive (false); // Sword
                    transform.GetChild(1).gameObject.SetActive (false); // Canva
                    GetComponent<AudioSource>().Play ();
                    withSword = true;
                }
            }else {
                transform.GetChild(1).gameObject.SetActive (false); // Canva
            }
        }
    }
}
