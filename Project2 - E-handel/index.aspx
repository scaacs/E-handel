<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Project2___E_handel.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>

        $(function () {
            $("#cart").html(localStorage.cart);
            $("tfoot").html(localStorage.footer);
            totalPrice = localStorage.sum ? parseFloat(localStorage.sum) : 0;

            $("#admin").click(function () {
                if ($("#password").val() == "abc123") {
                    open("Admin.aspx");
                    close("index.aspx");
                }
            });

            $("#pay").click(function () {
                var fullOrder = [];
                var productData = $("#cart td");
                for (var i = 0; i < productData.length; i++) {
                    var obj = { "itemNR": productData[i++].innerText, "itemName": productData[i++].innerText, "itemPrice": productData[i++].innerText, "itemQuant": productData[i++].innerText };
                    fullOrder.push(obj);
                }
                //fullOrder.push({ "totalPrice": totalPrice });
                var myJSON = JSON.stringify(fullOrder);
                $("#productInfo").val(myJSON);

                $("#target").submit();

                //$.ajax({
                //    method: "POST",
                //    url: "/Payment.aspx",
                //    data: { action: "addOrder", productInfo: myJSON }
                //}).done(function (data) {
                //    var incomming = JSON.parse(data);
                //    if (incomming.status == "ok") {
                //        alert("woohooo!");
                //        localStorage.clear();
                //        open("");
                //    }
                //    else {
                //        alert("Något gick fel");
                //    }
                //}).fail(function () {
                //    alert("Oj! Något gick fel!")
                //});

            });
        });
        var totalPrice = 0;

        function AddToCart(itemNR, itemName, itemPrice) {
            var antal = $("#cart td:first-child").text();
            var isNotExisting = true;
            for (var i = 0; i < antal.length; i++) {
                if (antal[i] == itemNR) {
                    var antaltd = $("#cart tr").eq(i + 1).children().eq(3).text();
                    var updatetd = (parseInt(antaltd)) + 1;
                    $("#cart tr").eq(i + 1).children().eq(3).text(updatetd);
                    isNotExisting = false;
                }
            }
            if (isNotExisting) {
                var removeButton = "<td><input type='button' value='Ta bort' onclick='RemoveItem(" + itemNR + ")'/></td>"
                $("#cart tr:last-child").after("<tr><td>" + itemNR + "</td><td>" + itemName + "</td><td>" + itemPrice + "</td><td>1</td>" + removeButton + "</tr>")
            }

            totalPrice += parseFloat(itemPrice);
            $("tfoot td:eq(1)").text(totalPrice + " kr");
            localStorage.cart = $("#cart").html();
            localStorage.footer = $("tfoot").html();
            localStorage.sum = totalPrice;
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
            localStorage.cart = $("#cart").html();
            localStorage.footer = $("tfoot").html();
            localStorage.sum = totalPrice;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <form method="post" id="target" action="Payment.aspx" runat="server">

        <input type="hidden" id="action" name="action" value="addOrder" />
        <input type="hidden" id="productInfo" name="productInfo" value="" />

        <div class="container">

            <div class="row">
                <div class="col-lg-5">
                    <div id="products" class="table table-hover">
                        <asp:Literal ID="Products" runat="server"></asp:Literal>
                    </div>
                </div>
                <div class="col-lg-2">
                    <p style="padding: 50px"></p>
                </div>
                <div class="col-lg-5">
                    <div class="table">
                        <table>
                            <thead>
                                <tr>
                                    <th colspan="5">Kundvagn</th>
                                </tr>
                            </thead>
                            <tbody id="cart">
                                <tr>
                                    <th>Artikelnummer</th>
                                    <th>Produkt</th>
                                    <th>à Pris</th>
                                    <th>Antal</th>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr>
                                    <td colspan="2">Totalsumma</td>
                                    <td colspan="2"></td>
                                    <td></td>
                                </tr>
                            </tfoot>
                        </table>
                        <br />
                        <input type="button" value="Betala" id="pay" style="margin-left: 375px" />
                    </div>
                </div>
            </div>
            <div class="row" style="margin-top: 150px">
                <div class="col-lg-8">
                </div>
                <div class="col-lg-4">
                    <input type="password" id="password" />
                    <input type="button" value="Admin" id="admin" />
                </div>
            </div>
        </div>
    </form>
</asp:Content>
