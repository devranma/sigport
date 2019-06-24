<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizarAapRelatorioAluno.aspx.cs" Inherits="SigPort.VisualizarAapRelatorioAluno" %>

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
   <style>.wow:first-child {visibility: hidden;}
       .auto-style1 {
           width: 70%;
           height: 370px;
           min-height: 300px;
           padding: 10px;
           background-color: #ffffff;
           border-radius: 8px;
           box-shadow: 2px 2px 29px 5px #222446;
       }
       .auto-style2 {
           clear: both;
           height: 181px;
       }
   </style>
</head>
<body>
     <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
		<center>
			<div class="auto-style1">
				<p class="descricaoForms">Nome da AAP, relatório ou status</p>
				<div class="clearfix"></div>
				<form style="margin-top: 4%;" id="form1" runat="server">
                    <br />
                        <asp:DropDownList ID="selecionarAap" runat="server" class="slcForms" OnSelectedIndexChanged="selecionarAap_SelectedIndexChanged">
                            <asp:ListItem Enabled="False">Modelagem de Processos</asp:ListItem>
                            <asp:ListItem Enabled="False">Engenharia de Software e Aplicações</asp:ListItem>
                            <asp:ListItem Enabled="False">Banco de Dados e Aplicações</asp:ListItem>
                            <asp:ListItem Enabled="False">Programação para Internet</asp:ListItem>
                            <asp:ListItem Enabled="False">Sistemas Integrados de Gestão e Aplicações</asp:ListItem>
                            <asp:ListItem Enabled="False">Projetos de Tecnologia da Informação II</asp:ListItem>
                            <asp:ListItem Enabled="False">Portfólio I - TG1</asp:ListItem>
                            <asp:ListItem Enabled="False">Portfólio II - TG2</asp:ListItem>
                            <asp:ListItem Selected="True">Todos</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:Button ID="btnRevisaoNotas" runat="server" Text="Pesquisar" class="wow bounceIn" data-wow-delay="0.5s" OnClick="btnRevisaoNotas_Click"/>
                    <br />
                    <div class="auto-style2">
                        <br />
                <asp:GridView ID="gvAAP" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Disciplina" />
                        <asp:BoundField DataField="Nota" DataFormatString="{0:n2}" HeaderText="Nota" />
                        <asp:BoundField DataField="Situacao" HeaderText="Situação" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
				</form>
				<div class="clearfix"></div>
				
			</div>
			
		</center>
	</div>
    <div class="clearfix"></div>
     <% Response.WriteFile("rodape.htm"); %>
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
