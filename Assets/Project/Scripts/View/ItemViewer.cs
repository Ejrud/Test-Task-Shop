﻿using System.Collections.Generic;
using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private ShopItemFrame _itemFramePrefab;
    private ItemFrame[] _frames = new ItemFrame[0];

    public void Initialize(List<Item> items)
    {
        UpdateItemList(items.Count);
        SetProperties(items);
    }

    private void SetProperties(List<Item> items)
    {
        int count = 0;
        foreach (Item item in items)
        {
            _frames[count].Init(item);
            count++;
        }
    }

    private void UpdateItemList(int count)
    {
        if (_frames.Length > count)
        {
            int surplus = _frames.Length - count;
            HideSurplus(surplus);
        }
        else if (_frames.Length < count)
        {
            int surplus = count - _frames.Length;
            AddSurplus(surplus);
        }
    }

    private void AddSurplus(int lenght)
    {
        ItemFrame[] temp = _frames;
        int remaind = temp.Length;
        _frames = new ItemFrame[lenght];

        for (int i = 0; i < _frames.Length; i++)
        {
            if (remaind > 0)
            {
                _frames[i] = temp[i];
                continue;
            }

            _frames[i] = CreateItemFrame();
        }
    }

    private void HideSurplus(int startIndex)
    {
        for (int i = startIndex; i < _frames.Length; i++)
            _frames[i].SetActive(false);
    }

    private ItemFrame CreateItemFrame()
    {
        ItemFrame frame = Instantiate(_itemFramePrefab);
        frame.transform.SetParent(_parent);
        frame.transform.localScale = Vector3.one;
        return frame;
    }
}