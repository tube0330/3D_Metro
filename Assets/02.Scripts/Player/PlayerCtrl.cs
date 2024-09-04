using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Movement _movement;
    Transform tr;
    [SerializeField] SkinnedMeshRenderer[] meshrend;

    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");

    void Start()
    {
        tr = transform;
        _movement = GetComponent<Movement>();
        meshrend = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (var renderer in meshrend)
            renderer.enabled = false;
    }

    private void Update()
    {
        // 로컬 좌표계로 이동 벡터 계산
        Vector3 worldMove = new Vector3(h, 0, v);
        Vector3 localMove = tr.TransformDirection(worldMove);

        _movement.Move(localMove);

        if (Input.GetButtonDown("Jump"))
        {
            _movement.Jump();
        }
    }
}
