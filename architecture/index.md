
# Ticket system architecture

* TicketShop

* The Program start in the HomeController with a Welcome greeting. The Customer clicks on Ticket, and the Ticket Actionresult is called that returns the Events in the view.
* For more information the Customer click on the Info- cell and ShowInfo-Actionresult is called returning the Description-property to the view.
* If there are more Events than is viewable on the screen, the Custumer can use the search-textbox, entering the event of interest, or part ov the name. On buttonclick Search, the Search-Actionresult is called, returning all events that has the input querystring in the EventName.

* The Customer chooses a ticket, and the Buy-buttonclick calls the Checkout-Actionresult, returning the Customers Ticketchoice in the Checkout-shoppingcart.

* The Customer has three choises:
1. Continue shopping, and the Ticket-Actionresult is called again returning to the Ticket-view.
2. Delete chosen ticket, and the DeleteTicketFromCart- actionresult is called, removing the ticket from the CartSummary-object.
3. Go to payment/Checkout, and the Customerinformation form appears, for addresslabel input by the Customer.

* When all textboxes are filled, the GoToPayment-actionresult is called. The method saves the Customerinfo in the database, then it loops all tickets saving the Event in the SeatsAtEventDate-table returning a seatID. It then takes thes seatID and enters the Tickets table, returning a TicketID. Finally it takes the TicketID and the TransationID (customerinfo) to the TicketToTransaction-table logging who purchased which ticket.
* The first iteration is then completed and the loop goes back repeating above with the rest of the tickets in the cart.

* When the method is done a sendEmail-function is called, sending an E-mail to the Customer, who is then returned to the Purchased Completed view, which shows a thankyou greeting on the screen. 




* Which components does your application consist of?

# Context diagram

<img src="images/context.png" />

# Container diagram

<img src="images/container.png" />

# Database

<img src="images/database_diagram.png" />
