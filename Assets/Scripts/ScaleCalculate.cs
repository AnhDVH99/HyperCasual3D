using UnityEngine;

public class ScaleCalculate
{
    private float maxScale = 4f;
    private float minScale = 1.12f;
    private float obstacleDamage = 0.5f;
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public Vector3 CalculatePlayerHeadSize(GateType gateType, int gateValue, Transform headTransform)
    {
        float changeSize = gateValue / 100f;
        float newXScale;
        float newYScale;
        float newZScale;

        switch (gateType)
        {
            case GateType.fatterType:
                newXScale = headTransform.localScale.x + changeSize;
                newYScale = headTransform.localScale.y + changeSize;
                newZScale = headTransform.localScale.z;

                if (newXScale > maxScale)
                {
                    newXScale = maxScale;
                }
                if (newYScale > maxScale)
                {
                    newYScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.thinnerType:
                newXScale = headTransform.localScale.x - changeSize;
                newYScale = headTransform.localScale.y - changeSize;
                newZScale = headTransform.localScale.z - changeSize;

                if (newXScale < minScale)
                {
                    newXScale = minScale;
                }
                if (newYScale < minScale)
                {
                    newYScale = minScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.tallerType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z + changeSize;

                if (newZScale > maxScale)
                {
                    newZScale = maxScale;
                }

                return new Vector3(newXScale, newYScale, newZScale);

            case GateType.shorterType:
                newXScale = headTransform.localScale.x;
                newYScale = headTransform.localScale.y;
                newZScale = headTransform.localScale.z - changeSize;

                if (newZScale < minScale)
                {
                    newZScale = minScale;
                }
                return new Vector3(newXScale, newYScale, newZScale);

            default:
                return new Vector3(minScale, minScale, minScale);
        }
    }

    public Vector3 DecreasePlayerHeadSize(Transform playerTransform)
    {
        float newXScale = playerTransform.localScale.x - obstacleDamage;
        float newYScale = playerTransform.localScale.y - obstacleDamage;
        float newZScale = playerTransform.localScale.z - obstacleDamage;

        if(newXScale < minScale)
        {
            newXScale = minScale;
        }
        if(newYScale < minScale)
        {
            newYScale = minScale;
        }
        if(newZScale < minScale)
        {
            newZScale = minScale;
        }

        return new Vector3(newXScale, newYScale, newZScale);    
    }
}