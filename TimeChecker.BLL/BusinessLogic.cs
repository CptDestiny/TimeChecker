using System;
using System.Data;
using System.Dynamic;

namespace TimeChecker.BLL
{
    public partial class BusinessLogic
    {
        private int User { get; set; }
        private int Type { get; set; }
        private string Date { get; set; }
        private string Time { get; set; }
        private string Comment { get; set; }

        public bool ConnectTest(object sender)
        {
            return true;
        }



    }
}
