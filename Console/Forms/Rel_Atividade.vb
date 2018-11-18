Imports Console
Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class Rel_Atividade

    Private Sub cmdSair_Click(sender As Object, e As EventArgs)
        Me.Dispose()
    End Sub
    Public Sub LimparCampos()
        txtCodigo.Text = String.Empty
        dtPeriodo1.ResetText()
        dtPeriodo2.ResetText()
        cboTipoAtividade.SelectedIndex = 0
        cboSituacao.SelectedIndex = 0
        grdRelAtividades.Columns.Clear()
        chkInativo.Checked = False
        lblTotalAtividades.Text = "0"
    End Sub
    
    Private Sub Rel_Atividade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim funcoes As New Funcoes
        funcoes.PreencherCombo(cboTipoAtividade, "Console_Tipo_Atividade", "Descricao", "codigo")
        funcoes.PreencherCombo(cboSituacao, "Console_Atividade_Situacao", "Situacao", "codigo")
        lblTotalAtividades.Text = "0"
    End Sub
    Dim query As String
    Private Sub btnGerar_Click(sender As Object, e As EventArgs) Handles btnGerar.Click
        Dim relAtividadeDAO = New RelAtividadeDAO()
        grdRelAtividades.Columns.Clear()
        relAtividadeDAO.RetornaRelAtividade(txtCodigo, dtPeriodo1, dtPeriodo2, cboTipoAtividade, cboSituacao, grdRelAtividades, chkInativo)
        lblTotalAtividades.Text = relAtividadeDAO.RetornarQtdLinhas()
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim funcoes As New Funcoes
        funcoes.SoNumeros(e)
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim funcoes As New Funcoes
        funcoes.SoNumeros(e)
    End Sub

    Private Sub txtCodigo_Click(sender As Object, e As EventArgs) Handles txtCodigo.Click
        LimparCampos()
    End Sub

    Private Sub Rel_Atividade_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Dim funcoes As New Funcoes
        funcoes.SairTela(e, Me)
    End Sub


    Private Sub grdRelAtividades_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdRelAtividades.CellContentClick
        Dim relAtividadeDAO = New RelAtividadeDAO()
        relAtividadeDAO.verificaCliqueBotaoGrade(e, grdRelAtividades)
    End Sub
End Class