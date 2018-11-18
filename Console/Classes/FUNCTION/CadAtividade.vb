Imports Console
Imports System.Data.SqlClient

Public Class CadAtividade

    Private tpAtividade As Integer
    Private descAtividade As String
    Private descDetalhadaAtividade As String
    Private stAtividade As Integer
    Private userResponsavel As Long
    Private userResponsavelNome As String
    Private userCadastrouCodigo As Long
    Private userCadastrouNome As String


    Public Property tipoAtividade() As Integer
        Get
            Return tpAtividade
        End Get
        Set(value As Integer)
            tpAtividade = value
        End Set
    End Property

    Public Property descricaoAtividade() As String
        Get
            Return descAtividade
        End Get
        Set(value As String)
            descAtividade = value
        End Set
    End Property

    Public Property descricaoDetalhadaAtividade() As String
        Get
            Return descDetalhadaAtividade
        End Get
        Set(value As String)
            descDetalhadaAtividade = value
        End Set
    End Property

    Public Property situacaoAtividade() As Integer
        Get
            Return stAtividade
        End Get
        Set(value As Integer)
            stAtividade = value
        End Set
    End Property

    Public Property usuarioResponsavel() As Long
        Get
            Return userResponsavel
        End Get
        Set(value As Long)
            userResponsavel = value
        End Set
    End Property
    Public Property usuarioResponsavelNome() As String
        Get
            Return userResponsavelNome
        End Get
        Set(value As String)
            userResponsavelNome = value
        End Set
    End Property

    Public Property usuarioCadastrouCodigo() As Long
        Get
            Return userCadastrouCodigo
        End Get
        Set(value As Long)
            userCadastrouCodigo = value
        End Set
    End Property

    Public Property usuarioCadastrouNome() As String
        Get
            Return userCadastrouNome
        End Get
        Set(value As String)
            userCadastrouNome = value
        End Set
    End Property


    'Metodo utilizado para verificar o preenchimento dos campos obrigatrios da tela de Cadastro de Atividade
    Public Function verificaCamposObrigatorio(tipoAtividade As Integer, descAtividade As String, descDetAtividade As String, sitAtividade As Integer, respAtividade As Integer) As Boolean
        'Dim preenchido As Boolean
        Dim Cad_Atividade As New Cad_Atividade
        verificaCamposObrigatorio = False
        Try
            If (tipoAtividade = 0) Then
                MsgBox("Selecione o Tipo de Atividade que será cadastrada!")
                Exit Function
            ElseIf (descAtividade = "") Then
                MsgBox("Informe a Descrição da atividade!")
                Cad_Atividade.txtDescAtividade.Focus()
                Exit Function
            ElseIf (descDetAtividade = "") Then
                MsgBox("Informe a Descrição Detalhada da atividade!")
                Exit Function
            ElseIf (sitAtividade = 0) Then
                MsgBox("Selecione a Situação atual da atividade!")
                Exit Function
            ElseIf (respAtividade = 0) Then
                MsgBox("Selecione o Responsável atual da atividade!")
                Exit Function
            End If
        Catch ex As Exception
            MsgBox("Erro nas validações dos campos!")
        End Try

        verificaCamposObrigatorio = True

        Return verificaCamposObrigatorio

    End Function

    Public Sub gravarAtividade(tipoAtividade As String, descAtividade As String, descDetAtividade As String, situacaoAtividade As String, userResponsavel As String, userCadastrou As String)

        Dim funcDAO As New FuncoesDAO

        funcDAO.InserirDados("INSERT INTO Console_Atividade (" _
                             & "Tipo_Atividade," _
                             & "Desc_Atividade," _
                             & "Desc_Detalhada_Atividade," _
                             & "Situacao," _
                             & "Data_Cadastro," _
                             & "Funcionario_Responsavel," _
                             & "Funcionario_Cadastrou)" _
                             & "VALUES( " _
                             & tipoAtividade & " ,'" _
                             & descAtividade & "','" _
                             & descDetAtividade & "'," _
                             & situacaoAtividade & "," _
                             & "GETDATE()," _
                             & userResponsavel & "," _
                             & userCadastrou & ")")

    End Sub

    Public Function verificaLostFocus(e As KeyEventArgs, codigo As String) As Boolean

        verificaLostFocus = False
        'Ao informar o código da atividade e pressionar enter o sistema carrega a tela com os dados
        Try
            If ((e.KeyCode = Keys.Tab) Or (e.KeyCode = Keys.Enter)) Then
                e.Handled = True
                If (codigo <> "") Then

                    Dim funcoesDAO As New FuncoesDAO
                    Dim retorno As SqlDataReader

                    retorno = funcoesDAO.ConsultarDados("SELECT CA.Codigo," _
                                                       & "CA.Tipo_Atividade," _
                                                       & "CA.Desc_Atividade," _
                                                       & "CA.Desc_Detalhada_Atividade," _
                                                       & "CA.Situacao," _
                                                       & "CA.Data_Cadastro," _
                                                       & "CA.Funcionario_Responsavel," _
                                                       & "FLR.Usuario AS Func_Resp_Nome," _
                                                       & "CA.Data_Baixa," _
                                                       & "CA.Funcionario_Baixou," _
                                                       & "FLB.Usuario AS Func_Baixou_Nome," _
                                                       & "CA.Funcionario_Cadastrou," _
                                                       & "FL.Usuario AS Func_Cadastrou_Nome," _
                                                       & "CA.Inativo " _
                                                       & "FROM Console_Atividade CA " _
                                                       & "INNER JOIN Funcionario_Login FL ON CA.Funcionario_Cadastrou = FL.Codigo " _
                                                       & "INNER JOIN Funcionario_Login FLR ON CA.Funcionario_Responsavel = FLR.Codigo " _
                                                       & "LEFT JOIN Funcionario_Login FLB ON CA.Funcionario_Baixou = FLB.Codigo WHERE CA.Codigo = " & codigo)

                    tipoAtividade = retorno("Tipo_Atividade")
                    descricaoAtividade = retorno("Desc_Atividade")
                    descricaoDetalhadaAtividade = retorno("Desc_Detalhada_Atividade")
                    situacaoAtividade = retorno("Situacao")
                    usuarioResponsavel = retorno("Funcionario_Responsavel")
                    usuarioResponsavelNome = retorno("Func_Resp_Nome")
                    usuarioCadastrouCodigo = retorno("Funcionario_Cadastrou")
                    usuarioCadastrouNome = retorno("Func_Cadastrou_Nome")

                    verificaLostFocus = True

                End If
            End If
        Catch ex As Exception
            MsgBox("Erro ao carregar Atividade !" & Err.Number, Err.Description)
        End Try

        Return verificaLostFocus

    End Function




End Class
