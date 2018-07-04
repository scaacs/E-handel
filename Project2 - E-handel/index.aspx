<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project2___E_handel.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
         
        $(function () {
            
        });
        var totalPrice = 0;
        function AddToCart(itemNR, itemName, itemPrice) {
            var antal = $("#cart td:first-child").text();
            var isNotExisting = true;
            for (var i = 0; i < antal.length; i++) {
                if (antal[i] == itemNR) {
                    var antaltd = $("#cart tr").eq(i+1).children().eq(3).text();
                    var updatetd = (parseInt(antaltd))+1;
                    $("#cart tr").eq(i + 1).children().eq(3).text(updatetd);
                    isNotExisting = false;
                }
            }
            if (isNotExisting) {
                var removeButton = "<td><input type='button' value='Ta bort' onclick='RemoveItem("+itemNR+")'/></td>"
                 $("#cart tr:last-child").after("<tr><td>" + itemNR + "</td><td>" + itemName + "</td><td>" + itemPrice + "</td><td>1</td>"+ removeButton + "</tr>")
            }
           
            totalPrice += parseFloat(itemPrice);
            $("tfoot td:eq(1)").text(totalPrice + " kr");
        }

        function RemoveItem(nr) {
            var artikelID = $("#cart td:first-child").text();
            for (var i = 0; i < artikelID.length; i++) {
                if (artikelID[i] == nr) {
                    var row = $("#cart tr").eq(i + 1);
                    var subtractPrice = parseFloat((row.children().eq(2).text()));
                    var times = parseFloat((row.children().eq(3).text()));
                    totalPrice -= (subtractPrice * times);
                    row.remove();
                    $("tfoot td:eq(1)").text(totalPrice + " kr");
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-4">
                <div id="products" class="table table-hover">
                    <asp:Literal ID="Products" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="col-lg-4">
                <p style="padding:50px"></p>
            </div>
            <div class="col-lg-4">
                <div class="table">
                    <table>
                        <thead>
                            <tr><th colspan="5">Kundvagn</th></tr>     
                        </thead>
                        <tbody id="cart">
                            <tr><th>Artikelnummer</th><th>Produkt</th><th>à Pris</th><th>Antal</th></tr>
                        </tbody>
                        <tfoot>
                            <tr><td colspan="2">Totalsumma</td><td colspan="2"></td><td></td></tr>
                        </tfoot>
                        
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
