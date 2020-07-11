using FluentScheduler;

namespace OverchargingAlert
{
    public class MyRegistry : Registry
    {

        public MyRegistry()
        {
            //Set this value to change frequency of check
            int frequencyOfCheck = 15;

            //To schedule Percentage Check operation every 15 Minutes once
            Schedule<MyJob>().ToRunNow().AndEvery(frequencyOfCheck).Minutes();
        }
    }
}
