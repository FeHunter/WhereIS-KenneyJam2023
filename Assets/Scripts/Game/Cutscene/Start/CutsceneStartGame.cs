using UnityEngine;

namespace Game {
    public class CutsceneStartGame : MonoBehaviour{

        public float CutsceneTime;
        public GameObject Cutscene;
        float _endTime;

        void Start(){
            Player.Control = false;
            Cutscene.SetActive (true);
        }

        void Update(){
            
            _endTime += 1 * Time.deltaTime;
            if (_endTime >= CutsceneTime){
                Cutscene.SetActive (false);
                Player.Control = true;
            }
        }
    }
}
