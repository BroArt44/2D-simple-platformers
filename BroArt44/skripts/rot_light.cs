using UnityEngine;

public class rot_light : MonoBehaviour
{
    public float minAngle = 0f;
    public float maxAngle = 360f;

    // Скорость поворота в градусах в секунду
    public float rotationSpeed = 25f;

    // Интервал времени (в секундах) между сменой направления
    public float changeDirectionInterval = 2f;

    private Quaternion targetRotation;
    private float timer;

    void Start()
    {
        SetRandomTargetRotation();
        timer = changeDirectionInterval;
    }

    void Update()
    {
        // Плавно поворачиваем к цели
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SetRandomTargetRotation();
            timer = changeDirectionInterval;
        }
    }

    void SetRandomTargetRotation()
    {
        float randomAngle = Random.Range(minAngle, maxAngle);
        targetRotation = Quaternion.Euler(0f, 0f, randomAngle);
    }
}