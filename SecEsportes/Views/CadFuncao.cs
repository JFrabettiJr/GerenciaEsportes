using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecEsportes.Views
{
    public partial class CadFuncao : Form
    {
        public CadFuncao()
        {
            InitializeComponent();

            Infraestrutura.SQLiteDatabase.Instance.createTables();

            List<Modelo.Funcao> funcoes = Repositorio.FuncaoRepositorio.Instance.getFuncoes();
            dgvFuncoes.DataSource = funcoes;

            for (var iCount = 0; iCount < dgvFuncoes.Columns.Count; iCount++){
                switch (dgvFuncoes.Columns[iCount].DataPropertyName){
                    case nameof(Modelo.Funcao.id):
                        dgvFuncoes.Columns[iCount].HeaderText = "Código";
                        break;
                    case nameof(Modelo.Funcao.descricao):
                        dgvFuncoes.Columns[iCount].HeaderText = "Descrição";
                        break;
                }
            }

            dgvFuncoes.Refresh();

        }
    }
}
