﻿using Atencao_Assistida.Classes.Mysql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atencao_Assistida.Pesquisas
{
    public partial class PesquisaPadraoSaida : Form
    {
        public PesquisaPadraoSaida()
        {
            InitializeComponent();
        }

        private void PesquisaPadraoSaida_Load(object sender, EventArgs e)
        {
            Carrega("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Carrega(string valor)
        {

            //define um array de strings com nCOlunas
            string[] linhaDados = new string[4];

            //LIMPAR GRID
            Grid.Rows.Clear();
            Grid.Refresh();

            var dr = Saida_Padrao.Select(int.Parse(Usuario.Codempresa), int.Parse(Usuario.Coddepartamento), valor);

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    linhaDados[0] = dr.GetString(dr.GetOrdinal("CODSAIDAPADRAO"));
                    linhaDados[1] = dr.GetString(dr.GetOrdinal("CODUNIDADE"));
                    linhaDados[2] = dr.GetString(dr.GetOrdinal("NOMEUNIDADE"));
                    linhaDados[3] = dr.GetString(dr.GetOrdinal("DATACADASTRO"));
                   

                    Grid.Rows.Add(linhaDados);
                }

            }

            dr.Close();
            dr.Dispose();



        }

        private void txtpesquisa_TextChanged(object sender, EventArgs e)
        {

            Carrega(txtpesquisa.Text);

        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var RowsIndex = Grid.CurrentRow.Index;

            try
            {
                var Codigo = Grid.Rows[RowsIndex].Cells[0].Value.ToString();
                var CodUnidade = Grid.Rows[RowsIndex].Cells[1].Value.ToString();

                Parametros.Valor = Grid.Rows[RowsIndex].Cells[0].Value.ToString();

                Close();
            }
            catch
            {

            }
        }
    }
}
