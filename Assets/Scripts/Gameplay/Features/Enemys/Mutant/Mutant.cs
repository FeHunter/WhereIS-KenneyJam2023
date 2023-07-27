using UnityEngine;
using UnityEngine.AI;

namespace Game {
    public class Mutant : MonoBehaviour{

        bool _live = true, _goToAttack, _getHit = true;
        int _escapePoint;
        Animator animator;
        NavMeshAgent _nav;
        public float Life = 2, Speed, MinDistance;
        public Transform[] EscapePoints;

        void Start(){
            animator = GetComponent<Animator>();
            _nav = GetComponent<NavMeshAgent>();
            _nav.speed = Speed;
        }

        void Update(){
            
            Animations ();
            if (_live){
                Move ();
                // GetHit ();
            }else {
                _nav.enabled = false;
            }
        }

        void Move (){
            if (_goToAttack){
                if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) <= 1){
                    Debug.Log ("Attack");
                    // Attack player
                    if (FunctionsOnGame.PlayerScript.attacking && _getHit){
                        Life --;
                        _getHit = false;
                        _goToAttack = false;
                    }
                }
                else if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) > 1){
                    // Fallow the player
                    _nav.SetDestination (FunctionsOnGame.PlayerTransform.position);
                    Debug.Log ("Following Player");
                }
            }else {
                // Escape from the player
                if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) < 3){
                    _nav.SetDestination ( - FunctionsOnGame.PlayerTransform.position);
                    Debug.Log ("Escaping");
                }else {
                    _goToAttack = true;
                    _getHit = true;
                    Debug.Log ("Back to attack");
                }
            }
        }

        void Animations (){
            if (_live){
                if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) <= 1){
                    // Attack
                    animator.SetInteger ("anim", 2);
                }else if (FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) >= 1 && FunctionsOnGame.Distance (transform, FunctionsOnGame.PlayerTransform) <= 3){
                    // Walk
                    animator.SetInteger ("anim", 1);
                }else {
                    // Idle
                    animator.SetInteger ("anim", 0);
                }
            }else {
                // Death
                animator.SetInteger ("anim", 3);
            }
        }
    }
}
