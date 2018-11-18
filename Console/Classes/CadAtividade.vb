Imports Console.Cad_Atividade

Public Class CadAtividade

    'Metodo utilizado para verificar o preenchimento dos campos obrigatrios da tela de Cadastro de Atividade
    Public Function verificaCamposObrigatorio()

        Dim telaCadAtividade As New Cad_Atividade
        Dim preenchido As Boolean = True

        If telaCadAtividade.cboSituacao.SelectedIndex < 0 Then
            MsgBox("Selecione o Tipo da Atividade!")
            Return preenchido = False
            Exit Function
        ElseIf telaCadAtividade.txtDescAtividade.Text = "" Then
            MsgBox("Informe a Descrição da Atividade!")
            Return preenchido = False
            Exit Function
        ElseIf telaCadAtividade.txtDescDetAtividade.Text = "" Then
            MsgBox("Informe a Descrição Detalhada da Atividade!")
            Return preenchido = False
            Exit Function
        ElseIf telaCadAtividade.cboSituacao.SelectedIndex < 0 Then
            MsgBox("Selecione a Situação da Atividade!")
            Return preenchido = False
            Exit Function
            End If

            Return preenchido

    End Function

End Class
