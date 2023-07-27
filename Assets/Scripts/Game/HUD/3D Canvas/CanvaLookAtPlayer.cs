using UnityEngine;
using UnityEngine.UI;

namespace Game {
        public class CanvaLookAtPlayer : MonoBehaviour{

            Transform _camera;

        void Start(){
            _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().transform;
            GetComponent<Canvas>().worldCamera = _camera.GetComponent<Camera>();
        }

        void Update(){
            
            transform.LookAt (_camera.transform.position);
        }
    }
}
