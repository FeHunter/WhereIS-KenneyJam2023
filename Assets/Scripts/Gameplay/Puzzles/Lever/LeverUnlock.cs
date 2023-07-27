using UnityEngine;

namespace Game {
    public class LeverUnlock : MonoBehaviour{

        bool _active, _over;
        public bool WithLever;
        public Transform Unlock, VFX, LeverCamera;
        float _moveDownTime;
        Transform _player;

        void Start(){
            _player = GameObject.Find("Player").GetComponent<Transform>();
        }

        void Update(){
            if (!_over){
                UnlockMoveDown ();
            }else {
                Unlock.gameObject.SetActive (false);
                LeverCamera.gameObject.SetActive (false);
                transform.GetChild(0).gameObject.SetActive (false);
                GetComponent<LeverUnlock>().enabled = false;
            }
        }

        void UnlockMoveDown (){

            if (FunctionsOnGame.Distance (transform, _player) <= 1 && WithLever){
                transform.GetChild(0).gameObject.SetActive (true); // Canva
                transform.GetChild(1).gameObject.SetActive (false); // Light
                if (Input.GetKeyDown("e")){
                    _active = true;
                    GetComponent<Animator>().Play ("use");
                }
            }else {
                transform.GetChild(0).gameObject.SetActive (false);
            }

            if (_active){
                _moveDownTime += 1*Time.deltaTime;
                if (_moveDownTime > 1f && _moveDownTime < 2f){
                    LeverCamera.gameObject.SetActive (true);
                    if (VFX != null){ VFX.gameObject.SetActive (true); }
                    Unlock.transform.Translate (0, -2f * Time.deltaTime, 0);
                }
                if (_moveDownTime >= 3f) {
                    _over = true;
                }
            }
        }
    }
}
