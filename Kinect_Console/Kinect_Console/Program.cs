using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;      //Add Microsoft.Kinect to Reference

namespace Kinect_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KinectSensor objKS;  //Kinect Sensor Object
            objKS = KinectSensor.KinectSensors[0];

            while (true)
            {
                int iNumKinect = KinectSensor.KinectSensors.Count;

                String strKinectInfo = null;
                strKinectInfo += iNumKinect.ToString("키넥트 수 : 0개");
                strKinectInfo += "\n";
                strKinectInfo += objKS.UniqueKinectId;         //Kinect ID
                strKinectInfo += "\n";
                strKinectInfo += objKS.DeviceConnectionId;     //Connected Kinect ID
                strKinectInfo += "\n";
                strKinectInfo += objKS.Status.ToString();      //Kinect Status
                
                strKinectInfo += "\n";
                //Kinect Sensor 동작 여부(true/false)
                strKinectInfo += "Kinect 동작 여부 : " + objKS.IsRunning;

                //Kinect 정보 : strKinectInfo 출력
                Console.WriteLine(strKinectInfo);

                //ESC key
                if (Console.ReadKey().Key == ConsoleKey.Escape) break;
            }
        }
    }
}
