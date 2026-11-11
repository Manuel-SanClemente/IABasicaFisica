using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TowerNPC : MonoBehaviour
{
    public GameObject bullet;
    public GameObject turret;
    public GameObject objective;
    public Transform turretCanon;
    public Transform turretTest;

    private float bulletSpeed = 15.0f;
    private float rotSpeed = 5.0f; // velocidade de rotación da unidade cara ao obxectivo

    static float delayReset = 1.2f;
    float delay = delayReset;

    void Update()
    {
        delay -= Time.deltaTime;

        Vector3 targetDirection = (objective.transform.position - turret.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(targetDirection.x, 0.0f, targetDirection.z));
        turret.transform.rotation = Quaternion.Slerp(turret.transform.rotation, lookRotation, Time.deltaTime * rotSpeed);

        float? angle = RotateTurret();

        if(angle != null && delay <= 0.0f)
        {
            CreateBullet();
            delay = delayReset;
        }

    }

    private void CreateBullet()
    {
        GameObject shell = Instantiate(bullet, turretCanon.transform.position, turretCanon.transform.rotation);
        shell.GetComponent<Rigidbody>().linearVelocity = bulletSpeed * turretCanon.forward;
    }

    private float? RotateTurret()
    {
        float? angle = CalculateAngle(true);

        if (angle != null)
        {
            turretCanon.localEulerAngles = new Vector3(360.0f -(float)angle, 0.0f, 0.0f);
        }

        return angle;
    }

    float? CalculateAngle(bool low)
    {
        Vector3 targetDir = objective.transform.position - this.transform.position;
        float y = targetDir.y; // altura relativa
        targetDir.y = 0.0f;
        float x = targetDir.magnitude - 1.0f; // distancia horizontal (axustada substraendo 1)
        float gravity = 9.8f;
        float sSqr = bulletSpeed * bulletSpeed;
        float underTheSqrRoot = (sSqr * sSqr) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (underTheSqrRoot >= 0.0f)
        {
            float root = Mathf.Sqrt(underTheSqrRoot);
            float highAngle = sSqr + root;
            float lowAngle = sSqr - root;

            if (low) return (Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg);
            else return (Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg);
        }
        else
            return null;
    }
}
