﻿using UnityEngine;
using System.Collections.Generic;
using System.Security;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;

namespace Lui {
    public class LGridViewCell : LTableViewCell {
        public int row;
    }

    /// <summary>
    /// 网格
    /// </summary>
    [SLua.CustomLuaClass]
    public class LGridView : LScrollView {
        public Vector2 cellsSize;
        public int cellsCount;
        public int cols;
        public bool autoRelocate;
        public bool isAsyncOnce;
        public GameObject cell_tpl;

        protected int _rows;
        protected List<LGridViewCell> _cellsUsed;
        protected List<LGridViewCell> _cellsFreed;
        protected List<Vector2> _positions;
        protected Dictionary<int, int> _indices;
        protected UnityAction<int, GameObject> onCellHandle;
        public void SetCellHandle(UnityAction<int, GameObject> act) {
            onCellHandle = act;

        }

        public LGridView() {
            cellsCount = 0;
            cellsSize = Vector2.zero;
            cols = 0;
            _rows = 0;
            direction = ScrollDirection.VERTICAL;
            _cellsUsed = new List<LGridViewCell>();
            _cellsFreed = new List<LGridViewCell>();
            _positions = new List<Vector2>();
            _indices = new Dictionary<int, int>();
        }

        public void removeAllFromUsed() {
            int len = _cellsUsed.Count;
            for (int i = 0; i < len; i++) {
                Destroy(_cellsUsed[i].node);
            }
            _cellsUsed.Clear();
        }

        public void removeAllFromFreed() {
            int len = _cellsFreed.Count;
            for (int i = 0; i < len; i++) {
                Destroy(_cellsFreed[i].node);
            }
            _cellsFreed.Clear();
        }

        public void insertSortableCell(LGridViewCell cell, int idx) {
            if (_cellsUsed.Count == 0) {
                _cellsUsed.Add(cell);
            }
            else {
                for (int i = 0; i < _cellsUsed.Count; i++) {
                    if (_cellsUsed[i].idx > idx) {
                        _cellsUsed.Insert(i, cell);
                        return;
                    }
                }
                _cellsUsed.Add(cell);
                return;
            }
        }

        protected Vector2 cellPositionFromIndex(int idx) {
            if (idx == LScrollView.INVALID_INDEX) {
                return _positions[0];
            }
            return _positions[idx];
        }

        public void updateCellAtIndex(int idx, int row) {
            if (cellsCount == 0) {
                return;
            }

            LGridViewCell cell = _onDataSourceAdapterHandler(dequeueCell(), idx);
            cell.idx = idx;
            cell.row = row;
            RectTransform rtran = cell.node.GetComponent<RectTransform>();
            rtran.pivot = new Vector2(0, 1);
            rtran.sizeDelta = cellsSize;
            cell.node.SetActive(true);
            cell.node.transform.SetParent(container.transform);
            cell.node.transform.localPosition = cellPositionFromIndex(idx);
            cell.node.transform.localScale = new Vector3(1, 1, 1);
            insertSortableCell(cell, idx);

            //新抽象出来的Item接口
            IListItem item = rtran.GetComponent<IListItem>();
            if (item != null) {
                Debug.LogError("我是Index" + idx);
                item.Init(idx);
                item.OnRefresh();
            }

            _indices.Add(idx, 1);
        }

        protected int cellBeginRowFromOffset(Vector2 offset) {
            float ofy = offset.y + container.GetComponent<RectTransform>().rect.height;
            float xos = ofy - GetComponent<RectTransform>().rect.height;
            int row = (int)(xos / cellsSize.y);

            row = Mathf.Max(row, 0);
            row = Mathf.Min((int)_rows - 1, row);

            return (int)row;
        }

        protected int cellEndRowFromOffset(Vector2 offset) {
            float ofy = offset.y + container.GetComponent<RectTransform>().rect.height;
            int row = (int)(ofy / cellsSize.y);

            row = Mathf.Max(row, 0);
            row = Mathf.Min((int)_rows - 1, row);

            return (int)row;
        }

        protected int cellFirstIndexFromRow(int row) {
            return cols * row;
        }

        protected void updatePositions() {
            if (cellsCount == 0) {
                return;
            }
            RectTransform rtran = GetComponent<RectTransform>();

            _rows = cellsCount % cols == 0 ? cellsCount / cols : cellsCount / cols + 1;
            float height = Mathf.Max(_rows * cellsSize.y, rtran.rect.height);
            float width = cols * cellsSize.x;
            setContainerSize(new Vector2(width, height));

            float nx = 0.0f;
            float ny = height;

            for (int idx = 0; idx < cellsCount; ++idx) {
                if (idx != 0 && idx % cols == 0) {
                    nx = 0.0f;
                    ny = ny - cellsSize.y;
                }
                _positions.Add(new Vector2(nx, ny));
                nx += cellsSize.x;
            }
        }

        public List<LGridViewCell> getCells() {
            List<LGridViewCell> ret = new List<LGridViewCell>();
            for (int i = 0; i < _cellsUsed.Count; i++) {
                ret.Add(_cellsUsed[i]);
            }
            return ret;
        }

        public LGridViewCell cellAtIndex(int idx) {
            if (!_indices.ContainsKey(idx)) {
                return null;
            }
            for (int i = 0; i < _cellsUsed.Count; i++) {
                if (_cellsUsed[i].idx == idx) {
                    return _cellsUsed[i];
                }
            }
            return null;
        }

        protected LGridViewCell dequeueCell() {
            LGridViewCell cell = null;
            if (_cellsFreed.Count == 0) {
                return null;
            }
            else {
                cell = _cellsFreed[0];
                _cellsFreed.RemoveAt(0);
            }
            return cell;
        }

        public void reloadData() {
            if (_cellsUsed.Count > 0) {
                for (int i = 0; i < _cellsUsed.Count; i++) {
                    LGridViewCell cell = _cellsUsed[i];
                    _cellsFreed.Add(cell);
                    cell.reset();
                    cell.node.SetActive(false);
                }
                _cellsUsed.Clear();
            }

            Transform tran = transform.Find("container/cell_tpl");
            if (tran != null) {
                tran.gameObject.SetActive(false);
            }
            try {
                _indices.Clear();
                _positions.Clear();
                updatePositions();
                setContentOffsetToTop();
                onScrolling();
            }
            catch (Exception e) {
                Debug.Log(e);
            }

            relocateContainer();
        }

        protected override void onScrolling() {
            base.onScrolling();

            int beginRow = 0, endRow = 0;
            beginRow = cellBeginRowFromOffset(getContentOffset());
            endRow = cellEndRowFromOffset(getContentOffset());

            while (_cellsUsed.Count > 0) {
                LGridViewCell cell = _cellsUsed[0];
                int row = cell.row;
                int idx = cell.idx;

                if (row < beginRow) {
                    _indices.Remove(idx);
                    _cellsUsed.Remove(cell);
                    _cellsFreed.Add(cell);
                    cell.reset();
                    //cell.node.transform.SetParent(null);
                    cell.node.SetActive(false);
                }
                else {
                    break;
                }
            }

            while (_cellsUsed.Count > 0) {
                LGridViewCell cell = _cellsUsed[_cellsUsed.Count - 1];
                int row = cell.row;
                int idx = cell.idx;

                if (row > endRow && row < _rows) {
                    _indices.Remove(idx);
                    _cellsUsed.Remove(cell);
                    _cellsFreed.Add(cell);
                    cell.reset();
                    //cell.node.transform.SetParent(null);
                    cell.node.SetActive(false);
                }
                else {
                    break;
                }
            }

            if (isAsyncOnce) {
                StopAllCoroutines();
                StartCoroutine(_onScrollingAsync(beginRow, endRow));
            }
            else {

                for (int row = beginRow; row <= endRow && row < _rows; ++row) {
                    int cellBeginIndex = cellFirstIndexFromRow(row);
                    int cellEndIndex = cellBeginIndex + cols;

                    for (int idx = cellBeginIndex; idx < cellEndIndex && idx < cellsCount; ++idx) {
                        if (_indices.ContainsKey(idx)) {
                            continue;
                        }
                        updateCellAtIndex(idx, row);
                    }
                }
            }
        }

        IEnumerator _onScrollingAsync(int beginRow, int endRow) {

            for (int row = beginRow; row <= endRow && row < _rows; ++row) {
                int cellBeginIndex = cellFirstIndexFromRow(row);
                int cellEndIndex = cellBeginIndex + cols;

                for (int idx = cellBeginIndex; idx < cellEndIndex && idx < cellsCount; ++idx) {
                    if (_indices.ContainsKey(idx)) {
                        continue;
                    }
                    updateCellAtIndex(idx, row);
                    yield return new WaitForEndOfFrame();
                }
            }
            isAsyncOnce = false;
        }

        protected override void onDraggingScrollEnded() {
            if (cellsCount == 0) {
                return;
            }

            if (autoRelocate) {
                Vector2 offset = getContentOffset();
                int row = cellBeginRowFromOffset(offset);
                Vector2 pointA = cellPositionFromIndex(cellFirstIndexFromRow(row));
                Vector2 pointB = new Vector2(0, pointA.y - cellsSize.y);
                Vector2 contentPoint = new Vector2(0, GetComponent<RectTransform>().rect.height);
                offset = offset - contentPoint;
                pointA.x = 0;

                float distanceA = Vector2.Distance(offset, -pointA);
                float distanceB = Vector2.Distance(offset, -pointB);

                if (distanceA < distanceB) {
                    float duration = Mathf.Abs(distanceA) / LTableView.AUTO_RELOCATE_SPPED;
                    setContentOffsetInDuration(-pointA + contentPoint, duration);
                }
                else {
                    float duration = Mathf.Abs(distanceB) / LTableView.AUTO_RELOCATE_SPPED;
                    setContentOffsetInDuration(-pointB + contentPoint, duration);
                }
            }

            base.onDraggingScrollEnded();
        }

        protected LGridViewCell _onDataSourceAdapterHandler(LGridViewCell cell, int idx) {
            if (cell == null) {
                cell = new LGridViewCell();
                if (cell_tpl != null)
                    cell.node = (GameObject)Instantiate(cell_tpl);
                else {
                    Transform tpl = transform.Find("container/cell_tpl");
                    if (tpl) {
                        cell.node = (GameObject)Instantiate(tpl.gameObject);
                    }
                    else {
                        Debug.LogWarning("模板为空");
                    }
                }
            }
            if (onCellHandle != null) {
                onCellHandle.Invoke(idx, cell.node);
            }
            return cell;
        }

    }
}