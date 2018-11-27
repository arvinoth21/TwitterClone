using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string SayHello(string name);

        [OperationContract]
        string TodayProgram(string name);

        [OperationContract]
        List<string> OpeningJobs();

        [OperationContract]
        string OpeningJobsByRole(int id);

        [OperationContract]
        int Add(int a, int b);

        [OperationContract]
        int Subtract(int a, int b);
        // TODO: Add your service operations here
    }
}
