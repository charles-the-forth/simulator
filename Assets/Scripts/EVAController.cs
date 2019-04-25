using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EVAController : MonoBehaviour
{

    public GameObject messageIdText;
    public GameObject lightIntensityText;
    public GameObject humidityCanSatText;
    public GameObject humidityExternalText;
    public GameObject temperatureMPUText;
    public GameObject temperatureCanSatText;
    public GameObject temperatureExternalText;
    public GameObject airQualityText;
    public GameObject pressureCanSatText;
    public GameObject pressureExternalText;
    public GameObject altitudeCanSatText;
    public GameObject altitudeExternalText;
    public GameObject accelerationXText;
    public GameObject accelerationYText;
    public GameObject accelerationZText;
    public GameObject rotationXText;
    public GameObject rotationYText;
    public GameObject rotationZText;
    public GameObject magnetometerXText;
    public GameObject magnetometerYText;
    public GameObject magnetometerZText;
    public GameObject yearText;
    public GameObject monthText;
    public GameObject dayText;
    public GameObject hourText;
    public GameObject minuteText;
    public GameObject secondText;
    public GameObject numberOfSatellitesText;
    public GameObject currentDrainText;

    private int index = 1;
    private string[] lines;

    void Start()
    {
        string path = "Assets/Files/result.csv";

        StreamReader reader = new StreamReader(path);

        lines = reader.ReadToEnd().Split('\n');

        reader.Close();

        InvokeRepeating("UpdateContent", 0f, 0.4f);
    }

    void UpdateContent()
    {
        int messageId;
        string[] values = lines[index].Split(',');
        if (values.Length >= 36) {
            int.TryParse(values[0], out messageId);
            messageIdText.GetComponent<Text>().text = (messageId - 1985).ToString();
            lightIntensityText.GetComponent<Text>().text = values[1] + " lux";
            temperatureCanSatText.GetComponent<Text>().text = values[4] + " °C";
            temperatureMPUText.GetComponent<Text>().text = values[5] + " °C";
            temperatureExternalText.GetComponent<Text>().text = values[6] + " °C";
            humidityCanSatText.GetComponent<Text>().text = values[7] + " %";
            humidityExternalText.GetComponent<Text>().text = values[8] + " %";
            airQualityText.GetComponent<Text>().text = values[9] + " ug/m3";
            pressureCanSatText.GetComponent<Text>().text = values[10] + " hPa";
            pressureExternalText.GetComponent<Text>().text = values[11] + " hPa";
            altitudeCanSatText.GetComponent<Text>().text = values[12] + " m";
            altitudeExternalText.GetComponent<Text>().text = values[13] + " m";
            accelerationXText.GetComponent<Text>().text = values[14] + " m/s2";
            accelerationYText.GetComponent<Text>().text = values[15] + " m/s2";
            accelerationZText.GetComponent<Text>().text = values[16] + " m/s2";
            rotationXText.GetComponent<Text>().text = values[17] + " °";
            rotationYText.GetComponent<Text>().text = values[18] + " °";
            rotationZText.GetComponent<Text>().text = values[19] + " °";
            magnetometerXText.GetComponent<Text>().text = values[20] + " °";
            magnetometerYText.GetComponent<Text>().text = values[21] + " °";
            magnetometerZText.GetComponent<Text>().text = values[22] + " °";
            yearText.GetComponent<Text>().text = values[23];
            monthText.GetComponent<Text>().text = values[24];
            dayText.GetComponent<Text>().text = values[25];
            hourText.GetComponent<Text>().text = values[26];
            minuteText.GetComponent<Text>().text = values[27];
            secondText.GetComponent<Text>().text = values[28];
            numberOfSatellitesText.GetComponent<Text>().text = values[29];
            currentDrainText.GetComponent<Text>().text = values[36] + "mA";

            index++;
        }        
    }

    void Update()
    {
        
    }
}
