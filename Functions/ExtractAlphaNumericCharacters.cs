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

using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Server;

#endregion

public partial class UserDefinedFunctions
{
    /// <summary>
    /// 	Extracts the alpha and numeric characters from an input string.
    /// </summary>
    /// <param name = "source">The source.</param>
    /// <returns></returns>
    [SqlFunction]
    [return: SqlFacet(MaxSize = -1)]
    public static SqlString ExtractAlphaNumericCharacters([SqlFacet(MaxSize = -1)] SqlString source)
    {
        if (!source.IsNull)
        {
            return Regex.Replace(source.Value, @"[^a-zA-Z0-9 ]", string.Empty, RegexOptions.Compiled);
        }

        return null;
    }
} ;