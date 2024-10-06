using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion.Models.Extensions
{
    /// <summary>
    /// This class is used for Extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Evaluatting the string
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static double Evaluate(this string expression)
        {
            var loDataTable = new DataTable();
            var loDataColumn = new DataColumn("Eval", typeof(double), expression);
            loDataTable.Columns.Add(loDataColumn);
            loDataTable.Rows.Add(0);
            return Math.Round((double)(loDataTable.Rows[0]["Eval"]), 5);
        }
    }
}
