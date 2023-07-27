using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {

    public class SpikeBall : MonoBehaviour{

        public float Speed;
        public Transform[] GoTo;
        int _GoToIndex;

        void Start(){
            _GoToIndex = Random.Range(0, GoTo.Length);
        }

        void Update(){
                        
            if (_GoToIndex >= GoTo.Length) {
               _GoToIndex = 0;
            }else {
                transform.position = Vector3.MoveTowards (transform.position, new Vector3 (GoTo[_GoToIndex].position.x, transform.position.y, GoTo[_GoToIndex].position.z), Speed * Time.deltaTime);
            }

            if (FunctionsOnGame.Distance (transform, GoTo[_GoToIndex]) <= .1f) {
                _GoToIndex ++;
            }

            // Hit on player
            if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) <= .4f) {
                FunctionsOnGame.PlayerScript.Life = false;
            }


        }
    }
}
