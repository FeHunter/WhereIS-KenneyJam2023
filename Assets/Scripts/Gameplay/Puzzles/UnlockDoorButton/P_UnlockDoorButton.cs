using UnityEngine;

namespace  Game {
    public class P_UnlockDoorButton : MonoBehaviour{

        public Transform Block, Button, Door, DoorCamera, VFX;
        public PushItem ItemToPush;
        bool _finished;
        float _moveDorTime;

        void Start(){
            
        }

        void Update(){
            if (!_finished){
                CheckIfComplet ();
            }else {
                DoorCamera.gameObject.SetActive (false);
                GetComponent<P_UnlockDoorButton>().enabled = false;
            }
            
        }

        void CheckIfComplet (){
            if (FunctionsOnGame.Distance (Block, Button) <= .5f){
                ItemToPush.Over = true;
                DoorCamera.gameObject.SetActive (true);
                _moveDorTime += 1*Time.deltaTime;
                if (_moveDorTime >= 1f){
                    VFX.gameObject.SetActive (true);
                    Door.transform.Translate (0, -.5f*Time.deltaTime, 0);
                }
                if (_moveDorTime >= 2){
                    _finished = true;
                }
            }
        }
    }
}
