using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ASPxGridView1_HeaderFilterFillItems(object sender, DevExpress.Web.ASPxGridViewHeaderFilterEventArgs e)
    {
        if (e.Column.FieldName == "CategoryName") {
            var orderedList = e.Values.OrderByDescending(x => x.DisplayText, new MyComparer()).ToList();
            e.Values.Clear();
            e.Values.AddRange(orderedList);
        }        
    }
    public class MyComparer:IComparer<string>
    {       
        public MyComparer()
        {
            
        }
        public int Compare(string x, string y)
        {            
            if (x == y)
                return 0;
            if (x.StartsWith("(") && y.StartsWith("("))
                return -String.Compare(x.Substring(1), y.Substring(1));
            if (x == "(All)" || x == "(Blanks)" || x == "(Non blanks)")
                return 1;
            if (y == "(All)" || y == "(Blanks)" || y == "(Non blanks)")
                return -1;
            return String.Compare(x, y);             
        }
    }
}