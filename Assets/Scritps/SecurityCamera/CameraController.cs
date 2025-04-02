using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private PlayerModel playerModel;
    private CameraModel model;
    private LineOfSight los;

    private void Awake()
    {
        playerModel = target.GetComponent<PlayerModel>();
        model = GetComponent<CameraModel>();
        los = GetComponent<LineOfSight>();
    }

    private void Update()
    {
        model.IsDetecting = target && playerModel.IsDetectable && los.CheckDistance(target) && los.CheckAngle(target) && los.CheckView(target);
    }
}
