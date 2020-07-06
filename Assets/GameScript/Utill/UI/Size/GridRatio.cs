using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridRatio : MonoBehaviour
{

    private float originWidth, originHeight;
    private RectTransform parent;
    private GridLayoutGroup grid;

    

    GridLayout gridLayout;
    // Start is called before the first frame update
    void Awake()
    {

        parent = gameObject.GetComponent<RectTransform>();
        grid = gameObject.GetComponent<GridLayoutGroup>();

        originWidth = parent.rect.width;
        originHeight = parent.rect.height;
    }

    public void SetDynamicGrid(int cnt, int minColsInARow, int maxRow)
    {

        int rows = Mathf.Clamp(Mathf.CeilToInt((float)cnt / minColsInARow), 1, maxRow + 1);
        int cols = Mathf.CeilToInt((float)cnt / rows);

        float spaceW = (grid.padding.left + grid.padding.right) + (grid.spacing.x * (cols - 1));
        float spaceH = (grid.padding.top + grid.padding.bottom) + (grid.spacing.y * (rows - 1));

        float maxWidth = originWidth - spaceW;
        float maxHeight = originHeight - spaceH;

        float width = Mathf.Min(parent.rect.width - (grid.padding.left + grid.padding.right) - (grid.spacing.x * (cols - 1)), maxWidth);
        float height = Mathf.Min(parent.rect.height - (grid.padding.top + grid.padding.bottom) - (grid.spacing.y * (rows - 1)), maxHeight);

        grid.cellSize = new Vector2(width / cols, height / rows);
    }


}
