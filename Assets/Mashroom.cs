using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Mashroom : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcess;
    [SerializeField] private HealthManager healthManager;
    [SerializeField] private MeshRenderer mesh;
    [SerializeField] private Collider collider;
    [SerializeField] private float jumpMultiplayer;
    [SerializeField] private float speedMultiplayer;
    [SerializeField] private float damagePerSecond;
    [SerializeField] private int duration;

    private bool isActive;
    private async void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent(out PlayerController playerController))
        {
            postProcess.enabled = true;
            playerController.moveSpeed *= speedMultiplayer;
            playerController.jumpForce *= jumpMultiplayer;
            isActive = true;
            mesh.enabled = false;
            collider.enabled = false;
            await Task.Delay(duration * 1000);
            mesh.enabled = true;
            collider.enabled = true;
            isActive = false;
            postProcess.enabled = false;
            playerController.moveSpeed /= speedMultiplayer;
            playerController.jumpForce /= jumpMultiplayer; 
        }
    }


    private void Update()
    {
        if (isActive)
        {
            healthManager.HurtPlayer((int)(damagePerSecond * Time.deltaTime));            
        }
    }
}
