using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class DrawingManager : MonoBehaviour
{
    public Vector2Int textureSize = new Vector2Int(50, 50);
    public string pathToTempTexturesFolder;
    private Vector2 conversionWorldToTextureVector;

    public CursorDatas cursorData;

    public GameObject UI_canvas;
    HistoryManager historyManager;
    LayersManager layersManager;
    ToolsManager toolsManager;
    ColorsManager colorsManager;
    ModeManager modeManager;

    // Start is called before the first frame update
    void Start()
    {
        pathToTempTexturesFolder = System.IO.Path.Combine(Application.dataPath + "/Drawing/DrawingMesh/TexturesTemp/");
        conversionWorldToTextureVector = new Vector2(10, 10) / new Vector2(textureSize.x, textureSize.y);
        cursorData = new CursorDatas();

        historyManager = UI_canvas.GetComponentInChildren<HistoryManager>();
        layersManager = UI_canvas.GetComponentInChildren<LayersManager>();
        toolsManager = UI_canvas.GetComponentInChildren<ToolsManager>();
        colorsManager = UI_canvas.GetComponentInChildren<ColorsManager>();
        modeManager = UI_canvas.GetComponentInChildren<ModeManager>();
        layersManager.initLayers(textureSize, pathToTempTexturesFolder);

        GetComponentInChildren<MeshRenderer>().material.SetTexture("_DrawingTexture", layersManager.getCurrentLayerTexture());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponentInChildren<IsOvered>().isOvered) //Click
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                cursorData.currentPixelPosition = worldPositionToTexturePosition(hit.point);
                cursorData.needForANewClick = false;
                historyManager.newActionIfNecessary(toolsManager.currentTool, modeManager.currentMode);
            }

        }
        else if (Input.GetMouseButton(0) && cursorData.needForANewClick == false)
        {
            if (GetComponentInChildren<IsOvered>().isOvered)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    cursorData.update(worldPositionToTexturePosition(hit.point));
                    // toolsManager.useTool(layersManager.getCurrentLayerTexture(), cursorData, historyManager.getCurrentAction(), colorsManager.currentColor);
                    // layersManager.getCurrentLayerTexture().SetPixel(cursorData.currentPixelPosition.x, cursorData.currentPixelPosition.y, Color.black);
                    // layersManager.getCurrentLayerTexture().Apply();
                }

            }
            else if (!GetComponentInChildren<IsOvered>().isOvered)
            {
                cursorData.needForANewClick = true;
            }
        }
    }

    public Vector2Int worldPositionToTexturePosition(Vector3 position)
    {
        Vector2 positionOnTexture = new Vector2(position.x, position.y) / conversionWorldToTextureVector;
        Vector2Int positionOnTextureAsInt = new Vector2Int((int)positionOnTexture.x, (int)positionOnTexture.y);

        return positionOnTextureAsInt;
    }
}