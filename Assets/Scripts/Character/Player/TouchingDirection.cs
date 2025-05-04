using UnityEngine;

public class TouchingDirection : MonoBehaviour
{
    CapsuleCollider2D _tourchingCollider;
    
    RaycastHit2D[] _groundHits = new RaycastHit2D[5];
    [SerializeField] private float groundHitDistance = 0.1f;
    public bool _isGrounded = false;

    [SerializeField] private float wallHitDistance = 0.2f;
    RaycastHit2D[] _wallHits = new RaycastHit2D[5];
    public bool _isWalled = false;
    private Vector2 WallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _tourchingCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = _tourchingCollider.Cast(Vector2.down, _groundHits, groundHitDistance) >0 ;
        _isWalled = _tourchingCollider.Cast(WallCheckDirection, _wallHits, wallHitDistance) >0;
        Debug.Log($"Grounded {_isGrounded}");
        Debug.Log($"Wall {_isWalled}");
    }
}
