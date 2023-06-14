using UnityEngine;

public class MovingParticleSystem : MonoBehaviour
{
    public ParticleSystem movingParticles;
    public Transform mainCharacter;
    public float movementThreshold = 0.1f;

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = mainCharacter.position;
        movingParticles.Stop();
    }

    void Update()
    {
        if (Vector3.Distance(mainCharacter.position, previousPosition) > movementThreshold)
        {
            movingParticles.Play();
        }
        else
        {
            movingParticles.Stop();
        }

        previousPosition = mainCharacter.position;
    }
}

