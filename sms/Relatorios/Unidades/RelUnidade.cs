﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atencao_Assistida.Relatorios.Unidades
{
    public partial class RelUnidade : Form
    {
        public RelUnidade()
        {
            InitializeComponent();
        }

        private void RelUnidade_Load(object sender, EventArgs e)
        {
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            reportViewer1.ZoomPercent = 100;

            this.UnidadeTableAdapter.Fill(this.DsUnidade.Unidade);

            this.reportViewer1.RefreshReport();
        }
    }
}
