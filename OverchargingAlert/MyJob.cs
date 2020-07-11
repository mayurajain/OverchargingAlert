using FluentScheduler;
using System;
using System.Media;
using System.Windows.Forms;

namespace OverchargingAlert
{

    public class MyJob : IJob
    {
        //Percentage check Method
        public void Execute()
        {
            //Set this value to change maximum permited charge percent
            int maximumCharge = 95;

            //To get power related information of current state of laptop
            PowerStatus powerStatus = SystemInformation.PowerStatus;

            //Extracting only battery percentage information
            int BatteryPercentage = (int)(powerStatus.BatteryLifePercent * 100);

            //To check if laptop is running on battery
            bool isRunningOnBattery = SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline;

            //Checking if battery percentage has exceded 90% and if laptop is still plugged in
            if (BatteryPercentage >= maximumCharge && isRunningOnBattery == false)
            {
                SoundPlayer player = new SoundPlayer
                {
                    SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\NotificationTone.wav"
                };
                player.Play();
                string message = "We observed that your laptop has charged sufficiently,Please unplug the charger.";
                string title = "Overcharging Alert!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
                Console.WriteLine(isRunningOnBattery);
                if (result == DialogResult.OK)
                {
                    player.Stop();
                }

            }
        }
    }
}
