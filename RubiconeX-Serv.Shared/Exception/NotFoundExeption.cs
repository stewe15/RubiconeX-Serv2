using System;
using System.Collections.Generic;
using System.Text;

namespace RubiconeX_Serv.Shared.Exception
{
    public  class NotFoundExeption : System.Exception
    {
        public NotFoundExeption(string message): base(message)
        {

        }
    }
}
