using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecEsportes
{
    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
            CenterToScreen();
        }

        private void btnCadEquipes_Click(object sender, EventArgs e){
            new Views.CadEquipe().ShowDialog();
        }

        private void btnCadPessoa_Click(object sender, EventArgs e) {
            new Views.CadPessoa().ShowDialog();
        }

        private void btnCadFuncao_Click(object sender, EventArgs e) {
            new Views.CadFuncao().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e) {
            new Views.CadCompeticao().ShowDialog();
        }
    }
}
