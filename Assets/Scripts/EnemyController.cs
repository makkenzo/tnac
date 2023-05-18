using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [Header("Settings")]
    public float movementSpeed = 2f;
    public Transform[] waypoints;
    [SerializeField] private Energy _energy;
    [SerializeField] protected Transform energyLossPos;

    [Header("Doors")]
    [SerializeField] private ButtonController door1;
    [SerializeField] private ButtonController door2;
    [SerializeField] private ButtonController door3;

    private Transform currentWaypoint;
    private bool isDead = false;
    private bool isNearbyPosition = false;
    private float timer = 0f;

    private void Start()
    {
        currentWaypoint = waypoints[0];
        InvokeRepeating("TeleportToRandomWaypoint", 15f, 15f);
    }

    private void Update()
    {
        if (currentWaypoint.name == "P3.1" && !door1.doorIsOpen)
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
                Invoke("LoadDeadScene", 0f);
        }
        else if (currentWaypoint.name == "P4.1" && !door3.doorIsOpen)
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
                Invoke("LoadDeadScene", 0f);
        }
        else if (currentWaypoint.name == "P1.1" && !door2.doorIsOpen)
        {
            timer += Time.deltaTime;

            if (timer >= 10f)
                Invoke("LoadDeadScene", 0f);
        }

        if (!isDead && _energy.energy <= 95f)
        {
            isDead = true;
            Invoke("SendEnemyToEnergyLossPosition", 5f);
            Invoke("LoadDeadScene", 10f);
        }
    }

    private void TeleportToRandomWaypoint()
    {
        if (!isDead)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            currentWaypoint = waypoints[randomIndex];

            if (currentWaypoint.CompareTag("Aisle"))
            {
                if (!isNearbyPosition)
                {
                    Transform farPos = GetAisleFarPosition(currentWaypoint);

                    if (farPos != null)
                    {
                        transform.position = farPos.position;
                        transform.rotation = farPos.rotation;

                        currentWaypoint = farPos;
                    }
                    isNearbyPosition = true;
                }
                else
                {
                    Transform nearbyPos = GetAisleNearbyPosition(currentWaypoint);

                    if (nearbyPos != null)
                    {
                        transform.position = nearbyPos.position;
                        transform.rotation = nearbyPos.rotation;

                        currentWaypoint = nearbyPos;
                    }
                }
            }
            else
            {
                transform.position = currentWaypoint.position;
                transform.rotation = currentWaypoint.rotation;
                isNearbyPosition = false;

                currentWaypoint = transform;
            }
        }
    }

    private Transform GetAisleFarPosition(Transform aisle)
    {
        string roomName = aisle.name.Substring(0, aisle.name.IndexOf('.'));
        string farPositionName = roomName + ".2";

        foreach (Transform waypoint in waypoints)
        {
            if (waypoint.name == farPositionName)
            {
                return waypoint;
            }
        }
        return null;
    }

    private Transform GetAisleNearbyPosition(Transform aisle)
    {
        foreach (Transform waypoint in waypoints)
        {
            if (waypoint.name.EndsWith(".1"))
            {
                return waypoint;
            }
        }
        return null;
    }

    private void SendEnemyToEnergyLossPosition()
    {
        transform.position = energyLossPos.position;
        transform.rotation = energyLossPos.rotation;

        currentWaypoint = energyLossPos;
    }

    private void LoadDeadScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
