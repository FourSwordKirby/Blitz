﻿using System;
using UnityEngine;
using System.Collections;
using SimpleJSON;

public class Weather : MonoBehaviour {

    private const string APIKEY = "b0b79e758e2d59d38681b665080f909f";
    public string currentIP;
    public string currentCountry;
    public string currentCity;

    //Light
    public int lightMax = 0;
    public bool isNightTime = false;

    //Data
    public int cloudinessPercentage;
    public int humidityPercentage;
    public float finalTemp;

    //Status
    public int counter = 0;
    private int refreshWaitTime = 1000;
    private bool isRunning = false;
    public bool weatherSyncWorking = false;
    public string status = "";

    //retrieved from weather API
    public string retrievedCountry;
    public string retrievedCity;
    public int conditionID;
    public string conditionName;
    public string countryCode;
    public string clouds;
    public string sunriseTime;
    public string sunsetTime;
    private System.DateTime sunrise;
    private System.DateTime sunset;

    void Awake()
    {
        StartCoroutine(attemptConnect());
    }

    IEnumerator attemptConnect()
    {
        StopCoroutine(SendRequest());
        StartCoroutine(SendRequest());
        while (status == "")
        {
            //Debug.Log ("Connecting...");
            yield return null;
        }
        if (status != "Working")
            Debug.Log("connection failed");
    }

    IEnumerator getIP()
    {
        WWW IPRequest = new WWW("api.ipify.org/?format=json");
        yield return IPRequest;

        if (IPRequest.error == null || IPRequest.error == "")
        {
            var N = JSON.Parse(IPRequest.text);
            currentIP = N["ip"].Value;
            Debug.Log (currentIP);
        }
    }

    IEnumerator SendRequest()
    {
        //get the players IP, City, Country
        Network.Connect("http://google.com");
        Network.Disconnect();

        WWW IPRequest = new WWW("api.ipify.org/?format=json");
        yield return IPRequest;

        if (IPRequest.error == null || IPRequest.error == "")
        {
            var N = JSON.Parse(IPRequest.text);
            currentIP = N["ip"].Value;
        }

        WWW cityRequest = new WWW("http://www.geoplugin.net/json.gp?ip=" + currentIP); //get our location info
        yield return cityRequest;

        if (cityRequest.error == null || cityRequest.error == "")
        {
            var N = JSON.Parse(cityRequest.text);
            //Debug.Log (N);
            currentCountry = N["geoplugin_countryName"].Value;
            countryCode = N["geoplugin_countryCode"].Value;
            string regionCode = N["geoplugin_regionCode"].Value;
            string city = (N["geoplugin_city"].Value).Replace(" ", "");
            currentCity = city + "," + regionCode + countryCode;
            status = "Working";
            isRunning = true;
        }

        else
        {
            Debug.LogError("WWW error: " + cityRequest.error);
            status = "Internet problem";
            isRunning = false;
        }

        //get the current weather
        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?q=" + currentCity + "&APPID=" + APIKEY); //get our weather
        yield return request;
        Debug.Log(currentCity);
        /*
        if (request.error == null || request.error == "")
        {
            var N = JSON.Parse(request.text);
            status = "Working";
            isRunning = true;
            Debug.Log(N);

            retrievedCountry = N["sys"]["country"].Value; //get the country
            retrievedCity = N["name"].Value; //get the city
            sunrise = (UnixTimeStampToDateTime(int.Parse(N["sys"]["sunrise"])));
            sunset = (UnixTimeStampToDateTime(int.Parse(N["sys"]["sunset"])));

            string temp = N["main"]["temp"].Value; //get the temperature
            float tempTemp; //variable to hold the parsed temperature
            float.TryParse(temp, out tempTemp); //parse the temperature
            finalTemp = Mathf.Round(((tempTemp - 273.0f) * 10) / 10); //holds the actual converted temperature

            int.TryParse(N["weather"][0]["id"].Value, out conditionID); //get the current condition ID
            conditionName = N["weather"][0]["main"].Value; //get the current condition Name
            //conditionName = N["weather"][0]["description"].Value; //get the current condition Description
            clouds = N["clouds"]["all"].Value;
            float tempCloud;
            float.TryParse(clouds, out tempCloud);
            cloudinessPercentage = Mathf.RoundToInt(tempCloud);

            string humidity = N["main"]["humidity"].Value; //get the humitity
            float tempHumidity;
            float.TryParse(humidity, out tempHumidity);
            humidityPercentage = Mathf.RoundToInt(tempHumidity);

            //Update Light Levels
            lightMax = getSunLevels();

            //Update weather effects in a room
            //			Debug.Log (System.DateTime.Now);
            //			GameObject skylight = GameObject.FindGameObjectWithTag("Sunlight");
            //			if(skylight != null) {
            //				SkylightFade s = skylight.GetComponent<SkylightFade>();
            //				if(s != null) s.updateSkylightColor();
            //		}
            //Adjust Max Sun
            GameObject lightLevels = GameObject.FindGameObjectWithTag("LightLevels");
            if (lightLevels != null) lightLevels.GetComponent<LightLevels>().upperBound = lightMax + 2;
        }
        else
        {
            Debug.LogError("WWW error: " + request.error);
            status = "Internet problem";
            isRunning = false;
        }

        if (currentCity == "")
        {
            Debug.LogError("Weather Sync Failed at IP " + currentIP);

        }
         */
    }

    public static System.DateTime UnixTimeStampToDateTime(int unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
        //return dtDateTime.ToString("hh:mm tt");
        return dtDateTime;
    }
}
