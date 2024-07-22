using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRAGGING : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public Material[] MyMaterial;
    float rotSpeed = 20;
    public int rotate = 0;
    public string Name;
    public int Type;
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        if (applycolor.Instance)
        {
            foreach (Material item in MyMaterial)
            {
                if (item) { 
                    applycolor.Instance.NewAssignedMat(item);
                }
            }
        }
    }
    public float _maxX, _maxY, _maxZ, _minX, _minY, _minZ;
    private void Update()
    {
        Vector3 newPos = transform.position;
        Quaternion NewRatation = transform.rotation;
        NewRatation.z = Mathf.Clamp(transform.rotation.z, 0, 0);
        transform.rotation = NewRatation;
        newPos.x = Mathf.Clamp(transform.position.x, _minX, _maxX);
        newPos.y = Mathf.Clamp(transform.position.y, _minY, _maxY);
        newPos.z = Mathf.Clamp(transform.position.z, _minZ, _maxZ);
        transform.position = newPos;
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mZCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    public void OnRotate()
    {
        if (rotate == 0)
        {
            rotate = 1;
        }
        else
        {
            rotate = 0;
        }
    }

    void OnMouseDrag()
    {
        if (rotate == 0)
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = GetMouseWorldPos() + mOffset;
            }
        }

        if (rotate == 1)
        {
            float rotX = Input.GetAxis("Mouse X") * rotSpeed * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * rotSpeed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotX);
            transform.RotateAround(Vector3.right, rotY);

        }
    }
    private void OnMouseUp()
    {
        if (applycolor.Instance)
        {
            //  applycolor.Instance.DeniedToApply();
        }
    }

}
