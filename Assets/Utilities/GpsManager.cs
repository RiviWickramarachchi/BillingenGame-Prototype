using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;
using UnityEngine.UI;
using System.Threading;


//need for the other method to get gps value
public enum LocationState
{
    Disabled,
    TimedOut,
    Enabled,
    Failed
}
public class GpsManager : MonoBehaviour
{
    
    const float earthRadius = 6371; //earth radius is in KM, so the distance should be multiplied by 1000 in order to convert into meters
    private LocationState locationState;
    private float latitude;
    private float longitude;
    private float distance;
    private float total_distance;
    private int x = 1;
    private AbstractLocationProvider _locProvider = null;

    public float Distance { get => distance; set => distance = value; }
    public float Total_distance { get => total_distance; }




    // Start is called before the first frame update
    void Start()
    {
        if (null == _locProvider)
        {
            _locProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }
        print("Script started running");
        //locationState = LocationState.Disabled;
        latitude = 0f;
        longitude = 0f;
        Distance = 0f;

       

        //int xx = 
        //if(Input.location.isEnabledByUser)   
        //{
        //    print("Inside isEnabledByUser");
        //    Input.location.Start();
        //    int waitTime = 15;
        //    print(Input.location.status);
        //    while((Input.location.status == LocationServiceStatus.Initializing) && waitTime >0)
        //    {
        //        yield return new WaitForSeconds(1);
        //        waitTime--;
        //    }
        //    if(waitTime ==0)
        //    {
        //        locationState = LocationState.TimedOut;
        //        print("location state = TimedOut");
        //    }
        //    else if (Input.location.status == LocationServiceStatus.Failed)
        //    {
        //        locationState = LocationState.Failed;
        //        print("location state = Failed");
        //    }
        //    else
        //    {
        //        locationState = LocationState.Enabled;
        //        latitude = Input.location.lastData.latitude;
        //        longitude = Input.location.lastData.longitude;


        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Location currntLoc = _locProvider.CurrentLocation;
        if (currntLoc.IsLocationServiceInitializing)
        {
            print("location services are initializing");
        }
        else
        {
            if (!currntLoc.IsLocationServiceEnabled)
            {
                print("location services not enabled");
            }
            else
            {
                if (currntLoc.LatitudeLongitude.Equals(Vector2d.zero))
                {
                    print("Waiting for location ....");
                }
                else
                {
                    
                    //string[] currentLatLong = (currntLoc.LatitudeLongitude.ToString()).Split(',');
                    //latitude = float.Parse(currentLatLong[0]);
                    //longitude = float.Parse(currentLatLong[1]);
                    float deltaDistance = HaverSine(ref latitude, ref longitude) * 1000f;
                    //print(deltaDistance);
                    if (deltaDistance > 0f)
                    {
                        Distance = Distance + deltaDistance;
                        total_distance = total_distance + deltaDistance;
                        //print(string.Format("Distance travelled = {0}", distance));
                    }
                    print(" distance = " + Distance);
                    print("total_distance = " + Total_distance);
                    if(x ==1)
                    {
                        Distance = 0;
                        total_distance = 0;
                        x++;
                    }
                    
                }
            }
        }

    }

    private float HaverSine(ref float lastLatitude, ref float lastLongitude)
    {
        //print("Last Latitude : " + lastLatitude + " Last Longitude : "+ lastLongitude);
        Location newLoc = _locProvider.CurrentLocation;
        string[] newLatLong = (newLoc.LatitudeLongitude.ToString()).Split(',');
        float newLatitude = float.Parse(newLatLong[0]);
        float newLongitude = float.Parse(newLatLong[1]);
        //print("New Latitude : " + newLatitude + " New Longitude : " + newLongitude);
        float deltaLatitude = (newLatitude - lastLatitude) * Mathf.Deg2Rad;
        float deltaLongitude = (newLongitude - lastLongitude) * Mathf.Deg2Rad;

        float a = Mathf.Pow(Mathf.Sin(deltaLatitude / 2), 2) + Mathf.Cos(lastLatitude * Mathf.Deg2Rad) *
                  Mathf.Cos(newLatitude * Mathf.Deg2Rad) * Mathf.Pow(Mathf.Sin(deltaLongitude / 2), 2);
        lastLatitude = newLatitude;
        lastLongitude = newLongitude;
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        //print("C VALUE : " + c);
        return earthRadius * c;

    }
}
