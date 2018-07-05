<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Payment.aspx.cs" Inherits="Project2___E_handel.Payment" %>



<asp:Content ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <title>Betalning</title>

    <script>

</script>
    <link href="form-validation.css" rel="stylesheet">
</asp:Content>

<asp:Content ContentPlaceHolderID="main" runat="server">

    <div class="container">
        <div class="py-5 text-center">
            <h2>Betalning</h2>
            <p class="lead">Vänligen fyll i nedanstående information för att lägga en order till vårt kundlager.</p>
        </div>

        <div class="row">
            <div class="col-md-4 order-md-2 mb-4">
                <asp:Literal ID="numberOfItems" runat="server"></asp:Literal>
                <ul class="list-group mb-3">
                    <asp:Literal ID="cart" runat="server"></asp:Literal>
                </ul>

                <form class="card p-2">
                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="rabattkod">
                        <div class="input-group-append">
                            <button type="submit" class="btn btn-secondary">Lös in rabatt</button>
                        </div>
                    </div>
                </form>

            </div>
            <div class="col-md-8 order-md-1">
                <h4 class="mb-3">Faktureringsadress</h4>
                <form method="post" class="needs-validation" novalidate runat="server">
                    <input type="hidden" name="action" id="action" value="postOrder" />
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="firstName">Förnamn</label>
                            <input type="text" class="form-control" name="firstName" id="firstName" placeholder="" value="" required>
                            <div class="invalid-feedback">
                                Fyll i giltligt förnamn.
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="lastName">Efternamn</label>
                            <input type="text" class="form-control" id="lastName" placeholder="" value="" required>
                            <div class="invalid-feedback">
                                Fyll i giltligt efternamn.                  
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="username">Användarnamn</label>
                        <div class="input-group">
                            <div class="input-group-prepend">
                            </div>
                            <input type="text" class="form-control" id="username" placeholder="ditt_användarnamn" required>
                            <div class="invalid-feedback" style="width: 100%;">
                                Fyll i ditt användarnamn.
                            </div>
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="email">Email <span class="text-muted">(Optional)</span></label>
                        <input type="email" name="email" class="form-control" id="email" placeholder="du@till_exempel.com" required>
                        <div class="invalid-feedback">
                            Vänligen ange giltlig e-postadress för fraktspårning.
                        </div>
                    </div>

                    <div class="mb-3">
                        <label for="address">Address</label>
                        <input type="text" class="form-control" id="address" placeholder="Din gata 13" required>
                        <div class="invalid-feedback">
                            Vänligen ange fraktadress.
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-md-5 mb-3">
                            <label for="zip">Postadress</label>
                            <input type="text" class="form-control" id="zip" placeholder="111 11" required>
                            <div class="invalid-feedback">
                                Vänligen ange postadress.
                            </div>
                        </div>
                    </div>
                    <hr class="mb-4">
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="same-address">
                        <label class="custom-control-label" for="same-address">Fraktadressen är samma faktureringsadressen</label>
                    </div>
                    <div class="custom-control custom-checkbox">
                        <input type="checkbox" class="custom-control-input" id="save-info">
                        <label class="custom-control-label" for="save-info">Spara den här informationen till nästa gång</label>
                    </div>
                    <hr class="mb-4">

                    <h4 class="mb-3">Betalning</h4>

                    <div class="d-block my-3">
                        <div class="custom-control custom-radio">
                            <input id="credit" name="paymentMethod" type="radio" class="custom-control-input" checked required>
                            <label class="custom-control-label" for="credit">Kreditkort</label>
                        </div>
                        <div class="custom-control custom-radio">
                            <input id="debit" name="paymentMethod" type="radio" class="custom-control-input" required>
                            <label class="custom-control-label" for="debit">Debitkort</label>
                        </div>
                        <div class="custom-control custom-radio">
                            <input id="paypal" name="paymentMethod" type="radio" class="custom-control-input" required>
                            <label class="custom-control-label" for="paypal">PayPal</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="cc-name">Namn på kortet</label>
                            <input type="text" class="form-control" id="cc-name" placeholder="" required>
                            <small class="text-muted">Hela namnet som står skrivet på kortet</small>
                            <div class="invalid-feedback">
                                Name on card is required
                            </div>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="cc-number">Kreditkortnummer</label>
                            <input type="text" class="form-control" id="cc-number" placeholder="" required>
                            <div class="invalid-feedback">
                                kreditkortnumber krävs
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3 mb-3">
                            <label for="cc-expiration">Förfallodatum</label>
                            <input type="text" class="form-control" id="cc-expiration" placeholder="" required>
                            <div class="invalid-feedback">
                                Förfalldatum krävs
                            </div>
                        </div>
                        <div class="col-md-3 mb-3">
                            <label for="cc-cvv">CVV</label>
                            <input type="text" class="form-control" id="cc-cvv" placeholder="" required>
                            <div class="invalid-feedback">
                                Säkerhetskod(CVV) krävs
                            </div>
                        </div>
                    </div>
                    <hr class="mb-4">
                    <button class="btn btn-primary btn-lg btn-block" type="submit" id="payButton">Betala</button>
                </form>
            </div>
        </div>

        <footer class="my-5 pt-5 text-muted text-center text-small">
            <p class="mb-1">© 2018 Kontorsprylar AB</p>
        </footer>
    </div>

    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../assets/js/vendor/popper.min.js"></script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <script src="../../assets/js/vendor/holder.min.js"></script>
    <script>
            // Example starter JavaScript for disabling form submissions if there are invalid fields
            (function () {
                'use strict';

                window.addEventListener('load', function () {
                    // Fetch all the forms we want to apply custom Bootstrap validation styles to
                    var forms = document.getElementsByClassName('needs-validation');

                    // Loop over them and prevent submission
                    var validation = Array.prototype.filter.call(forms, function (form) {
                        form.addEventListener('submit', function (event) {
                            if (form.checkValidity() === false) {
                                event.preventDefault();
                                event.stopPropagation();
                            }
                            form.classList.add('was-validated');
                            alert("Order lagd!");
                            localStorage.clear();
                            open("index.aspx");
                            close("payment.aspx");
                        }, false);
                    });
                }, false);
            })();
    </script>
</asp:Content>
