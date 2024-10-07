using Ej1.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ej1
{
    public partial class Form1 : Form
    {
        FiscalizadorVTV FiscalizadorVTV = new FiscalizadorVTV();
        VTV vtv;
        public Form1()
        {
            InitializeComponent();
        }
        #region
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        #endregion 
        private void btnCargar_Click(object sender, EventArgs e)
        {
            string nom = tBnombre.Text;
            int dni = Convert.ToInt32(tBdni.Text);
            string email = tBemail.Text;
            Propietario p = null;
            try
            {
                p = new Propietario(dni, nom, email);
            }
            catch (DniInvalidoException ex)
            {
                MessageBox.Show("Error\n" + ex.Message);
            }
            catch (PatenteInvalidaException ex)
            {
                MessageBox.Show("Error\n" + ex.Message);
            }
            DateTime hoy = dateTime.Value;
            string pat = tBpatente.Text;
            vtv = new VTV(pat, p);
            int i = 0;
            FormEvaluacion ev;
            FormVer ver = new FormVer();
            while(i<vtv.CantidadVerificaciones)
            {
                ev = new FormEvaluacion();               
                Evaluacion eval = vtv[i];
                vtv.Fecha = hoy;
                ev.tBnombre.Text = eval.Nombre;
                ev.tBdesc.Text = eval.Descripcion;
                if (eval is EvaluacionParametrica)
                {
                    EvaluacionParametrica evalu = (EvaluacionParametrica)eval;
                    
                    ev.groupBox2.Enabled = false;                    
                    ev.tBminimo.Enabled = false;
                    ev.tBmaximo.Enabled = false;
                    ev.tBminimo.Text = evalu.ValorMinimo.ToString();
                    ev.tBmaximo.Text = evalu.ValorMaximo.ToString();

                    if (ev.ShowDialog() == DialogResult.OK)
                    {
                        
                        double med = Convert.ToDouble(ev.tBmedido.Text);
                        evalu.ValorMedido = med;
                    }
                }
                else
                {
                    EvaluacionSimple evalu = (EvaluacionSimple)eval;
                    ev.groupBox1.Enabled = false;                
                    if (ev.ShowDialog() == DialogResult.OK)
                    {
                        bool correcto = ev.cBfunciona.Checked;
                        evalu.HaVerificado = correcto;
                    }
                }
                ver.tBdatos.Text += eval.ToString();
                i++;                               
            }
            ver.tBdatos.Text += FiscalizadorVTV.AgregarVTV(p, pat).ToString();
            ver.ShowDialog();
        }
    }
}
