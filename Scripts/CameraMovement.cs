using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform Player;
    Vector3 offset;

    private void Start() {
        offset = transform.position - Player.position;
    }

    private void Update() { 
        Vector3 targetPos = Player.position + offset;
        targetPos.x = 0; 
        transform.position = targetPos;
    }

}
