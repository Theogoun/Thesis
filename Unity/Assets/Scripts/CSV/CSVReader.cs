using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BikeTripData
{
    public float Time { get; set; }
    public float Speed { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}

public class CSVReader : MonoBehaviour
{
    public List<BikeTripData> bikeTripDataList = new();

    void Awake()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "bike_trip.csv");
        
        try
        {
            using (StreamReader sr = new(filePath))
            {
                // Skip the header line
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    BikeTripData data = new()
                    {
                        Time = float.Parse(values[0]),
                        Speed = float.Parse(values[1]),
                        X = float.Parse(values[2]),
                        Z = float.Parse(values[3]),
                        Y = float.Parse(values[4])
                    };

                    bikeTripDataList.Add(data);
                }
            }

            Debug.Log("CSV file read successfully.");
        }
        catch (Exception e)
        {
            Debug.LogError("Error reading CSV file: " + e.Message);
        }
    }

    void PrintData()
    {
        foreach (var data in bikeTripDataList)
        {
            Debug.Log($"Time: {data.Time}, Speed: {data.Speed}, X: {data.X}, Z: {data.Z}");
        }
    }
}