using UnityEngine;
using System.Collections;

public class AnimationHelper : MonoBehaviour
{

    #region Fields and Properties

    [SerializeField]
    private bool rotateX;

    [SerializeField]
    private bool rotateY;

    [SerializeField]
    private bool rotateZ;

    [SerializeField]
    private float rotateSpeed = 50f;

    [SerializeField]
    private float offsetX;

    [SerializeField]
    private float offsetY;

    [SerializeField]
    private float offsetZ;

    [SerializeField]
    private float translateSpeed = 0.1f;

    private Vector3 initialPosition;

    #endregion Fields and Properties

    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
        startPostion = endPosition = transform.position;
    }

    private Vector3 endPosition;
    private Vector3 startPostion;
    private bool direction = true;

    void LateUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(rotateX ? Time.deltaTime * rotateSpeed : 0f, rotateY ? Time.deltaTime * rotateSpeed : 0f, rotateZ ? Time.deltaTime * rotateSpeed : 0f));

        Vector3 maxPosition = initialPosition + new Vector3(offsetX, offsetY, offsetZ);
        Vector3 minPosition = initialPosition - new Vector3(offsetX, offsetY, offsetZ);
        bool reachedMax = (offsetX > 0f && transform.position.x - maxPosition.x >= -0.01f) || (offsetY > 0f && transform.position.y - maxPosition.y >= -0.01f) || (offsetZ > 0f && transform.position.z - maxPosition.z >= -0.01f);
        bool reachedMin = (offsetX > 0f && transform.position.x - minPosition.x <= 0.01f) || (offsetY > 0f && transform.position.y - minPosition.y <= 0.01f) || (offsetZ > 0f && transform.position.z - minPosition.z <= 0.01f);

        if (!direction && reachedMax)
        {
            direction = true;
        }
        else if (reachedMin)
        {
            direction = false;
        }
        

        if (offsetX > 0f)
        {
            if (reachedMax || direction)
            {
                endPosition.Set(minPosition.x, initialPosition.y, initialPosition.z);
            }
            else if (!direction)
            {
                endPosition.Set(maxPosition.x, initialPosition.y, initialPosition.z);
            }

        }

        if (offsetY > 0)
        {
            if (reachedMax || direction)
            {
                endPosition.Set(endPosition.x, minPosition.y, initialPosition.z);
            }
            else if (!direction)
            {
                endPosition.Set(endPosition.x, maxPosition.y, initialPosition.z);
            }
        }

        if (offsetZ > 0)
        {
            if (reachedMax || direction)
            {
                endPosition.Set(endPosition.x, endPosition.y, minPosition.z);
            }
            else if (!direction)
            {
                endPosition.Set(endPosition.x, endPosition.y, maxPosition.z);
            }
        }

        if (endPosition != initialPosition)
        {

            transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * translateSpeed); //Vector3.Lerp(transform.position, endPosition, Time.deltaTime * translateSpeed);
        }


    }
}
