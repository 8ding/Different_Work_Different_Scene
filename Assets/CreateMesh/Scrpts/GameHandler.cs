using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Material material;
    private Vector2[] headDownUV;
    private Vector2[] headUpUV;
    private Vector2[] headLeftUV;
    private Vector2[] headRightUV;
        
    private Vector2[] bodyDownUV;
    private Vector2[] bodyUpUV;
    private Vector2[] bodyLeftUV;
    private Vector2[] bodyRightUV;
        
    private Vector2[] swordUV;
    private Vector2[] shieldUV;
        
    private Vector2[] handUV;
    private Vector2[] footUV;
    void Start()
    {
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0,1);
        vertices[1] = new Vector3(1,1);        
        vertices[2] = new Vector3(0,0);
        vertices[3] = new Vector3(1,0);



        /*int headX = 0;
        int headY = 380;
        int headwidth = 128;
        int headheight = 128;
        int textureWidth = 512;
        int textureHeight = 512;
        uv[0] = ConvertPixelsToUVCoordinates(headX, headY + headheight, textureWidth, textureHeight);
        uv[1] = ConvertPixelsToUVCoordinates(headX + headwidth, headY + headheight, textureWidth, textureHeight);
        uv[2] = ConvertPixelsToUVCoordinates(headX, headY, textureWidth, textureHeight);
        uv[3] = ConvertPixelsToUVCoordinates(headX + headwidth, headY, textureWidth, textureHeight);*/

        headDownUV = GetUVRectangleFormPixels(0, 384, 128, 128, 512, 512);
        headUpUV = GetUVRectangleFormPixels(256, 384, 128, 128, 512, 512);
        headLeftUV = GetUVRectangleFormPixels(256, 384, -128, 128, 512, 512);
        headRightUV = GetUVRectangleFormPixels(128, 384, 128, 128, 512, 512);
            
        bodyDownUV = GetUVRectangleFormPixels(0, 256, 128, 128, 512, 512);
        bodyUpUV = GetUVRectangleFormPixels(256, 256, 128, 128, 512, 512);
        bodyLeftUV = GetUVRectangleFormPixels(256, 256, -128, 128, 512, 512);
        bodyRightUV = GetUVRectangleFormPixels(128, 256, 128, 128, 512, 512);
            
        swordUV = GetUVRectangleFormPixels(0, 128, 128, 128, 512, 512);
        shieldUV = GetUVRectangleFormPixels(128, 128, 128, 128, 512, 512);
            
        handUV = GetUVRectangleFormPixels(384, 448, 64, 64, 512, 512);
        footUV = GetUVRectangleFormPixels(448, 448, 64, 64, 512, 512);
        ApplyUV(headRightUV,ref uv);
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 2;
        triangles[4] = 1;
        triangles[5] = 3; 
        
        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        
        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(30, 30, 1);
        
        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        CodeMonkey.CMDebug.ButtonUI(new Vector2(-200, 100), "Head Down", () =>
        {
            ApplyUV(headDownUV, ref uv);
            mesh.uv = uv;
        });
        CodeMonkey.CMDebug.ButtonUI(new Vector2(-200, 30), "Body Down", () =>
        {
            ApplyUV(bodyDownUV, ref uv);
            mesh.uv = uv;
        });
        CodeMonkey.CMDebug.ButtonUI(new Vector2(-200, -40), "Sword", () =>
        {
            ApplyUV(swordUV, ref uv);
            mesh.uv = uv;
        });
    }

    private Vector2 ConvertPixelsToUVCoordinates(int x, int y, int textureWidth, int textureHeight)
    {
        return new Vector2((float) x / textureWidth, (float) y / textureHeight);
    }

    private Vector2[] GetUVRectangleFormPixels(int x, int y, int width, int height, int textureWidth, int textureHeight)
    {
        return new Vector2[]
        {
            ConvertPixelsToUVCoordinates(x, y + height, textureWidth, textureHeight),
            ConvertPixelsToUVCoordinates(x + width, y + height, textureWidth, textureHeight),
            ConvertPixelsToUVCoordinates(x, y, textureWidth, textureHeight),
            ConvertPixelsToUVCoordinates(x + width, y, textureWidth, textureHeight)
        };
    }

    private void ApplyUV(Vector2[] uv, ref Vector2[] mainUV)
    {
        mainUV[0] = uv[0];
        mainUV[1] = uv[1];
        mainUV[2] = uv[2];
        mainUV[3] = uv[3];
    }
        void Update()
    {
        
    }
}
