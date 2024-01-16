using UnityEngine;

namespace GangWar.KillArea
{
    public class KillAreaMoveTo : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.position = _target.position;
        }
    }
}