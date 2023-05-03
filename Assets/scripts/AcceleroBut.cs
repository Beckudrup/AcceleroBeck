using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using TMPro;
public class AcceleroBut : MonoBehaviour
{

    public int test = 8;
    StreamWriter motionData;
    public TMP_Text realTimeAccel;
    public TMP_Text buttontext;
    public TMP_Text restartButton;
    //float tilt = 0f;
    public float timer = 2.0f;
    //bool testButton = false;
    //string delimiter = ", ";
    public int attempt = 0;
    public List<float> data = new List<float>(); 
    bool isRecording = false;
    public void Start()
    {
        buttontext.text = "Press to start test";
        realTimeAccel.text = "";
        restartButton.text = "Press AFTER each run";

        //string fn = Application.persistentDatapath;

        //string fullFilename = Path.Combine(Application.persistentDataPath, $"Accelerometer_Data{attempt}.csv"); //@"This PC\Singup's Note20 Ultra\Internal storage\Document\SUPER.csv";
        //motionData = new StreamWriter(fullFilename, true);

        /*
        FileStream f = new FileStream("C:\\gaming.csv", FileMode.OpenOrCreate);
        StreamWriter motionData = new StreamWriter(f);
        */
        /*
        motionData.WriteLine("haha");
        motionData.Close();
        */
    }
    public void FixedUpdate()
    {

            if (!isRecording) return;
            timer -= Time.deltaTime;
            buttontext.text = timer.ToString("0.00");

            float tilt = Input.acceleration.y;
            realTimeAccel.text = tilt.ToString("0.00"); 
            data.Add(tilt);

        if (timer >= 0) return;
        isRecording = false;
        makefile();
            //string dataText = (tilt.ToString("0.00")); //Tror det skal stå sådan her? neden under original.
            //motionData.WriteLine("ord");
            //motionData.WriteLine(data);
            
        }
        

        // 

        //testButton = false;
    

    public void makefile()
    {
        attempt += 1;
        //string dataFile = $"C:\\temp\\gaming{attempt}.csv";
        string dataFile = Path.Combine(Application.persistentDataPath, $"Accelerometer_Data{attempt}.csv");
        StreamWriter streamWriter = new StreamWriter(dataFile, true);
        foreach (var n in data)
        {
            streamWriter.WriteLine(n);

            //dataText.text = n.ToString("0.00");
        }
        streamWriter.Close();
        isRecording = false;
    }




    public void AccelerometerTest(){

        
        isRecording = true;
        timer = 2.0f;
        data.Clear();
        //attempt += 1;
        /*
        if (timer >= 0)
        {
         // string dataText = ("{1}", x) + delimiter + ("{2}", y) + delimiter + ("{3}", z);
         
         //motionData.WriteLine(dataText);
        }
        else {
            //motionData.Close();
            Debug.Log("stinky påååpååå");
            
        }    
        */
        

    }/*
    public void restart()
    {
        motionData.Close();
    }
*/
    
}
