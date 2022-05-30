using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Start at first waypoint in path
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            Vector3 targetPos = MoveToWaypoint();

            // Increments waypoint index when the target waypoint is reached
            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Vector3 MoveToWaypoint()
    {
        var targetPos = waypoints[waypointIndex].transform.position;
        var movementThisFrame = waveConfig.MoveSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
        return targetPos;
    }
}
