using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GateType { fatterType, thinnerType, tallerType, shorterType}
public class GateController : MonoBehaviour
{
    public int gateValue;
    public RawImage gateImage;
    public TMPro.TextMeshProUGUI gateText;
    public Texture[] textures;
    public GateType gateType;
    public GameObject playerGO;
    public PlayerController playerController;
    bool hasGateUsed;
    private GateHolderController gateHolderController;

    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerController = playerGO.GetComponent<PlayerController>();
        AddGateValueAndSymbol();
        gateHolderController = transform.parent.gameObject.GetComponent<GateHolderController>();
        
    }

    void Update()
    {
        
    }

    public void AddGateValueAndSymbol()
    {
        int gateValueMultiple = Random.Range(1, 11);
        gateValue = gateValueMultiple * 10;
        gateText.text = gateValue.ToString();
        
        switch (gateType)
        {
            case GateType.fatterType:
                gateImage.texture = textures[0];
                break;
            case GateType.thinnerType:
                gateImage.texture = textures[1];
                break;
            case GateType.tallerType:
                gateImage.texture = textures[2];
                break;
            case GateType.shorterType:
                gateImage.texture = textures[3];
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && hasGateUsed == false)
        {
            hasGateUsed = true;
            playerController.PassedGate(gateType, gateValue);
            if(gateHolderController != null)
            {
                gateHolderController.CloseGates();
            }
            Destroy(gameObject);
        }
    }
}
