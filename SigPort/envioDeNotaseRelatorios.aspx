<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="envioDeNotaseRelatorios.aspx.cs" Inherits="SigPort.envioDeNotaseRelatorios" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGPORT</title>
	<link rel="stylesheet" type="text/css" href="css/estilo.css">
	<link rel="icon" href="homeicon.png">
	<meta charset="utf-8">
	<meta name="author" content="Mike Ewerthon de Figueiredo Silva" />
	<link rel="stylesheet" href="css/libs/animate.css">
  	<link rel="stylesheet" href="css/site.css">
	<script src="js/script.js"></script>
   <script src="js/jquery-1.5.2.min.js"></script>
   <style>.wow:first-child {visibility: hidden;}</style>
</head>
<body>
     <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
        <center> 
            <form id="form1" runat="server">
            <div class="containerAapAlunoeRelatorio" runat="server">
                <asp:GridView ID="gvAlunosMateria" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="nomeaap" HeaderText="Nome AAP" />
                    <asp:ButtonField ButtonType="Button" HeaderText="Carregar Dados" Text="Carregar" CommandName="btnCarregar" />
                    <asp:BoundField DataField="idaap" Visible="False" />
                </Columns>
            </asp:GridView>
                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                <br />
            </div>
            <div class="containerAapAlunoeRelatorio">
                <br />
                <asp:Label ID="lblTituloSelecionaAap" runat="server" Text="Selecione a AAP:" class="tituloTabelaInformacoes"></asp:Label>
                
                    <div class="clearfix"></div><br /><br />
                    <asp:TextBox ID="txtIntegranteUm" runat="server" placeholder="Integrante 1" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaIntegranteUm" runat="server" placeholder="Nota do integrante" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtIntegranteDois" runat="server" placeholder="Integrante 2" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaIntegranteDois" runat="server" placeholder="Nota do integrante" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtIntegranteTres" runat="server" placeholder="Integrante 3" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaIntegranteTres" runat="server" placeholder="Nota do integrante" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtIntegranteQuatro" runat="server" placeholder="Integrante 4" class="txtLadoaLado" required></asp:TextBox>
                    <asp:TextBox ID="txtNotaIntegranteQuatro" runat="server" placeholder="Nota do integrante" class="txtLadoaLado" required></asp:TextBox>
                    <br /><br />
                    <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" class="btnRevisaoNotas" OnClick="btnConfirmar_Click"/>
                    <asp:Button ID="btnBaixarArquivo" runat="server" Text="Baixar Arquivo" class="btnRevisaoNotas"/>
                    <asp:Button ID="btnVoltar" runat="server" Text="Voltar" class="btnRevisaoNotas"/>
                    <br /><br />
                
            </div>
            <div class="clearfix"></div>
                </form>
        </center>
    </div>
    <div class="clearfix"></div>
     <% //Response.WriteFile("rodape.htm"); %>
	<script src="dist/wow.js"></script>		
	<script>
	    wow = new WOW(
		{
		    animateClass: 'animated',
		    offset: 100,
		    callback: function (box) {
		        console.log("WOW: animating <" + box.tagName.toLowerCase() + ">")
		    }
		}
		);
	    wow.init();
	    document.getElementById('moar').onclick = function () {
	        var section = document.createElement('section');
	        section.className = 'section--purple wow fadeInDown';
	        this.parentNode.insertBefore(section, this);
	    };
	</script>
</body>
</html>
