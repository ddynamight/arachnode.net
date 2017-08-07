#region License : arachnode.net

// // Copyright (c) 2015 http://arachnode.net, arachnode.net, LLC
// //  
// // Permission is hereby granted, upon purchase, to any person
// // obtaining a copy of this software and associated documentation
// // files (the "Software"), to deal in the Software without
// // restriction, including without limitation the rights to use,
// // copy, merge and modify copies of the Software, and to permit persons
// // to whom the Software is furnished to do so, subject to the following
// // conditions:
// // 
// // LICENSE (ALL VERSIONS/EDITIONS): http://arachnode.net/r.ashx?3
// // 
// // The above copyright notice and this permission notice shall be
// // included in all copies or substantial portions of the Software.
// // 
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// // EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// // OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// // NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// // HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// // WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// // FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// // OTHER DEALINGS IN THE SOFTWARE.

#endregion

#region

using System;
using System.Configuration;
using System.Reflection;
using System.Threading;
using Arachnode.DataSource.Properties;

#endregion

namespace Arachnode.DataSource
{
    public static class ConnectionString
    {
        public static string Value
        {
            get { return ConfigurationManager.ConnectionStrings["arachnode_net_ConnectionString"].ToString(); }
            set
            {
                try
                {
                    Settings.Default.arachnode_net_ConnectionString = value;

                    FieldInfo fieldInfo = typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);

                    if (fieldInfo != null)
                    {
                        fieldInfo.SetValue(ConfigurationManager.ConnectionStrings["arachnode_net_ConnectionString"], false);
                    }

                    ConfigurationManager.ConnectionStrings["arachnode_net_ConnectionString"].ConnectionString = value;
                }
                catch
                {
                    //Thread.Sleep(100000000);
                }
            }
        }
    }
}