using UnityEngine;
using DG.Tweening;

public class VerticalSlidingDoorView : DoorViewBase
{
    [SerializeField][Min(0.0001f)] private float _openTime;
    [SerializeField][Min(0.0001f)] private float _moveDelta;

    private bool _animationEnded;

    private Vector3 _openedPosition;
    private Vector3 _closedPosition;

    private void Start()
    {
        _openedPosition = new Vector3(CachedTransform.position.x, CachedTransform.position.y - _moveDelta, CachedTransform.position.z);
        _closedPosition = new Vector3(CachedTransform.position.x, CachedTransform.position.y, CachedTransform.position.z);

        _animationEnded = true;
    }

    protected override void Close()
    {
        if (CachedTransform.position != _closedPosition && _animationEnded == true)
        {
            _animationEnded = false;

            CachedTransform.DOMoveY(CachedTransform.position.y + _moveDelta, _openTime).OnComplete(() =>
            {
                CachedTransform.position = _closedPosition;
                _animationEnded = true;
            });
        }
    }

    protected override void Open()
    {
        if (CachedTransform.position != _openedPosition && _animationEnded == true)
        {
            _animationEnded = false;

            CachedTransform.DOMoveY(CachedTransform.position.y - _moveDelta, _openTime).OnComplete(() =>
            {
                CachedTransform.position = _openedPosition;
                _animationEnded = true;
            });
        }
    }
}