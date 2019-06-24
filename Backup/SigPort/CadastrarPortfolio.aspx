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
   <style>.wow:first-child {visibility: hidden;}</style>
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
		    <div class="blocoFormularioRevisaoNotas">
                <p class="descricaoForms">Selecione 3 AAP'S e cadastre no PortFólio 1</p>
                <div style="clear:both;"></div>
			    <form id="form1" runat="server" style="margin-top: 4%;">
                    <input type="checkbox" value="Modelagem de Processos" class="TravamentoChecks" id="CheckModelagemProcessos" required/>
                    <asp:Label ID="lblModelagemProcessos" runat="server" Text="Modelagem de Processos" class="lblCadastrarPortFolio"></asp:Label><br />
                    <input type="checkbox" value="Engenharia de Software e Aplicações" class="TravamentoChecks" id="CheckEngenhariaSoftware" required/>
                    <asp:Label ID="lblEngenhariadeSoftwareAplicacoes" runat="server" Text="Engenharia de Software e Aplicações" class="lblCadastrarPortFolio"></asp:Label><br />
                    <input type="checkbox" value="Banco de Dados e Aplicações" class="TravamentoChecks" id="CheckBancodeDados" required/>
                    <asp:Label ID="lblBancodeDadoseAplicacoes" runat="server" Text="Banco de Dados e Aplicações" class="lblCadastrarPortFolio"></asp:Label><br />
                    <input type="checkbox" value="Programação para Internet" class="TravamentoChecks" id="CheckProgramacaoInternet" required/>
                    <asp:Label ID="lblProgramacaoParaInternet" runat="server" Text="Programação para Internet" class="lblCadastrarPortFolio"></asp:Label><br />
                    <input type="checkbox" value="Sistemas Integrados de Gestão e Aplicações" class="TravamentoChecks" id="CheckSistemasIntegrados" required/>
                    <asp:Label ID="lblSistemasIntegradosdeGestaoAplicacoes" runat="server" Text="Sistemas Integrados de Gestão e Aplicações" class="lblCadastrarPortFolio"></asp:Label><br />
                    <br /><br />
                    <asp:Button ID="btnCadastrarPortfolio1" class="btnRevisaoNotas" runat="server" Text="PortFólio 1"/>
                   <!-- <asp:Button ID="btnCadastrarPortfolio2" class="btnRevisaoNotas" runat="server" Text="PortFólio 2"/>-->
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
