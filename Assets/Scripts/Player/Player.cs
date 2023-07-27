using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game {
    public class Player : MonoBehaviour{

        float _activeAttackTime;
        bool _doAttack, _atkAnimation;

        [Header ("Player Movements")]
        public float SpeedMove, SpeedRotate, Gravity;

        [Header ("Skills")]
        public static bool Control = true, Push;
        public bool Life, Sword, attacking;

        public AudioSource[] Sounds;
        public GameObject SwordObj;

        public static string ObjectOnView { get; set; }

        Animator _animator;
        float _defaultSpeed, _defaultRotate, _rot;
        CharacterController _controller;
        Vector3 _rotation;
        Vector3 _move;

        public static Transform PlayerTransform {get; set;}
        public static Player PlayerScript {get; set;}

        void Awake (){
            PlayerTransform = this.transform;
            PlayerScript = this.GetComponent<Player>();
        }

        void Start(){

            Life = true;

            _controller = GetComponent<CharacterController>();
            _animator = transform.GetChild(0).GetComponent<Animator>();

            _defaultSpeed = SpeedMove;
            _defaultRotate = SpeedRotate;
        }

        void Update(){
                        
            if (Control && Life){
                Move ();
                AttackSword ();
            }

            if (!Life){
                _animator.SetInteger ("anim", 4); // Death
                Sounds[0].enabled = false; // Walking
                Sounds[1].enabled = false; // Pushing
                Invoke ("ReloadScene", 5);
            }
        }

        void ReloadScene (){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        void AttackSword (){
            SwordObj.SetActive (Sword);
            if (Input.GetMouseButtonDown(0) && Sword && !_doAttack){
                _doAttack = true;
            }
            
            if (_doAttack){
                _activeAttackTime += 1*Time.deltaTime;
                if (_activeAttackTime >= .7f){
                    attacking = true;
                }
                if (_activeAttackTime >= 1.2f){
                    _doAttack = false;
                }
                _atkAnimation = true;
            }else {
                _activeAttackTime = 0;
                attacking = false;
                _atkAnimation = false;
            }
        }

        void Move (){
            if (_controller.isGrounded){
                if (Input.GetKey("w") && !_atkAnimation){
                    _move = Vector3.forward * SpeedMove * Time.deltaTime;
                }else if (Input.GetKey("s") && !_atkAnimation){
                    _move = Vector3.back * SpeedMove * Time.deltaTime;
                }else {
                    _move = Vector3.zero;
                }
            }

            if (!Push){
                _rot += Input.GetAxis("Horizontal") * SpeedRotate * Time.deltaTime;
                transform.eulerAngles = new Vector3 (0, _rot, 0);
            }

            _move.y -= Gravity * Time.deltaTime;

            _move = transform.TransformDirection (_move);
            _controller.Move (_move);

            // Speed Control
            if (Push){
                SpeedMove = (_defaultSpeed / 2);
                SpeedRotate = (_defaultRotate / 2);
            }else {
                SpeedMove = _defaultSpeed;
                SpeedRotate = _defaultRotate;
            }

            AnimationAndSoundsEffects ();
            OnPlayerView ();
        }

        void AnimationAndSoundsEffects (){
            // Default
            if (!Push && !_atkAnimation) {
                if (Input.GetKey("w") || Input.GetKey("s")){
                    _animator.SetInteger ("anim", 1);
                    Sounds[0].enabled = true; // Walking
                    Sounds[1].enabled = false; // Pushing
                }else {
                    _animator.SetInteger ("anim", 0);
                    Sounds[0].enabled = false; // Walking
                    Sounds[1].enabled = false; // Pushing
                }
            }
            // Pushing
            else if (Push){
                if (Input.GetKey("w") || Input.GetKey("s")){
                    _animator.SetInteger ("anim", 2);
                    Sounds[0].enabled = false; // Walking
                    Sounds[1].enabled = true; // Pushing
                }else {
                    _animator.SetInteger ("anim", 0);
                    Sounds[0].enabled = false; // Walking
                    Sounds[1].enabled = false; // Pushing
                }   
            }
            // Attacking
            else if (_atkAnimation ){
                _animator.SetInteger ("anim", 3); // Attack
                
                Sounds[0].enabled = false; // Walking
                Sounds[1].enabled = false; // Pushing
            }
        }

        void OnPlayerView (){
            RaycastHit hit;
            Ray ray = new Ray (new Vector3 (transform.position.x, transform.position.y+.5f, transform.position.z), transform.forward);
            if (Physics.Raycast (ray, out hit, 1f)) {
                if (hit.collider){
                    ObjectOnView = hit.collider.name;
                }else {
                    ObjectOnView = "";
                }
            }else {
                ObjectOnView = "";
            }
        }

        void OnTriggerEnter (Collider other){
            if (other.tag == "Enemy"){
                Life = false;
            }
        }
    
    }
}
