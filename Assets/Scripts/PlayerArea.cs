using UnityEngine;

public class PlayerArea : MonoBehaviour
{
    public Collider areaCollider; // 範囲を示すコライダー

    private Vector3 minBounds;
    private Vector3 maxBounds;

    void Start()
    {
        if (areaCollider != null)
        {
            Bounds bounds = areaCollider.bounds;
            minBounds = bounds.min;
            maxBounds = bounds.max;
        }
        else
        {
            Debug.LogError("Area Collider not assigned!");
        }
    }

    void Update()
    {
        // プレイヤーの位置を制限
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBounds.z, maxBounds.z);

        transform.position = clampedPosition;
    }
}
