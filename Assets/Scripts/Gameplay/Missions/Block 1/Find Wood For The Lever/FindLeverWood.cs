using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class FindLeverWood : MonoBehaviour{

        bool _finished;
        public bool WithW1, WithW2;
        public Transform Wood1, Wood2, VFX, LeverObj;
        public LeverUnlock Lever;
        public AudioSource[] Sounds;
        public GameObject MissionText, Hud;

        void Start(){
            LeverObj.gameObject.SetActive (false);
            // Lever.enabled = false;
        }

        void Update(){
            
            if (!_finished){
                GetWoods ();
                WithWood ();
                MountLever ();
            }else {
                Hud.SetActive (false);
            }
        }

        void GetWoods (){
            if (FunctionsOnGame.Distance (Wood1, FunctionsOnGame.PlayerTransform) <= 1 && Input.GetKeyDown("e") && !WithW1){
                WithW1 = true;
                Sounds[0].Play ();
            }
            if (FunctionsOnGame.Distance (Wood2, FunctionsOnGame.PlayerTransform) <= 1 && Input.GetKeyDown("e") && !WithW2){
                WithW2 = true;
                Sounds[0].Play ();
            }
        }

        void WithWood (){
            if (WithW1){
                Wood1.position = Vector3.MoveTowards (Wood1.position, new Vector3 (FunctionsOnGame.PlayerTransform.position.x+.2f, FunctionsOnGame.PlayerTransform.position.y + 1.5f, FunctionsOnGame.PlayerTransform.position.z), (FunctionsOnGame.PlayerScript.SpeedMove - 0.2f) * Time.deltaTime );
                Wood1.rotation = new Quaternion (180, 0, 0, 0);
            }
            if (WithW2){
                Wood2.position = Vector3.MoveTowards (Wood2.position, new Vector3 (FunctionsOnGame.PlayerTransform.position.x-.2f, FunctionsOnGame.PlayerTransform.position.y + 1.5f, FunctionsOnGame.PlayerTransform.position.z), (FunctionsOnGame.PlayerScript.SpeedMove - 0.2f) * Time.deltaTime );
                Wood2.rotation = new Quaternion (180, 0, 0, 0);
            }
        }

        void MountLever (){
            if (FunctionsOnGame.Distance (FunctionsOnGame.PlayerTransform, Lever.transform) <= 1 && WithW1 && WithW2){
                Hud.SetActive (true);
                if (Input.GetKeyDown("e")){
                    Invoke ("ActiveLever", 1);
                    Wood1.gameObject.SetActive (false);
                    Wood2.gameObject.SetActive (false);
                    LeverObj.gameObject.SetActive (true);
                    VFX.gameObject.SetActive (true);
                    _finished = true;
                }
            }else {
                Hud.SetActive (false);
            }

            // Show Text of the mission
            if (FunctionsOnGame.Distance (FunctionsOnGame.PlayerTransform, Lever.transform) <= 1 && ( !WithW1 || !WithW2)){
                MissionText.SetActive (true);
                Hud.SetActive (false);
            }else {
                MissionText.SetActive (false);
            }
        }

        void ActiveLever (){
            Lever.WithLever = true;
        }
    }
}
