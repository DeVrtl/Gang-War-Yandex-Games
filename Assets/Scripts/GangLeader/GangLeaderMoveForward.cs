namespace GangWar.GangLeader
{
    public class GangLeaderMoveForward : GangLeaderMovement
    {
        private void FixedUpdate()
        {
            Move(transform.forward);
        }
    }
}