using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] int MaxPage;
    [SerializeField] Vector3 PageStep;
    [SerializeField] RectTransform LevelPagesRect;
    [SerializeField] float TweenTime;
    [SerializeField] LeanTweenType  TweenType;
    private  int _currentPage;
    Vector3 targetPos;

    private void Awake()
    {
        _currentPage = 1;
        targetPos = LevelPagesRect.localPosition;
    }
    private void Next()
    {
        if(_currentPage < MaxPage)
        {
            _currentPage++;
            targetPos += PageStep;
            MovePage();
        }
    }
    private void Previous()
    {
        if(_currentPage > 1)
        {
            _currentPage--;
            targetPos -= PageStep;
            MovePage();
        }
    }
    private void MovePage()
    {
        LevelPagesRect.LeanMoveLocal(targetPos, TweenTime).setEase(TweenType);
    }
  
}
