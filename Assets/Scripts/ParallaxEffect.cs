using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Transform followTarget;
    [SerializeField] private float parallaxFactor = 5;

    Vector2 startingPosition;
    Vector2 camMoveSinceStart => (Vector2)camera.transform.position - startingPosition;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
    }
}
