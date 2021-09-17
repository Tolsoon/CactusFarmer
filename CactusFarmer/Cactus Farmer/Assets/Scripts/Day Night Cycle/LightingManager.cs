using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset preset;
    //varibles
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    GameManager GM;
    public Text dayText;
    public Text timerText;
    private void Awake()
    {
        GM = GetComponent<GameManager>();
        dayText.text = "Day: " + GM.day.ToString();
    }
    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime;
            if(TimeOfDay >= 24)
            {
                //adding a day when the time of day reaches close to midnight, growing plants
                TimeOfDay = 0;
                GM.day += 1;
                dayText.text = "Day: " + GM.day.ToString();
                UpdatePlantGrowth();
                
            }

            timerText.text = Math.Round(TimeOfDay,2).ToString();
                        
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
            
        }


    }
    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if(DirectionalLight != null)
        {
            //changes sun position and lighting color for skybox
            //DirectionalLight.color = preset.directionalColor.Evaluate(timePercent);
            //DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 130f, 0));
        }
    }
    private void OnValidate()
    {
        if(DirectionalLight != null)
        {
            return;
        }

        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                }
            }
        }
    }

    //function to add 1 day of growth to each planted plant
    public void UpdatePlantGrowth()
    {
        var plantZones = FindObjectsOfType<PlantingZone>();
        foreach(PlantingZone plantZone in plantZones)
        {
            if(plantZone.plantType != -1)
            {
                plantZone.gameObject.GetComponentInChildren<Cactus>().growthStage += 1;
                plantZone.gameObject.GetComponentInChildren<Cactus>().CheckGrowth();
            }
        }
    }
}
