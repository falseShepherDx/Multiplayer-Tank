using Unity.Netcode;
using UnityEngine;

public class PlayerAim : NetworkBehaviour
{
    [SerializeField] InputReader inputReader;

    [SerializeField] private Transform turretTransform;

    private void LateUpdate()
    {
        if(!IsOwner) return;

        Vector2 aimPos=inputReader.AimPosition;
        Vector2 worldPos=Camera.main.ScreenToWorldPoint(aimPos);

        turretTransform.up = new Vector2
            (worldPos.x - turretTransform.position.x,
            worldPos.y-turretTransform.position.y
            );
    }
}
