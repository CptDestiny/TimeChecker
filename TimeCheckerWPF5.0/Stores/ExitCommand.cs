using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeCheckerWPF5_0.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TimeCheckerWPF5_0.Stores
{
    class ExitCommand : CommandBase
    {
   
        public override void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}

