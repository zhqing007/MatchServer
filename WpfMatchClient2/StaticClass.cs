using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WpfMatchClient2 {
    class StaticClass {
        public static MatchService2.ServiceClient serviceClient = new MatchService2.ServiceClient();
        public static List<string> staticList = new List<string>();
        public static bool isclosed = false;
    }
}
