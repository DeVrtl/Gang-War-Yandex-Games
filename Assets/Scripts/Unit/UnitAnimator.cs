using UnityEngine;

namespace GangWar.Unit
{
    public class UnitAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public void Play(UnitAnimations state)
        {
            _animator.Play(state.ToString());
        }
    }
}