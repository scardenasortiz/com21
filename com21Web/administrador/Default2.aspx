<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/master/AdCom21.master" CodeFile="Default2.aspx.cs" Inherits="administrador_Default2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<link rel="stylesheet" type="text/css" href="../css/stylespanel/styles.css" />
<script type="text/javascript" >
    $(function () {
        $('.dragbox')
	.each(function () {
	    $(this).hover(function () {
	        $(this).find('h2').addClass('collapse');
	    }, function () {
	        $(this).find('h2').removeClass('collapse');
	    })
		.find('h2').hover(function () {
		    $(this).find('.configure').css('visibility', 'visible');
		}, function () {
		    $(this).find('.configure').css('visibility', 'hidden');
		})
		.click(function () {
		    $(this).siblings('.dragbox-content').toggle();
		})
		.end()
		.find('.configure').css('visibility', 'hidden');
	});
        $('.column').sortable({
            connectWith: '.column',
            handle: 'h2',
            cursor: 'move',
            placeholder: 'placeholder',
            forcePlaceholderSize: true,
            opacity: 0.4,
            stop: function (event, ui) {
                $(ui.item).find('h2').click();
                var sortorder = '';
                $('.column').each(function () {
                    var itemorder = $(this).sortable('toArray');
                    var columnId = $(this).attr('id');
                    sortorder += columnId + '=' + itemorder.toString() + '&';
                });
                //alert('SortOrder: '+sortorder);
                /*Pass sortorder variable to server using ajax to save state*/
            }
        })
	.disableSelection();
    });

    function script2() {
        //document.getElementById("imgLOAD").style.display = "none";
        return confirm("Desea eliminar el usuario.");


    }
</script>
   <div class="demoarea" style="margin-left: 5px">
        <br />
        <div class="column" id="column1">
		<div class="dragbox" id="item1" >
			<h2>Usuarios Administradores</h2>
			<div class="dragbox-content" >
                <table style="width: 100%;">
                    <tr>
                        <td style="background-image: url('../images/fondogrid.jpg'); background-repeat: repeat-x; padding-left: 5px;">
                         <%-- <asp:Button ID="Button1" runat="server" 
            Text="Nuevo Usuario" onclick="Button1_Click" />--%>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:Com21ConnectionString %>" 
                                SelectCommand="SELECT * FROM [tbl_c_promopubli]"></asp:SqlDataSource>
                        </td>
                       
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                       
                    </tr>
                    
                </table>
                
        
        </div>
		</div>
        <div class="dragbox" id="item2" >
			<h2>Usuarios Logeados</h2>
			<div class="dragbox-content" >
				Información de todo los usuarios logeados actualmente en el CMS. 
                </div>
		</div>     
        <div class="dragbox" id="item3" >
			<h2>Handle 3</h2>
			<div class="dragbox-content" >
				Proin porttitor euismod condimentum. Integer suscipit nibh nec augue facilisis ut commodo nisi ornare. Nam sed mauris vitae justo convallis placerat. Curabitur viverra, ipsum id volutpat sollicitudin, mi nisi condimentum nulla, nec dapibus velit libero eget orci. Nam purus lectus, imperdiet pharetra pulvinar ac, sodales sit amet sem. Ut vel mollis ante. Vivamus consectetur varius risus eu hendrerit. Sed scelerisque euismod leo, quis accumsan justo venenatis eu. Ut risus lorem, aliquet id fermentum nec, auctor ut enim. Ut pretium elementum turpis vel dignissim. 
			</div>
		</div>
        </div>
        <div class="column" id="column2" >
		<div class="dragbox" id="item4" >
			<h2># Sesiones</h2>
			<div class="dragbox-content" >
			</div>
		</div>
		<div class="dragbox" id="item5" >
			<h2>Handle 5</h2>
			<div class="dragbox-content" >
				Nam rhoncus sodales libero, et facilisis nisi volutpat et. Nullam tellus eros, consequat eget tristique ultricies, rhoncus vitae magna. Duis nec scelerisque orci. Nullam a enim est, et eleifend nunc. Proin dui eros, vulputate eget consectetur quis, ultrices ac sem. Nulla aliquam metus eu magna placerat placerat. Suspendisse eget tellus turpis, et ultricies nisi. Etiam in diam mi, sed tincidunt eros. Phasellus convallis aliquam arcu, vitae fringilla quam pharetra sed. In at augue at nibh placerat feugiat at id elit. Curabitur sit amet quam ut turpis molestie blandit in vel nulla. 
			</div>
		</div>
	    </div>
    </div>
</asp:Content>
