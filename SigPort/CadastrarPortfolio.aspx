<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastrarPortfolio.aspx.cs" Inherits="SigPort.CadastrarPortfolio" %>
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
           height: 627px;
           min-height: 300px;
           padding: 10px;
           background-color: #ffffff;
           border-radius: 8px;
           box-shadow: 2px 2px 29px 5px #222446;
       }
       .auto-style2 {
           height: 565px;
           width: 470px;
       }
   </style>
   <script type="text/javascript">
       //FUNÇÃO PARA TRAVAR OS CHECKBOXS ao selecionar 3 opções
           (function () {
               "use strict";
               var marcados = 0;
               var verifyCheckeds = function ($checks) { 
                   if (marcados >= 3) {
                       loop($checks, function ($element) {
                           $element.disabled = $element.checked ? '' : 'disabled';
                       });
                   } else {
                       loop($checks, function ($element) {
                           $element.disabled = '';
                       });
                   }
               };
               var loop = function ($elements, cb) {
                   var max = $elements.length;
                   while (max--) {
                       cb($elements[max]);
                   }
               }
               var count = function ($element) {
                   return $element.checked ? marcados + 1 : marcados - 1;
               }
               window.onload = function () {
              
                   var $checks = document.querySelectorAll('input[class="TravamentoChecks"]');
                   loop($checks, function ($element) {
                       $element.onclick = function () {
                           marcados = count(this);
                           verifyCheckeds($checks);
                       }
                       if ($element.checked) marcados = marcados + 1;
                   });
                   verifyCheckeds($checks);
               }
           } ());
           //FIM DA FUNÇÃO PARA TRAVAR OS CHECKBOXS ao selecionar 3 opções
    </script>
</head>
<body>
    <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
        <center>
		    <div class="auto-style1">
                <p class="descricaoForms">Selecione o TG e as AAps utilizadas</p>
			    <form id="form1" runat="server" style="margin-top: 4%;" class="auto-style2">
                <div style="clear:both;">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="Selecione o Portfólio:"></asp:Label>
                    <br />
                        <asp:DropDownList ID="ddlSelecionaPortfolio" runat="server" class="slcForms">
                            <asp:ListItem Enabled="False">Portfólio I - TG1</asp:ListItem>
                            <asp:ListItem Enabled="False">Portfólio II - TG2</asp:ListItem>
                            <asp:ListItem Selected="True">Selecione</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    </div>
                    <asp:Label ID="Label2" runat="server" Text="Selecione as AAPs (mínimo de 3)"></asp:Label>
                    <br />
                    <br />
                    <asp:CheckBox ID="cbModelagemDeProcessos" runat="server" Text="Modelagem de Processos" class="lblCadastrarPortFolio"/>
&nbsp;<br />
                    <asp:CheckBox ID="cbEngenhariaDeSoftware" runat="server" Text="Engenharia de Software e Aplicações" class="lblCadastrarPortFolio"/>
&nbsp;<br />
                    <asp:CheckBox ID="cbBancoDeDados" runat="server" Text="Banco de Dados e Aplicações" class="lblCadastrarPortFolio"/>
&nbsp;<br />
                    <asp:CheckBox ID="cbProgramacaoInternet" runat="server" Text="Programação para Internet" class="lblCadastrarPortFolio"/>
&nbsp;<br />
                    &nbsp;<asp:CheckBox ID="cbSistemasIntegrados" runat="server" Text="Sistemas Integrados de Gestão e Aplicações" class="lblCadastrarPortFolio"/>
                    <br />
                    &nbsp;<asp:CheckBox ID="cbProjetosTi2" runat="server" Text="Projetos de Tecnologia da Informação II" class="lblCadastrarPortFolio"/>
                    <br /><br />
                    <p class="descricaoForms" style="float: none;">Selecione o arquivo</p>
                    <br />
                   <!-- <asp:Button ID="btnCadastrarPortfolio2" class="btnRevisaoNotas" runat="server" Text="PortFólio 2"/>-->
                        <asp:FileUpload ID="fuArquivoRelatorio" runat="server" />
                    <br />
                    <br />
				    <br />
                    <asp:Button ID="btnCadastrarPortfolio1" class="btnRevisaoNotas" runat="server" Text="Enviar" OnClick="btnCadastrarPortfolio1_Click"/>
				</form>
		    </div>
		    <div class="clearfix"></div>
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
