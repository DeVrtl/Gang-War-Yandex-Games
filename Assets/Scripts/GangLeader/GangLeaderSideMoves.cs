namespace GangWar.GangLeader
{
    public class GangLeaderSideMoves : GangLeaderMovement
    {
        public void MoveLeft()
        {
            Move(-transform.right);
        }

        public void MoveRight()
        {
            Move(transform.right);
        }
    }
}