using UnityEngine;

namespace Game {

        public class PlayByDistance : MonoBehaviour{

            public float distance = 3;
            Transform _player;
            AudioSource audioSource;

            void Start () {
                _player = GameObject.FindGameObjectWithTag("Player").transform;
                audioSource = GetComponent<AudioSource>();
            }

            void Update(){
                if (FunctionsOnGame.Distance (transform, _player) <= distance){
                    audioSource.enabled = true;
                }else {
                    audioSource.enabled = false;
                }
            }
    }
}
