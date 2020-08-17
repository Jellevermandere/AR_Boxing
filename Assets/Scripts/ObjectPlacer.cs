using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ObjectPlacer : MonoBehaviour
{
    [Header("Prefabs")]
    [Tooltip("Instantiates this prefab on a plane at the touch location.")]
    [SerializeField]
    private GameObject placeObject;

    [Header("Variables")]
    

    [HideInInspector]
    public GameObject punchingBag;

    private ARRaycastManager raycastManager;
    static List<ARRaycastHit> arHits = new List<ARRaycastHit>();

    // grab the components
    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check witch gamemode the game is in:  0 == search state, 1 == play state
        if (GameManager.GameMode == 0)
        {
            if (!TryGetTouchPosition(out Vector2 touchPosition))
                return;

            if (raycastManager.Raycast(touchPosition, arHits, TrackableType.PlaneWithinPolygon))
            {
                // Raycast hits are sorted by distance, so the first one
                // will be the closest hit.
                Pose hitPose = arHits[0].pose;

                if (punchingBag == null)
                {
                    punchingBag = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                }
                else
                {
                    punchingBag.transform.position = hitPose.position;
                }
            }
        }
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
            if (Input.touchCount > 0)
            {
                touchPosition = Input.GetTouch(0).position;
                return true;
            }
#endif

        touchPosition = default;
        return false;
    }

    public void NextFace()
    {
        if (punchingBag.GetComponent<PunchingBagNull>())
        {
            punchingBag.GetComponent<PunchingBagNull>().SetFace();
        }
        if (punchingBag.GetComponentInChildren<MattController>())
        {
            punchingBag.GetComponentInChildren<MattController>().NextFace();
        }
        
    }

    public void SetPlayMode()
    {
        GameManager.GameMode = 1;
    }

    public void SetPlaceMode()
    {
        GameManager.GameMode = 0;
    }
}
