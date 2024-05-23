using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform followTarget; // Персонаж, за которым следит питомец
    public Transform rotationTarget; // Таргет, в направлении которого будет поворачиваться питомец
    public float followSpeed; // Скорость, с которой питомец следует за персонажем
    public float maxDistance; // Максимальное расстояние между питомцем и персонажем
    public float minDistance; // Минимальное расстояние между питомцем и персонажем
    public Vector3 followOffset; // Отступ от персонажа, на котором находится питомец

    private Vector3 targetPosition; // Целевая позиция питомца
    private Quaternion targetRotation; // Целевое вращение питомца
    private Quaternion initialRotation; // Начальное вращение питомца относительно персонажа
    public Animator anim;
    public float jumpForce;
    
    private void Start()
    {
        // Сохраняем начальное вращение питомца относительно персонажа
        initialRotation = Quaternion.Inverse(followTarget.rotation) * transform.rotation;
    }

    private void Update()
    {
        // Вычисляем направление от питомца к персонажу
        Vector3 direction = followTarget.position - transform.position;

        // Если питомец находится слишком далеко от персонажа, перемещаем его ближе
        if (direction.magnitude > maxDistance)
        {
            targetPosition = followTarget.position - direction.normalized * maxDistance;
        }
        // Если питомец находится слишком близко к персонажу, перемещаем его дальше
        else if (direction.magnitude < minDistance)
        {
            targetPosition = followTarget.position - direction.normalized * minDistance;
        }
        // Иначе питомец находится в допустимом диапазоне расстояний и можно использовать его текущую позицию
        else
        {
            targetPosition = transform.position;
        }


        // Добавляем отступ к целевой позиции
        targetPosition += followOffset;

        // Плавно перемещаем питомца к целевой позиции
        Vector3 pos = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
		pos.y = followTarget.transform.position.y;
		transform.position = pos;


        // Поворачиваем питомца в направлении таргета
        Vector3 rotationDirection = rotationTarget.position - transform.position;
        targetRotation = Quaternion.LookRotation(rotationDirection);
   
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
        
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}




