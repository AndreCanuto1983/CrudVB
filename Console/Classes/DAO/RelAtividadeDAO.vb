Imports Console.MDI
Imports System.Data.SqlClient
Imports System.Data.Sql
Public Class RelAtividadeDAO
    Dim qtdLinhas As String
    Public Sub ConfigurarGrade(grdRelAtividades As DataGridView)
        'Configurando os nomes das colunas da grade
        grdRelAtividades.Columns(0).HeaderText = "Código"
        grdRelAtividades.Columns(1).HeaderText = "Tipo"
        grdRelAtividades.Columns(2).HeaderText = "Descrição"
        grdRelAtividades.Columns(3).HeaderText = "Descrição Detalhada"
        grdRelAtividades.Columns(4).HeaderText = "Situação"
        grdRelAtividades.Columns(5).HeaderText = "Data Cadastro"
        grdRelAtividades.Columns(6).HeaderText = "Funcionário Responsável"
        grdRelAtividades.Columns(7).HeaderText = "Data Baixa"
        grdRelAtividades.Columns(8).HeaderText = "Funcionário Baixou"
        grdRelAtividades.Columns(9).HeaderText = "Funcionário Cadastrou"
        grdRelAtividades.Columns(10).HeaderText = "Inativo"

        'Configurando o tamanho das colunas da grade
        grdRelAtividades.Columns(0).Width = 60
        grdRelAtividades.Columns(1).Width = 60
        grdRelAtividades.Columns(2).Width = 120
        grdRelAtividades.Columns(3).Width = 190
        grdRelAtividades.Columns(4).Width = 80
        grdRelAtividades.Columns(5).Width = 125
        grdRelAtividades.Columns(6).Width = 190
        grdRelAtividades.Columns(7).Width = 100
        grdRelAtividades.Columns(8).Width = 150
        grdRelAtividades.Columns(9).Width = 150

        ' criar botão na grade
        Dim btn As New DataGridViewButtonColumn()
        btn.HeaderText = "Visualizar"
        btn.Name = "cmdVisualizar"
        btn.Text = "Visualizar"
        btn.UseColumnTextForButtonValue = True
        grdRelAtividades.Columns.Add(btn)

    End Sub
    Public Sub RetornaRelAtividade(codigo As TextBox, periodo1 As DateTimePicker, periodo2 As DateTimePicker, cboTipoAtividade As ComboBox, cboSituacao As ComboBox, grdRelAtividades As DataGridView, chkinativo As CheckBox)
        Dim tipoAtividade As Integer
        Dim Situacao As Integer
        Dim query = String.Empty
        Dim inativo As String

        If (periodo2.Value.Date < periodo1.Value.Date) Then
            MessageBox.Show("O segundo período não pode ser menor do que o primeiro período!")
            periodo2.Focus()
        End If
        If (cboTipoAtividade.SelectedIndex < 1) Then
            tipoAtividade = cboTipoAtividade.SelectedIndex
        End If
        If (cboSituacao.SelectedIndex < 1) Then
            Situacao = cboSituacao.SelectedIndex
        End If
        If ((cboTipoAtividade.SelectedIndex > 0) And (cboSituacao.SelectedIndex > 0)) Then
            tipoAtividade = cboTipoAtividade.SelectedValue
            Situacao = cboSituacao.SelectedValue
        End If
        If ((cboTipoAtividade.SelectedIndex > 0) And (cboSituacao.SelectedIndex < 1)) Then
            tipoAtividade = cboTipoAtividade.SelectedValue
        End If
        If ((cboSituacao.SelectedIndex > 0) And (cboTipoAtividade.SelectedIndex < 1)) Then
            Situacao = cboSituacao.SelectedValue
        End If
        If (chkinativo.Checked = True) Then
            inativo = "S"
        Else
            inativo = "N"
        End If

        Dim funcoes = New Funcoes()
        Dim funcoesDAO = New FuncoesDAO()

        Dim periodo As New ArrayList 'pegar os períodos e converter
        periodo.Add(periodo1.Value.Date)
        periodo.Add(periodo2.Value.Date)

        periodo = funcoes.ConverterPeriodo(periodo)

        Try
            If ((codigo.Text = String.Empty) And (tipoAtividade < 1) And (Situacao < 1)) Then
                query = "SELECT ca.Codigo, cta.Descricao, ca.Desc_Atividade, ca.Desc_Detalhada_Atividade, cas.Situacao, ca.Data_Cadastro,"
                query = query & "ca.Funcionario_Responsavel, ca.Data_Baixa, ca.Funcionario_Baixou, fl.Usuario, ca.Inativo FROM Console_Atividade ca "
                query = query & "LEFT JOIN Console_Tipo_Atividade cta ON ca.Tipo_Atividade = cta.Codigo "
                query = query & "LEFT JOIN Console_Atividade_Situacao cas ON ca.Situacao = cas.Codigo "
                query = query & "LEFT JOIN Funcionario f ON ca.Funcionario_Responsavel = f.Codigo AND ca.Funcionario_Baixou = f.codigo "
                query = query & "LEFT JOIN Funcionario_Login fl ON ca.Funcionario_Cadastrou = fl.Codigo "
                query = query & "WHERE ca.Data_Cadastro BETWEEN CONVERT(DATETIME,'" & periodo(0) & "',103) AND CONVERT(DATETIME,'" & periodo(1) & "',103) AND Inativo = '" & inativo & "'"

            ElseIf ((codigo.Text = String.Empty) And (tipoAtividade > 0) And (Situacao < 1)) Then
                query = "SELECT ca.Codigo, cta.Descricao, ca.Desc_Atividade, ca.Desc_Detalhada_Atividade, cas.Situacao, ca.Data_Cadastro,"
                query = query & "ca.Funcionario_Responsavel, ca.Data_Baixa, ca.Funcionario_Baixou, fl.Usuario, ca.Inativo FROM Console_Atividade ca "
                query = query & "LEFT JOIN Console_Tipo_Atividade cta ON ca.Tipo_Atividade = cta.Codigo "
                query = query & "LEFT JOIN Console_Atividade_Situacao cas ON ca.Situacao = cas.Codigo "
                query = query & "LEFT JOIN Funcionario f ON ca.Funcionario_Responsavel = f.Codigo AND ca.Funcionario_Baixou = f.codigo "
                query = query & "LEFT JOIN Funcionario_Login fl ON ca.Funcionario_Cadastrou = fl.Codigo "
                query = query & "WHERE ca.Data_Cadastro BETWEEN CONVERT(DATETIME,'" & periodo(0) & "',103) AND CONVERT(DATETIME,'" & periodo(1) & "',103) AND ca.Tipo_Atividade = " & tipoAtividade & " AND ca.Inativo = '" & inativo & "'"

            ElseIf ((codigo.Text = String.Empty) And (tipoAtividade < 1) And (Situacao > 0)) Then
                query = "SELECT ca.Codigo, cta.Descricao, ca.Desc_Atividade, ca.Desc_Detalhada_Atividade, cas.Situacao, ca.Data_Cadastro,"
                query = query & "ca.Funcionario_Responsavel, ca.Data_Baixa, ca.Funcionario_Baixou, fl.Usuario, ca.Inativo FROM Console_Atividade ca "
                query = query & "LEFT JOIN Console_Tipo_Atividade cta ON ca.Tipo_Atividade = cta.Codigo "
                query = query & "LEFT JOIN Console_Atividade_Situacao cas ON ca.Situacao = cas.Codigo "
                query = query & "LEFT JOIN Funcionario f ON ca.Funcionario_Responsavel = f.Codigo AND ca.Funcionario_Baixou = f.codigo "
                query = query & "LEFT JOIN Funcionario_Login fl ON ca.Funcionario_Cadastrou = fl.Codigo "
                query = query & "WHERE ca.Data_Cadastro BETWEEN CONVERT(DATETIME,'" & periodo(0) & "',103) AND CONVERT(DATETIME,'" & periodo(1) & "',103) AND ca.Situacao = " & Situacao & "AND ca.Inativo = '" & inativo & "'"

            ElseIf ((codigo.Text = String.Empty) And (tipoAtividade > 0) And (Situacao > 0)) Then
                query = "SELECT ca.Codigo, cta.Descricao, ca.Desc_Atividade, ca.Desc_Detalhada_Atividade, cas.Situacao, ca.Data_Cadastro,"
                query = query & "ca.Funcionario_Responsavel, ca.Data_Baixa, ca.Funcionario_Baixou, fl.Usuario, ca.Inativo FROM Console_Atividade ca "
                query = query & "LEFT JOIN Console_Tipo_Atividade cta ON ca.Tipo_Atividade = cta.Codigo "
                query = query & "LEFT JOIN Console_Atividade_Situacao cas ON ca.Situacao = cas.Codigo "
                query = query & "LEFT JOIN Funcionario f ON ca.Funcionario_Responsavel = f.Codigo AND ca.Funcionario_Baixou = f.codigo "
                query = query & "LEFT JOIN Funcionario_Login fl ON ca.Funcionario_Cadastrou = fl.Codigo "
                query = query & "WHERE ca.Data_Cadastro BETWEEN CONVERT(DATETIME,'" & periodo(0) & "',103) AND CONVERT(DATETIME,'" & periodo(1) & "',103) AND ca.Tipo_Atividade = " & tipoAtividade & " AND ca.Situacao = " & Situacao & " AND ca.Inativo = '" & inativo & "'"

            ElseIf ((codigo.Text <> String.Empty) And (tipoAtividade < 1) And (Situacao < 1)) Then
                query = "SELECT ca.Codigo, cta.Descricao, ca.Desc_Atividade, ca.Desc_Detalhada_Atividade, cas.Situacao, ca.Data_Cadastro,"
                query = query & "ca.Funcionario_Responsavel, ca.Data_Baixa, ca.Funcionario_Baixou, fl.Usuario, ca.Inativo FROM Console_Atividade ca "
                query = query & "LEFT JOIN Console_Tipo_Atividade cta ON ca.Tipo_Atividade = cta.Codigo "
                query = query & "LEFT JOIN Console_Atividade_Situacao cas ON ca.Situacao = cas.Codigo "
                query = query & "LEFT JOIN Funcionario f ON ca.Funcionario_Responsavel = f.Codigo AND ca.Funcionario_Baixou = f.codigo "
                query = query & "LEFT JOIN Funcionario_Login fl ON ca.Funcionario_Cadastrou = fl.Codigo "
                query = query & "WHERE ca.Codigo = '" & codigo.Text & "'"

            End If

            Dim grd = funcoesDAO.GerarGradeDT(query)
            grdRelAtividades.DataSource = grd
            grdRelAtividades.DataMember = grd.TableName ' Uso este modelo para retorno data table
            'grdRelAtividades.DataMember = grd.Tables(0).TableName    --> Uso este modelo quando o retorno é data set
            ConfigurarGrade(grdRelAtividades)
            grdRelAtividades.Refresh()
            grdRelAtividades.Update()
            qtdLinhas = Convert.ToString(grd.Rows.Count) 'Verifico a quantidade de registros retornado
            Dim relAtv = New Rel_Atividade()
            relAtv.lblTotalAtividades.Text = Convert.ToString(qtdLinhas)
        Catch ex As Exception
            grdRelAtividades.Columns.Clear()
            qtdLinhas = "0"
            MessageBox.Show("Nenhum registro foi encontrado!")
        End Try
    End Sub

    Public Sub verificaCliqueBotaoGrade(e As DataGridViewCellEventArgs, grdRelAtividades As DataGridView)
        If (e.ColumnIndex = 11) Then
            Try
                Dim Cad_Atividade = New Cad_Atividade()

                Dim cod = grdRelAtividades.Rows(e.RowIndex).Cells("Codigo").Value.ToString()
                If (cod <> String.Empty) Then
                    Dim funcoesDAO As New FuncoesDAO
                    Dim retorno As SqlDataReader

                    retorno = funcoesDAO.ConsultarDados("Select * From Console_Atividade WHERE Codigo = " & cod & "")

                    Cad_Atividade.Show()
                    Cad_Atividade.txtCodigo.Text = cod
                    Cad_Atividade.cboTipoAtividade.SelectedValue = retorno("Tipo_Atividade")
                    Cad_Atividade.txtDescAtividade.Text = retorno("Desc_Atividade")
                    Cad_Atividade.txtDescDetAtividade.Text = retorno("Desc_Detalhada_Atividade")
                    Cad_Atividade.cboSituacaoAtividade.SelectedValue = retorno("Situacao")
                    Cad_Atividade.cboUserResponsavel.SelectedValue = retorno("Funcionario_Responsavel")
                Else
                    MessageBox.Show("Nenhum registro para exportar!")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    Public Function RetornarQtdLinhas()
        Return qtdLinhas
    End Function
End Class
