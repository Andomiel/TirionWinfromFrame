using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformGeneralDeveloperFrame.Commons
{
    /// <summary>
    /// sqlserv数据库字段数据类型对应C#类型
    /// </summary>
    public sealed class SqlserverDataTypeToModelDataType
    {
        public static string ChangedType(string type)
        {
            string reval = string.Empty;
            switch (type.ToLower())
            {
                case "bigint":
                    reval = "long";
                    break;
                case "binary":
                    reval = "byte[]";
                    break;
                case "bit":
                    reval = "bool";
                    break;
                case "char":
                    reval = "string";
                    break;
                case "date":
                    reval = "DateTime";
                    break;
                case "datetime":
                    reval = "DateTime";
                    break;
                case "datetime2":
                    reval = "DateTime";
                    break;
                case "datetimeoffset":
                    reval = "DateTimeOffset";
                    break;
                case "decimal":
                    reval = "decimal";
                    break;
                case "float":
                    reval = "double";
                    break;
                case "image":
                    reval = "byte[]";
                    break;
                case "int":
                    reval = "int";
                    break;
                case "money":
                    reval = "decimal";
                    break;
                case "numeric":
                    reval = "decimal";
                    break;
                case "nvarchar":
                    reval = "string";
                    break;
                case "ntext":
                    reval = "string";
                    break;
                case "real":
                    reval = "float";
                    break;

                case "smalldatetime":
                    reval = "DateTime";
                    break;
                case "smallint":
                    reval = "short";
                    break;
                case "smallmoney":
                    reval = "decimal";
                    break;
                case "text":
                    reval = "string";
                    break;
                    
                case "time":
                    reval = "TimeSpan";
                    break;
                case "timestamp":
                    reval = "byte[]";
                    break;
                case "tinyint":
                    reval = "byte";
                    break;
                case "uniqueidentifier":
                    reval = "Guid";
                    break;
                case "varbinary":
                    reval = "byte[]";
                    break;
                case "varchar":
                    reval = "string";
                    break;
                case "xml":
                    reval = "string";
                    break;
                default:
                    reval = "string";
                    break;
            }

            return reval;
        }
    }
}
