using GangWar.UI.MobileMovement;
using UnityEngine;

namespace GangWar.GangLeader
{
    public class GangLeaderMobileMovement : GangLeaderMovement
    {
        [SerializeField] private GangLeaderSideMoves _sideMoves;
        [SerializeField] private LeftArrowButton _leftArrow;
        [SerializeField] private RightArrowButton _rightArrow;

        private void Start()
        {
            FreezeRotation();
        }

        private void FixedUpdate()
        {
            Move(transform.forward);

            if (_leftArrow.IsPressed == true)
            {
                _sideMoves.MoveLeft();
            }
            if (_rightArrow.IsPressed == true)
            {
                _sideMoves.MoveRight();
            }
        }
    }
}