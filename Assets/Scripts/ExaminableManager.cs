using UnityEngine;

public class ExaminableManager : MonoBehaviour
{
    [SerializeField] private Transform _examineTarget;

    private Vector3 _cachedPos;
    private Quaternion _cachedRot;
    private Examinable _currentExaminedObj;

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
        _currentExaminedObj = examinable;

        if(_currentExaminedObj != null)
        {
            //cache the examinable transform data so we can reset it
            _cachedPos = _currentExaminedObj.transform.position;
            _cachedRot = _currentExaminedObj.transform.rotation;
            _cachedScale = _currentExaminedObj.transform.localScale;

            //move the examinable to the target position and assign a parent to it
            _currentExaminedObj.transform.position = _examineTarget.position;
            _currentExaminedObj.transform.parent = _examineTarget;

            //Offset the scale to fit the examinable in view
            Vector3 offsetScale = _cachedScale *  examinable.examineScaleOffset;
            _currentExaminedObj.transform.localScale = offsetScale;

            _isExamining = true;
        } 
    }

    public void PerformUnexamine()
    {
        _currentExaminedObj.transform.position = _cachedPos;
        _currentExaminedObj.transform.rotation = _cachedRot;
        _currentExaminedObj.transform.localScale = _cachedScale;

        _currentExaminedObj.transform.parent = null;
        _currentExaminedObj = null;
        _isExamining = false;
    }
}
