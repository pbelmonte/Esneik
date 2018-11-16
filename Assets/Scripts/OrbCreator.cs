using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbCreator : MonoBehaviour {

    private float[][][] positions = new float[28][][];

    public Transform orb;
    private Transform orbCopy;
    private GameObject Orb;

	void Start () {
        float[][] array;
        float[] val;
        for(int i = 0; i < 28; i++)
        {
            array = new float[28][];
            for(int j = 0; j < 28; j++)
            {
                val = new float[2];
                val[0] = -13.5f + i;
                val[1] = -13.5f + j;
                array[j] = val;
            }
            positions[i] = array;
        }
    }

    void FixedUpdate ()
    {
        if (Orb == null)
        {
            CreateOrb();
        }
    }

    void CreateOrb ()
    {
        int val = (int)Random.Range(0, 783);
        float[] pos = positions[val / 28][val % 28];
        float z = pos[0];
        float x = pos[1];
        orbCopy = Instantiate(orb, new Vector3(x, 0.5f, z), Quaternion.identity);
        Orb = orbCopy.gameObject;
    }
}
