using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Transform player; // �÷��̾� Transform
    public RectTransform mapRect; // ���� UI Rect Transform
    public RectTransform playerIcon; // �÷��̾� ������ UI Rect Transform

    // ���� ���� ũ�� (���� ���, ���� 100, ���� 100)
    public Vector2 mapSize = new Vector2(100, 100);

    void Update()
    {
        // �÷��̾��� ��ġ�� ���� ���� ��ǥ�� ��ȯ
        Vector2 mapPosition = new Vector2(
            Mathf.Clamp(player.position.x, -mapSize.x, mapSize.x), // x ��ǥ ����
            Mathf.Clamp(player.position.y, -mapSize.y, mapSize.y) // y ��ǥ ����
        );

        // ���� ���� ��ǥ�� UI ������ ��ǥ�� ��ȯ
        Vector2 normalizedPosition = new Vector2(
            mapPosition.x / mapSize.x,
            mapPosition.y / mapSize.y
        );

        // UI ������ ũ�⿡ �°� ��ȯ
        Vector2 mapRectSize = mapRect.rect.size;
        Vector2 mapPositionPixels = new Vector2(
            normalizedPosition.x * mapRectSize.x,
            normalizedPosition.y * mapRectSize.y
        );

        // UI ���� ������ �÷��̾� �������� ��ġ ����
        playerIcon.anchoredPosition = mapPositionPixels;
    }


}