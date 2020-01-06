using LiveOptics.CloudPricing.Service;
using LiveOptics.CloudPricing.Service.Pricing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LiveOptics.CloudPricing
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //clear previous dumps
            Utility.ClearDumpFolder();

            CancellationToken cancellationToken = new CancellationToken();

            Task[] taskArray = new Task[3];
            //gather specific informations
            taskArray[0] = Task.Factory.StartNew(() =>
            {
                //google
                Console.WriteLine("google started");
                var googleCP = new GoogleCloud();
                googleCP.GatherInformation();
                Console.WriteLine("google finished");
            }, cancellationToken);

            taskArray[1] = Task.Factory.StartNew(() =>
            {
                //aws
                Console.WriteLine("aws started");
                var awsCP = new AWS();
                awsCP.GatherInformation();
                Console.WriteLine("aws finished");
            }, cancellationToken);

            taskArray[2] = Task.Factory.StartNew(() =>
            {
                //azure
                Console.WriteLine("azure started");
                var azureCP = new Azure();
                azureCP.GatherInformation();
                Console.WriteLine("azureCP finished");
            }, cancellationToken);

            Task.WaitAll(taskArray);

            Console.WriteLine("click to exit");
            Console.ReadLine();
        }
    }
}