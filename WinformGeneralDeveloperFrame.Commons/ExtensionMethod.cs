using DevExpress.XtraEditors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ComboBox = System.Windows.Forms.ComboBox;

namespace WinformGeneralDeveloperFrame.Commons
{
    public static class ExtensionMethod
    {
        public static void SetComboxEditDataSource<T>(this ComboBoxEdit cmb,IEnumerable<T> dataSource,string textFileName,string valueFileName)
        {
            foreach (var item in dataSource)
            {
                //cmb.Properties.Items.Add();
            }
        }
		/// <summary>
		/// 显示一般的提示信息
		/// </summary>
		/// <param name="message">提示信息</param>
		public static DialogResult ShowTips(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("提示信息"), MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 显示警告信息
		/// </summary>
		/// <param name="message">警告信息</param>
		public static DialogResult ShowWarning(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("警告信息"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// 显示错误信息
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowError(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("错误信息"), MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 显示询问用户信息，并显示错误标志
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowYesNoAndError(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("错误信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Error);
		}

		/// <summary>
		/// 显示询问用户信息，并显示提示标志
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowYesNoAndTips(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("提示信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
		}

		/// <summary>
		/// 显示询问用户信息，并显示警告标志
		/// </summary>
		/// <param name="message">警告信息</param>
		public static DialogResult ShowYesNoAndWarning(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("警告信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
		}

		/// <summary>
		/// 显示询问用户信息，并显示提示标志
		/// </summary>
		/// <param name="message">错误信息</param>
		public static DialogResult ShowYesNoCancelAndTips(this string message)
		{
			return DevExpress.XtraEditors.XtraMessageBox.Show((message), ("提示信息"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
		}
		//public static string language(this string message)
		//{
		//    return message;
		//}
		public static bool ToBoolean(this string str)
        {
            bool result = false;
            bool.TryParse(str, out result);
            return result;
        }

        public static void SetDataGridViewDoubleBuffered(this DataGridView dataGridView)
        {
            Type dgvType = dataGridView.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dataGridView, true, null);
        }
        /// <summary>
        /// 查询扩展方法
        /// </summary>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName)
        {
            return _OrderBy<T>(query, propertyName, false);
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName)
        {
            return _OrderBy<T>(query, propertyName, true);
        }

        static IOrderedQueryable<T> _OrderBy<T>(IQueryable<T> query, string propertyName, bool isDesc)
        {
            string methodname = (isDesc) ? "OrderByDescendingInternal" : "OrderByInternal";

            var memberProp = typeof(T).GetProperty(propertyName);

            var method = typeof(ExtensionMethod).GetMethod(methodname)
                .MakeGenericMethod(typeof(T), memberProp.PropertyType);

            return (IOrderedQueryable<T>)method.Invoke(null, new object[] { query, memberProp });
        }
        public static IOrderedQueryable<T> OrderByInternal<T, TProp>(IQueryable<T> query, System.Reflection.PropertyInfo memberProperty)
        {//public
            return query.OrderBy(_GetLamba<T, TProp>(memberProperty));
        }
        public static IOrderedQueryable<T> OrderByDescendingInternal<T, TProp>(IQueryable<T> query, System.Reflection.PropertyInfo memberProperty)
        {//public
            return query.OrderByDescending(_GetLamba<T, TProp>(memberProperty));
        }
        static Expression<Func<T, TProp>> _GetLamba<T, TProp>(System.Reflection.PropertyInfo memberProperty)
        {
            if (memberProperty.PropertyType != typeof(TProp)) throw new Exception();

            var thisArg = Expression.Parameter(typeof(T));
            var lamba = Expression.Lambda<Func<T, TProp>>(Expression.Property(thisArg, memberProperty), thisArg);

            return lamba;
        }

        /// <summary>
        /// 转换字符串为Int16类型，可以指定默认值
        /// </summary>
        /// <param name="str">字符串内容</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt16(this string str, Int16 defaultValue = 0)
        {
            str = ConvertHelper.ConvertToDBC(str);//先转换为半角字符串
            bool converted = Int16.TryParse(str, out defaultValue);
            return defaultValue;
        }
        public static DateTime ToDateTime(this object rowValue)
        {
            DateTime defMinValue = DateTime.Parse("1758-01-01 00:00:00");
            DateTime defMaxValue = DateTime.Parse("9999-12-31 23:59:59");
            if (rowValue == null || rowValue == DBNull.Value)
            {
                return defMinValue;//传入空值，返回预设值 
            }
            DateTime d;
            if (DateTime.TryParse(rowValue.ToString(), out d))
            {
                if (d < defMinValue || d > defMaxValue)
                    return defMinValue;//无效日期，预设返回SQL支持的最小日期 
                else
                    return d;
            }
            else
                return defMinValue;
        }
        public static void ModelDataToControl(this Control con, object data)
        {
            Type type = data.GetType();
            foreach (PropertyInfo pro in type.GetProperties())
            {
                if (pro.IsDefined(typeof(ModelBindControlAttribute), true))
                {
                    Control control = getControl(con, pro.GetCustomAttribute<ModelBindControlAttribute>().GetModelName());
                    if (control != null)
                    {
                        
                        if (control is ComboBoxEdit)
                        {
                            ComboBoxEdit txt = (ComboBoxEdit)control;
                            txt.EditValue = pro.GetValue(data) ;
                        }
                        else if (control is DateEdit)
                        {
                            DateEdit txt = (DateEdit)control;
                            txt.EditValue = pro.GetValue(data);
                        }
                        else if (control is CheckEdit)
                        {
                            CheckEdit txt = (CheckEdit)control;
                            txt.Checked = Boolean.Parse(pro.GetValue(data).ToString());

                        }
                        else if (control is LookUpEditBase)
                        {
                            LookUpEditBase txt = (LookUpEditBase)control;
                            txt.EditValue = pro.GetValue(data);
                        }
                        else if (control is CheckedComboBoxEdit)
                        {
                            CheckedComboBoxEdit txt = (CheckedComboBoxEdit)control;
                            txt.SetEditValue(pro.GetValue(data));
                        }
                        else 
                        {
                            TextEdit txt = (TextEdit)control;
                            txt.Text = pro.GetValue(data) == null ? "" : pro.GetValue(data).ToString();
                        }
                    }
                }
            }

        }

        public static Control getControl(this Control con, string name)
        {
            Control[] controls = con.Controls.Find(name, true);
            if (controls.Length > 0)
                return (controls[0]);
            else
            {
                return null;
            }
        }

        public static object ControlDataToModel(this Control con,object data)
        {
            Type type = data.GetType();
            object t = Activator.CreateInstance(type);
            foreach (PropertyInfo pro in type.GetProperties())
            {
                if (pro.IsDefined(typeof(ModelBindControlAttribute), true))
                {
                    Control control = getControl(con, pro.GetCustomAttribute<ModelBindControlAttribute>().GetModelName());
                    if (control != null)
                    {
                        if (control is ComboBoxEdit)
                        {
                            ComboBoxEdit txt = (ComboBoxEdit)control;
                            pro.SetValue(t, txt.EditValue);
                        }
                        else if (control is DateEdit)
                        {
                            DateEdit txt = (DateEdit)control;
                            pro.SetValue(t, txt.DateTime);
                        }
                        else if (control is CheckEdit)
                        {
                            CheckEdit txt = (CheckEdit)control;
                            pro.SetValue(t, txt.Checked);
                        }
                        else if (control is NumericUpDown)
                        {
                            NumericUpDown txt = (NumericUpDown)control;
                            pro.SetValue(t, Convert.ChangeType(txt.Text, pro.PropertyType));
                        }
                        else if (control is LookUpEditBase)
                        {
                            LookUpEditBase txt = (LookUpEditBase)control;
                            if(!string.IsNullOrEmpty(txt.EditValue.ToString()))
                                pro.SetValue(t, Convert.ChangeType(txt.EditValue, pro.PropertyType));
                        }
                        else if (control is CheckedComboBoxEdit)
                        {
                            CheckedComboBoxEdit txt = (CheckedComboBoxEdit)control;
                            pro.SetValue(t, Convert.ChangeType(txt.EditValue, pro.PropertyType));
                        }
                        else
                        {
                            TextEdit txt = (TextEdit)control;
                            if (string.IsNullOrEmpty(txt.Text))
                            {
                                txt.Text = "0";
                            }
                            pro.SetValue(t, Convert.ChangeType(txt.Text,pro.PropertyType));
                        }
                    }
                }
            }
            return t;
        }
        public static T RowToModel<T>(this DataRow dr) where T : new()
        {
            T model = new T();
            foreach (PropertyInfo p in (typeof(T)).GetProperties())
            {
                if (dr[p.Name] is System.DBNull) { continue; }
                p.SetValue(model, dr[p.Name.ToUpper()], null);
            }
            return model;
        }
        /// <summary>
        /// list转datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }
         public static DataTable ToDataTable2<T>(this IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();
            // column names
            PropertyInfo[] oProps = null;
            // Could add a check to verify that there is an element 0
            foreach (T rec in varlist)
            {
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();

                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType; if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow(); foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            return (dtReturn);
        }
    public delegate object[] CreateRowDelegate<T>(T t);

        /// <summary>
        /// 获取datatable数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        public static Dictionary<string, List<T>> GetDataTableData<T>(this DataTable dt)where T:class,new()
        {
            Dictionary<string, List<T>> data = new Dictionary<string, List<T>>();
            List<T> listAdd = new List<T>();
            List<T> listEdit = new List<T>();
            List<T> listDel = new List<T>();
            foreach (DataRow item in dt.Rows)
            {
                if (item.RowState == DataRowState.Added )
                {
                    T t = item.RowToModel<T>();
                    if (t != null)
                    {
                        listAdd.Add(t);
                    }
                }else if (item.RowState == DataRowState.Modified)
                {
                    T t = item.RowToModel<T>();
                    if (t != null)
                    {
                        listEdit.Add(t);
                    }
                }
                //listDel = dt.GetChanges(DataRowState.Deleted).DataTableToList<T>();
                DataTable dtDeleted = dt.GetChanges(DataRowState.Deleted);
                if (dtDeleted != null)
                {
                    foreach (DataRow row in dtDeleted.Rows)
                    {
                        T t = new T();
                        foreach (PropertyInfo fieldInfo in t.GetType().GetProperties())
                        {
                            fieldInfo.SetValue(t, row[fieldInfo.Name, DataRowVersion.Original], null);
                        }
                        listDel.Add(t);
                    }
                }
            }
            data.Add("Add",listAdd);
            data.Add("Del",listDel);
            data.Add("Edit", listEdit);
            return data;
        }
        /// <summary> 
        /// 利用反射将DataTable转换为List<T>对象
        /// </summary> 
        /// <param name="dt">DataTable 对象</param> 
        /// <returns>List<T>集合</returns> 
        public static List<T> DataTableToList<T>(this DataTable dt) where T : class, new()
        {
            // 定义集合 
            List<T> ts = new List<T>();
            //定义一个临时变量 
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性 
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性 
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量 
                    //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值 
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性 
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中 
                ts.Add(t);
            }
            return ts;
        }
        public static string GetDateTimeCode(this DateTime dt)
        {
            return DateTime.Now.Year + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") +
                   DateTime.Now.Hour.ToString("D2") +
                   DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2") +
                   DateTime.Now.Millisecond.ToString("D3");
        }
    }
}
