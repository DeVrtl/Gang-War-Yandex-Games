using UnityEngine;

namespace GangWar.GangLeader
{
    public class GangLeaderKeyboardStrafe : MonoBehaviour
    {
        [SerializeField] private GangLeaderSideMoves _sideMoves;

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _sideMoves.MoveLeft();
            }

            if (Input.GetKey(KeyCode.D))
            {
                _sideMoves.MoveRight();
            }
        }
    }
}