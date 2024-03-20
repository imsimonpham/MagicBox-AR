using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] private Transform _examineTarget;

    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Examinable _currentExaminedObj;
    private Transform _cachedParent;
    private Vector3 _cachedScale;

    private bool _isExamining = false;
    private float _rotSpeed = 0.5f;


    private void Update()
    {
        if (_isExamining)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Moved)
                {
                    _currentExaminedObj.transform.Rotate(touch.deltaPosition.x * _rotSpeed, touch.deltaPosition.y * _rotSpeed, 0, Space.Self);
                }  
            }
        }
    }

    public void PerformExamine(Examinable examinable)
    {
        _isExamining = true;
        _currentExaminedObj = examinable;

        //cache the examinable transform data so we can revert it later
        _cachedPos = _currentExaminedObj.transform.localPosition;
        _cachedRot = _currentExaminedObj.transform.localRotation; 
        _cachedParent = _currentExaminedObj.transform.parent;
        _cachedScale = _currentExaminedObj.transform.localScale;

        //move the examinable to the target position and assign a parent to it
        _currentExaminedObj.transform.position = _examineTarget.position;
        _currentExaminedObj.transform.parent = _examineTarget;

        //Offset the scale to fit the examinable view
        _currentExaminedObj.transform.localScale = _cachedScale * examinable.examineScaleOffset;
    }

    public void PerformUnexamine()
    {
        _isExamining = false;

        _currentExaminedObj.transform.parent = _cachedParent;
        _currentExaminedObj.transform.localPosition = _cachedPos;
        _currentExaminedObj.transform.localRotation = _cachedRot;
        _currentExaminedObj.transform.localScale = _cachedScale;
    }
}
