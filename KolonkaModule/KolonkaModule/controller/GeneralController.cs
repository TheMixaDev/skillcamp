using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KolonkaModule.controller
{
    class GeneralController
    {
        /// <summary>
        /// Стилизация формы
        /// </summary>
        /// <param name="form">Форма</param>
        public static void Stylizer(Form form)
        {
            Dictionary<string, Size> defaultSize = new Dictionary<string, Size>();
            Dictionary<string, Point> defaultLocation = new Dictionary<string, Point>();
            Dictionary<string, float> defaultFont = new Dictionary<string, float>();
            Dictionary<string, int[]> defaultColumn = new Dictionary<string, int[]>();
            void Resize(object o, EventArgs args)
            {
                double width = (double)((Control)o).Width / (double)form.MinimumSize.Width;
                double height = (double)((Control)o).Height / (double)form.MinimumSize.Height;
                foreach (Control control in form.Controls)
                {
                    Size standart;
                    Point location;
                    float font;
                    if (defaultSize.TryGetValue(control.Name, out standart) &&
                        defaultLocation.TryGetValue(control.Name, out location) &&
                        defaultFont.TryGetValue(control.Name, out font))
                    {
                        control.Width = (int)Math.Floor(standart.Width * width);
                        control.Height = (int)Math.Floor(standart.Height * height);
                        control.Location = new Point((int)Math.Floor(location.X * width), (int)Math.Floor(location.Y * height));
                        try
                        {
                            control.Font = new Font(control.Font.Name, (float)Math.Floor(font * Math.Min(width, height)), FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                        }
                        catch { }
                    }
                    int[] collection;
                    if (defaultColumn.TryGetValue(control.Name, out collection))
                    {
                        foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
                        {
                            column.Width = (int)Math.Floor(collection[column.Index] * width);
                        }
                    }
                }
            }
            form.Resize += new EventHandler(Resize);
            form.MinimumSize = new Size(form.Size.Width, form.Size.Height);
            form.BackColor = Color.White;
            foreach (Control control in form.Controls)
            {
                defaultSize.Add(control.Name, new Size(control.Size.Width, control.Size.Height));
                defaultLocation.Add(control.Name, new Point(control.Location.X, control.Location.Y));
                control.Font = new System.Drawing.Font(control.Font.Name, control.Font.Size, control.Font.Style, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                try
                {
                    defaultFont.Add(control.Name, control.Font.Size);
                }
                catch { }
                if (control is Button)
                {
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    ((Button)control).BackColor = Color.Aqua;
                    ((Button)control).ForeColor = Color.Black;
                }
                if (control is ComboBox)
                {
                    ((ComboBox)control).FlatStyle = FlatStyle.Flat;
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                }
                if (control is DataGridView)
                {
                    ((DataGridView)control).DefaultCellStyle.BackColor = Color.FromArgb(231, 150, 191);
                    List<int> widths = new List<int>();
                    foreach (DataGridViewColumn column in ((DataGridView)control).Columns)
                    {
                        widths.Add(column.Width);
                    }
                    defaultColumn.Add(control.Name, widths.ToArray());
                }
                if(control is ComboBox)
                {
                    ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }
    }
}
