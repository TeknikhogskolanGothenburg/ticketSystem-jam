
# Ticket system architecture

## TicketShop

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

## Backoffice

* The Administrator is directed to the Home view. Here are four choises:

#### Events

* Here there are three choises:
1. Add Event. 
The EventAdd-actionresult is called posting an eventobject to the database. GetAllEvent-method is then called returning all events to the the Value- object.
2. Edit Event.
GetAllEvent returns all events in a dropdown list. Administrator selects which to edit and inserts changes in the textboxes. EventsUpdate is called, putting the changes in the database.
3. Delete Event.
GetAllEvent returns all events in a dropdown list. Administrator selects which to delete. On buttonclick DeleteEvents is called deleting it from the database. GetAllEvent then returns an updates list in the dropdown list.

#### EventDates

* Here are two choises:
1. Add TicketEventDate.
GetAllEvents is called, showing it in a dropdown list. GetAllVenues is called, showing it in a second dropdown list. A calender is added to the view. The Administrator then selects one item in every list. EventDatesAdd is then called, connecting all three to one TicketEventDate-object.
2. Delete TicketEventDate.
GetAllSummary is called, showing all TicketEventDate in the view. On buttonclick, selected row is deleted by calling RemoveTicketEventDate method. Then GetAllSummary is called again showing the updated list.

#### Venues

* Here there are three choises:
1. Add Venue.
A form appears that requests input to a Venue object. On click, AddVenues is called posting the object to the database. 
2. Edit Venue.
EditVenues is called, returning all venues in a dropdown list. Selected venue and an updated form, sends the object to the database replacing the former information to the new.
3. Delete Venue.
DeleteVenues is called requesting GetAllVenues, returning all venues to a dropdown list. Selected item is on buttonclick removed from the database by the DeleteVenues-request. GetAllVenues is then returning a fresh venuelist.

#### Customer

* Here there is one choice:
1. Find Customer.
The Administrator enters a string, representing the name, or part of the name. The querystring is then sent to the database through the GetCustomer method, returning all Customers, that has the string in their first or lastname.



## Which components does your application consist of?

See Docfx.


# Context diagram

<img src="images/context.png" />

# Container diagram

<img src="images/container.png" />

# Database

<img src="images/database_diagram.png" />
