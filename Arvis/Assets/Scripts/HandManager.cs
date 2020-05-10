﻿using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.UI;

public class HandManager
{
    private const float AngleConstant = 180 / Mathf.PI;

    // 가상 손의 손가락
    private GameObject[] _handObject;
    private RawImage _screen;
    private List<Vector3> _cvt3List;

    private float _pWidth;
    private float _pHeight;
    public List<Vector3> Cvt3List
    {
        get
        {
            return _cvt3List;
        }
    }

    public HandManager(GameObject[] handObject, RawImage screen, int width, int height)
    {
        _cvt3List = new List<Vector3>();
        _handObject = handObject;
        _screen = screen;
        _pWidth = (float)width;
        _pHeight = (float)height;
    }

    public void MoveHand()
    {
        // 가상 손을 움직임
        for(int i = 0; i < _handObject.Length; i++)
        {
            _handObject[i].transform.position = _cvt3List[i];
        }

        RotateFingers();
    }

    private void RotateFingers()
    {
        Vector3 center = _handObject[0].transform.position;
        float centerX = center.x;
        float centerY = center.y;

        for(int i = 1; i < _handObject.Length; i++)
        {
            Vector3 finger = _handObject[i].transform.position;
            float x = finger.x;
            float y = finger.y;

            float angle = Mathf.Atan2(y - centerY, x - centerX) * AngleConstant;
            Quaternion rotation = _handObject[i].transform.rotation;
            _handObject[i].transform.rotation = Quaternion.Euler(rotation.x, rotation.y, angle - 90);
        }
    }

    // 프레임 이미지의 손가락 끝 좌표들을 유니티 가상공간의 좌표로 변환
    private Vector3 Point2Vector3(Point point)
    {
        Debug.Log("Point = "+ point);

        Vector3 cvt3 = new Vector3(_screen.transform.position.x, _screen.transform.position.y, _screen.transform.position.z);

        if(WebCam.isAndroid)
        {
            cvt3.x += (point.X / _pWidth - 0.5f) * _screen.rectTransform.sizeDelta.x * _screen.transform.lossyScale.x;
        }
        else
        {
            cvt3.x += (0.5f - point.X / _pWidth) * _screen.rectTransform.sizeDelta.x * _screen.transform.lossyScale.x;
        }
        
        cvt3.y += (0.5f - point.Y / _pHeight) * _screen.rectTransform.sizeDelta.y * _screen.transform.lossyScale.y;

        return cvt3;
    }

    public void InputPoint(List<Point> pointList, Point center)
    {
        _cvt3List.Add(Point2Vector3(center));
        for(int i = 0; i < pointList.Count; i++)
        {
            _cvt3List.Add(Point2Vector3(pointList[i]));
        }
    }
}
