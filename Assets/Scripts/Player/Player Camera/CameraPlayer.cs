using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game {
    public class CameraPlayer : MonoBehaviour{

        public float SpeedFollow, SpeedRotate;
        public Transform Player;

        void Start(){
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Screen.SetResolution (1920, 1080, FullScreenMode.FullScreenWindow, Screen.currentResolution.refreshRateRatio);
        }

        void Update(){

            transform.position = Vector3.MoveTowards (transform.position, new Vector3 (Player.position.x, transform.position.y, Player.position.z), SpeedFollow * Time.deltaTime);

            transform.Rotate (0, Input.GetAxis("Mouse X") * SpeedRotate * Time.deltaTime, 0);
        }
    }
}
