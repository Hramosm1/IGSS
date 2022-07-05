using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsultaSalud
{
    public partial class frmSalud : Form
    {
        public List<ModelIgss> result = new List<ModelIgss>(); 
        public frmSalud()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSalud_Load(object sender, EventArgs e)
        {
            dataGrid.DefaultCellStyle.ForeColor = Color.Black;
            dataGrid.DataSource = result;
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            try
            {

                if (result.Count > 0)
                {
                    
                    
                    SaveFileDialog csv = new SaveFileDialog();
                    // saveFileDialog1.Filter = "Excel Files |*.xlsx";
                    csv.Filter = "Excel Files |*.xlsx";
                    csv.Title = "Seleccione en donde quiere guardar su archivo";
                    if (csv.ShowDialog() == DialogResult.OK)
                    {
                        SLDocument sl = new SLDocument();
                        DataTable dt = new DataTable();
                        dt.Columns.Add("DPI");
                        dt.Columns.Add("Nombre");
                        dt.Columns.Add("FechaNacimeinto");
                        dt.Columns.Add("Telefono");
                        dt.Columns.Add("CodigoPatrono");
                        dt.Columns.Add("NombrePatrono");
                        dt.Columns.Add("RazonSocial");
                        dt.Columns.Add("MES");
                        dt.Columns.Add("AÑO");
                        dt.Columns.Add("Aporte");
                        foreach (var dato in result)
                        {
                            DataRow dr = dt.NewRow();
                            dr["DPI"] = dato.dpi;
                            dr["Nombre"] = dato.nombre;
                            dr["FechaNacimeinto"] = dato.fecha.ToString("dd/MM/yyyy");
                            dr["Telefono"] = dato.Telefono;
                            dr["CodigoPatrono"] = dato.codigo_patron;
                            dr["NombrePatrono"] = dato.nombre_patrono;
                            dr["AÑO"] = dato.año;
                            dr["MES"] = dato.mes;
                            dr["RazonSocial"] = dato.razon;
                            dr["Aporte"] = dato.aporte;
                            dt.Rows.Add(dr);
                        }

                        sl.ImportDataTable(1, 1, dt, true);
                        sl.SaveAs(csv.FileName);

                       // csv.DefaultExt = ".csv";
                       // EscribirCsv(dt, csv.FileName.Replace(".xlsx", ".csv"));
                    }
                    
                    frmExito.ErrorMensaje("Archivo Descargado");
                }

            }
            catch (Exception ex)
            {

                alerta.ErrorMensaje("Hay un error, " + ex.ToString());
            }
        }
        //public void EscribirCsv(DataTable dataTable, string filePath)
        //{

        //    StringBuilder fileContent = new StringBuilder();

        //    foreach (var col in dataTable.Columns)
        //    {
        //        fileContent.Append(col.ToString() + ",");
        //    }

        //    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

        //    foreach (DataRow dr in dataTable.Rows)
        //    {
        //        foreach (var column in dr.ItemArray)
        //        {
        //            fileContent.Append(column.ToString() + ",");
        //        }

        //        fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
        //    }

        //    System.IO.File.WriteAllText(filePath, fileContent.ToString());
        //}
    }
}
