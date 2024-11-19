namespace GameNamespace.Enemy
{
    using UnityEngine;

    public class Waypoint : MonoBehaviour
    {
        public Transform[] waypoints;

        public Transform GetNextWaypoint(int currentWaypointIndex)
        {
            //// 現在のウェイポイントの次のウェイポイントを返します
            return waypoints[(currentWaypointIndex + 1) % waypoints.Length];
        }
    }
}
