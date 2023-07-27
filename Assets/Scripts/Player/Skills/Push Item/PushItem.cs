using UnityEngine;
using UnityEngine.UI;

namespace Game {
    public class PushItem : MonoBehaviour{
    
        bool flag;
        public bool Over, Pushing;
        public float MinDistance;
        public Sprite PushingOn, PushingOff;
        public Image StatusIcon;
        Transform _player;

        void Start(){
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        void Update(){
            
            if (!Over){

                FunctionsOnGame.ActiveHUD(transform.GetChild(0).gameObject, transform, _player, 1);
                if (FunctionsOnGame.Distance (transform,_player) <= MinDistance){
                    if (Player.ObjectOnView == this.name){
                        if (Input.GetKeyDown("e")){
                            Pushing = !Pushing;
                        }
                    }
                }
                if (FunctionsOnGame.Distance (transform,_player) > MinDistance){
                    Pushing = false;
                }

                if (Pushing){
                    StatusIcon.sprite = PushingOn;
                    transform.parent = _player;
                    Player.Push = true;
                }else {
                    StatusIcon.sprite = PushingOff;
                    transform.parent = null;
                    if (FunctionsOnGame.Distance (transform,_player) <= MinDistance * 2){
                        Player.Push = false;
                    }
                }
            }else {
                if (!flag){
                    Player.Push = false;
                    transform.parent = null;
                    transform.GetChild(0).gameObject.SetActive (false);
                    GetComponent<PushItem>().enabled = false;
                    flag = true;
                }
            }
        }
    }
}
