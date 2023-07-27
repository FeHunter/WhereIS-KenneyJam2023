using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game {

        public class OpenChest : MonoBehaviour{

            public bool WithKey, Opened;
            public Transform Key;
            public GameObject ChestCanva, KeyCanva;
            public AudioSource[] Sounds;
            public string NextLevel;
            Transform _player;

        void Start(){
            _player = GameObject.Find("Player").GetComponent<Transform>();
        }

        void Update(){
            if (!Opened){
                GetKey ();
                OpenChestWithKey ();
            }
        }

        void GetKey (){
            if (FunctionsOnGame.Distance (_player, Key) <= 1 && Input.GetKeyDown("e") && !WithKey){
                WithKey = true;
                Sounds[0].Play ();
            }
            if (WithKey){
                Key.position = Vector3.MoveTowards (Key.position, new Vector3(_player.position.x, _player.position.y + 1, _player.position.z), (_player.GetComponent<Player>().SpeedMove / 1.2f) * Time.deltaTime);
                KeyCanva.SetActive (false);
            }else {
                FunctionsOnGame.ActiveHUD (KeyCanva, _player, Key, 1);
            }
        }

        void OpenChestWithKey (){
            if (!Opened){ FunctionsOnGame.ActiveHUD (ChestCanva, _player, transform, 1); }
            if (FunctionsOnGame.Distance (_player, transform) <= 1 && Input.GetKeyDown("e") && WithKey){
                Sounds[1].Play ();
                Opened = true;
                Key.gameObject.SetActive (false);
                ChestCanva.SetActive (false);
                GetComponent<Animator>().Play ("open");
                Invoke ("LoadNextLevel", 2);
            }
        }

        void LoadNextLevel (){
            SceneManager.LoadScene (NextLevel);
        }
    }

}
