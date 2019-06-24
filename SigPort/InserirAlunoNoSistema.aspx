<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InserirAlunoNoSistema.aspx.cs" Inherits="SigPort.InserirAlunoNoSistema" %>

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
           height: 21px;
       }
   </style>
   <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
</head>
<body>
     <% Response.WriteFile("topo.aspx"); %>
    <div class="containerPaginaInternas">
        <br /><br />
        <center>
            <form id="form1" runat="server" enctype="multipart/form-data">
                <div class="blocoFormularioRevisaoNotas" style="margin-top: 4%;">
                    <asp:Label ID="lblAvisoArquivoEnviado" runat="server" Text="" class="descricaoForms"></asp:Label>
                    <div class="clearfix"></div>
                    <p  style="text-align: center; float: none;" class="descricaoForms">Inserir alunos no sistema</p>
                    <p  style="text-align: center; float: none;" class="descricaoForms">&nbsp;</p>
                    <p  style="text-align: center; float: none;" class="descricaoForms">Padrão de nomenclatura de arquivos</p>
                    <p  style="text-align: center; float: none;" class="descricaoForms">&nbsp;</p>
                    <div class="clearfix">
                        <asp:Label ID="lblFormatoArquivo" runat="server"></asp:Label>
                        <br />
                        <br />
                    </div>
                    <asp:GridView ID="gvAlunosInserir" runat="server">
                    </asp:GridView>
                    <br />
                    <asp:FileUpload ID="fuListaAlunos" runat="server" />
                    <br />
                    <br />

                    <!-- INCÍCIO DO CÓDIGO ARRASTA E SOLTA -->

                    <asp:Label ID="lblMensagem" runat="server"></asp:Label>

                    <div id="dragandrophandler" class="auto-style1">
                    </div>
                    <div id="status1"></div>
                    <script>
                        function sendFileToServer(formData, status) {
                            var uploadURL = "http://hayageek.com/examples/jquery/drag-drop-file-upload/upload.php"; //Upload URL
                            var extraData = {}; //Extra Data.
                            var jqXHR = $.ajax({
                                xhr: function () {
                                    var xhrobj = $.ajaxSettings.xhr();
                                    if (xhrobj.upload) {
                                        xhrobj.upload.addEventListener('progress', function (event) {
                                            var percent = 0;
                                            var position = event.loaded || event.position;
                                            var total = event.total;
                                            if (event.lengthComputable) {
                                                percent = Math.ceil(position / total * 100);
                                            }
                                            //Set progress
                                            status.setProgress(percent);
                                        }, false);
                                    }
                                    return xhrobj;
                                },
                                url: uploadURL,
                                type: "POST",
                                contentType: false,
                                processData: false,
                                cache: false,
                                data: formData,
                                success: function (data) {
                                    status.setProgress(100);

                                    $("#status1").append("File upload Done<br>");
                                }
                            });

                            status.setAbort(jqXHR);
                        }

                        var rowCount = 0;
                        function createStatusbar(obj) {
                            rowCount++;
                            var row = "odd";
                            if (rowCount % 2 == 0) row = "even";
                            this.statusbar = $("<div class='statusbar " + row + "'></div>");
                            this.filename = $("<div class='filename'></div>").appendTo(this.statusbar);
                            getFileName(this.filename);
                            this.size = $("<div class='filesize'></div>").appendTo(this.statusbar);
                            this.progressBar = $("<div class='progressBar'><div></div></div>").appendTo(this.statusbar);
                            this.abort = $("<div class='abort'>Abort</div>").appendTo(this.statusbar);
                            obj.after(this.statusbar);

                            this.setFileNameSize = function (name, size) {
                                var sizeStr = "";
                                var sizeKB = size / 1024;
                                if (parseInt(sizeKB) > 1024) {
                                    var sizeMB = sizeKB / 1024;
                                    sizeStr = sizeMB.toFixed(2) + " MB";
                                }
                                else {
                                    sizeStr = sizeKB.toFixed(2) + " KB";
                                }

                                this.filename.html(name);
                                this.size.html(sizeStr);
                            }
                            this.setProgress = function (progress) {
                                var progressBarWidth = progress * this.progressBar.width() / 100;
                                this.progressBar.find('div').animate({ width: progressBarWidth }, 10).html(progress + "% ");
                                if (parseInt(progress) >= 100) {
                                    this.abort.hide();
                                }
                            }
                            this.setAbort = function (jqxhr) {
                                var sb = this.statusbar;
                                this.abort.click(function () {
                                    jqxhr.abort();
                                    sb.hide();
                                });
                            }
                        }
                        function handleFileUpload(files, obj) {
                            for (var i = 0; i < files.length; i++) {
                                var fd = new FormData();
                                fd.append('file', files[i]);

                                var status = new createStatusbar(obj); //Using this we can set progress.
                                status.setFileNameSize(files[i].name, files[i].size);
                                sendFileToServer(fd, status);

                            }
                        }
                        function getFileName(file_name) {
                            var filename = file_name;
                        }

                        $(document).ready(function () {
                            var obj = $("#dragandrophandler");
                            obj.on('dragenter', function (e) {
                                e.stopPropagation();
                                e.preventDefault();
                                $(this).css('border', '2px solid #0B85A1');
                            });
                            obj.on('dragover', function (e) {
                                e.stopPropagation();
                                e.preventDefault();
                            });
                            obj.on('drop', function (e) {

                                $(this).css('border', '2px dotted #0B85A1');
                                e.preventDefault();
                                var files = e.originalEvent.dataTransfer.files;

                                //We need to send dropped files to Server
                                handleFileUpload(files, obj);
                            });
                            $(document).on('dragenter', function (e) {
                                e.stopPropagation();
                                e.preventDefault();
                            });
                            $(document).on('dragover', function (e) {
                                e.stopPropagation();
                                e.preventDefault();
                                obj.css('border', '2px dotted #0B85A1');
                            });
                            $(document).on('drop', function (e) {
                                e.stopPropagation();
                                e.preventDefault();
                            });

                        });
                    </script>

                    <!-- FIM DO CÓDIGO ARRASTA E SOLTA -->

                    <br /><br />
                    <asp:Button ID="btnUpload" class="btnRevisaoNotas" runat="server" Text="Upload" 
                        onclick="btnUpload_Click" />
                    <asp:Button ID="btnInserir" class="btnRevisaoNotas" runat="server" 
                        Text="Inserir" onclick="btnInserir_Click" />
                    <div class="clearfix"></div>
                </div>
            </form>
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
