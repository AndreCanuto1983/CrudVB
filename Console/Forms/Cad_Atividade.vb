Imports System.Windows.Forms
Imports Console
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class Cad_Atividade

    Private Sub Cad_Atividade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Dim funcoes As New Funcoes

        ' Limpa campos antes de preenche-los
        limparCampos()
        Dim mdiDao = New MdiDAO()
        Dim usuario
        usuario = mdiDao.getUsuario()
        lblCodUsuario.Text = usuario("Usuario")
        lblNomeUsuario.Text = usuario("Perfil")

        ' Preencher combox da tela
        funcoes.PreencherCombo(cboTipoAtividade, "Console_Tipo_Atividade", "Descricao", "Codigo")
        funcoes.PreencherCombo(cboSituacaoAtividade, "Console_Atividade_Situacao", "Situacao", "Codigo")
        funcoes.PreencherCombo(cboUserResponsavel, "Funcionario_Login", "Usuario", "Codigo")
    End Sub

    Private Sub cmdAlterar_Click(sender As Object, e As EventArgs)

        'Dim cadAtividade As New CadAtividade
        'Dim funcoesDAO As New FuncoesDAO

        'If (cadAtividade.verificaCamposObrigatorio(cboTipoAtividade.SelectedIndex, txtDescAtividade.Text, txtDescDetAtividade.Text, _
        '                                          cboSituacaoAtividade.SelectedIndex, cboUserResponsavel.SelectedIndex)) Then
        '    funcoesDAO.AlterarDados("UPDATE Console_Atividade SET" _
        '                            & "Tipo_Atividade = " & CChar(cboTipoAtividade.SelectedValue.ToString) & ", " _
        '                            & "Desc_Atividade = " & txtDescAtividade.Text & ", " _
        '                            & "Desc_Detalhada_Atividade = " & txtDescDetAtividade.Text & ", " _
        '                            & "Situacao = " & CChar(cboSituacaoAtividade.SelectedValue.ToString) & ", " _
        '                            & "Funcionario_Responsavel = " & CChar(cboUserResponsavel.SelectedValue.ToString) & "" _
        '                            & "WHERE Codigo = " & txtCodigo.Text)
        'End If

    End Sub

    Private Sub Cad_Atividade_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        Dim funcoes As New Funcoes
        funcoes.SairTela(e, Me)
    End Sub

    Private Sub txtCodigo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodigo.KeyPress
        Dim funcoes As New Funcoes
        funcoes.SoNumeros(e)
    End Sub

    Private Sub txtCodigo_KeyUp(sender As Object, e As KeyEventArgs) Handles txtCodigo.KeyUp
        Dim cadAtividade As New CadAtividade
        If (cadAtividade.verificaLostFocus(e, txtCodigo.Text)) Then

            cboTipoAtividade.SelectedValue = cadAtividade.tipoAtividade
            lblCodCadastrou.Text = cadAtividade.usuarioCadastrouCodigo
            lblUserCadastrou.Text = cadAtividade.usuarioCadastrouNome
            'lblCodUsuario.Text =
            'lblNomeUsuario
            txtDescAtividade.Text = cadAtividade.descricaoAtividade
            txtDescDetAtividade.Text = cadAtividade.descricaoDetalhadaAtividade
            cboSituacaoAtividade.SelectedValue = cadAtividade.situacaoAtividade
            cboUserResponsavel.SelectedValue = cadAtividade.usuarioResponsavel

        End If
    End Sub

    Private Sub cmdGravar_Click(sender As Object, e As EventArgs) Handles cmdGravar.Click

        Dim cadAtividade As New CadAtividade
        If (cadAtividade.verificaCamposObrigatorio(cboTipoAtividade.SelectedIndex, txtDescAtividade.Text, txtDescDetAtividade.Text, cboSituacaoAtividade.SelectedIndex, cboUserResponsavel.SelectedIndex)) Then
            cadAtividade.gravarAtividade(CChar(cboTipoAtividade.SelectedValue.ToString), txtDescAtividade.Text, txtDescDetAtividade.Text, CChar(cboSituacaoAtividade.SelectedValue.ToString), CChar(cboUserResponsavel.SelectedValue.ToString), lblCodUsuario.Text)
            limparCampos()
        End If

    End Sub

    Private Sub txtCodigo_LostFocus(sender As Object, e As EventArgs) Handles txtCodigo.LostFocus
        'Dim cadAtividade As New CadAtividade
        'If (cadAtividade.verificaLostFocus(e, txtCodigo.Text)) Then

        '    cboTipoAtividade.SelectedValue = cadAtividade.tipoAtividade
        '    lblCodCadastrou.Text = cadAtividade.usuarioCadastrouCodigo
        '    lblUserCadastrou.Text = cadAtividade.usuarioCadastrouNome
        '    'lblCodUsuario.Text =
        '    'lblNomeUsuario
        '    txtDescAtividade.Text = cadAtividade.descricaoAtividade
        '    txtDescDetAtividade.Text = cadAtividade.descricaoDetalhadaAtividade
        '    cboSituacaoAtividade.SelectedValue = cadAtividade.situacaoAtividade
        '    cboUserResponsavel.SelectedValue = cadAtividade.usuarioResponsavel

        'End If
    End Sub

    Private Sub limparCampos()
        Dim Cad_Atividades As New Cad_Atividade

        txtCodigo.Text = ""
        cboSituacaoAtividade.SelectedValue = 0
        txtDescAtividade.Text = ""
        txtDescDetAtividade.Text = ""
        cboTipoAtividade.SelectedValue = 0
        cboUserResponsavel.SelectedValue = 0
        lblCodCadastrou.Text = ""
        lblUserCadastrou.Text = ""

    End Sub


    Private Sub txtCodigo_MouseClick(sender As Object, e As MouseEventArgs) Handles txtCodigo.MouseClick
        limparCampos()
    End Sub
End Class