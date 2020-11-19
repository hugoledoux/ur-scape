﻿// Copyright (C) 2019 Singapore ETH Centre, Future Cities Laboratory
// All rights reserved.
//
// This software may be modified and distributed under the terms
// of the MIT license. See the LICENSE file for details.
//
// Author:  Michael Joos  (joos@arch.ethz.ch)

using UnityEngine;

public class ToolLayerController : MapLayerControllerT<GridMapLayer>
{
    public T CreateMapLayer<T>(T prefab, string layerName, GridData gridData = null) where T : GridMapLayer
    {
        T mapLayer = Instantiate(prefab);
        var grid = gridData == null ? new GridData() : new GridData(gridData);
        Add(mapLayer, grid, layerName, Color.white);

        return mapLayer;
    }

    public void Add(GridMapLayer layer, GridData grid, string name, Color color)
    {
        layer.Init(map, grid);
        layer.name = name;
        layer.SetColor(color);
        layer.transform.SetParent(transform, false);
        mapLayers.Add(layer);
    }

    public void Remove(GridMapLayer layer)
    {
        mapLayers.Remove(layer);
    }
}
