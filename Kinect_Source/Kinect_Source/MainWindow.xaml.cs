using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;     //Add Microsoft.kinect to Reference

namespace Kinect_Source
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        KinectSensor objKS;   //Kinect Sensor Object
        public MainWindow()
        {
            InitializeComponent();
            objKS = KinectSensor.KinectSensors[0];
            KinectSensor.KinectSensors.StatusChanged +=
                new EventHandler<StatusChangedEventArgs>(Kinects_StatusChanged);
        }


        void Kinects_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            TextBlock1.Text = objKS.Status.ToString();  //Output Kinect Status
        }

        //확인(OK) Button EventHandler
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            int iNumKinect = KinectSensor.KinectSensors.Count;

            String strKinectInfo = null;
            strKinectInfo += iNumKinect.ToString("키넥트 수 : 0개");
            strKinectInfo += "\n";
            strKinectInfo += objKS.UniqueKinectId;     //Kinect ID
            strKinectInfo += "\n";
            strKinectInfo += objKS.DeviceConnectionId; //Connected Kinect ID
            strKinectInfo += "\n";
            strKinectInfo += objKS.Status.ToString(); //Kinect Status

            strKinectInfo += "\n";
            //Kinect Sensor 동작 여부(True/False)
            strKinectInfo += "Kinect 동작 여부 : " + objKS.IsRunning;

            TextBlock1.Text = strKinectInfo;
        }
    }
}
