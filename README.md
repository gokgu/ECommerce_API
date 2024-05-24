Onion Architecture, Code First and Swagger <br>
Read and Write Repositories <br>
CRUD operations for Customer, Product and Order <br> 
Service Layer, Service Registirations <br>
Mail Service <br>
Order Service <br>
SendCompletedOrderMail <br>

<strong>Introduction:</strong><br>
I set up the project according to Onion Architecture. I set the layers according to this architecture. I created Customer, Product and Order entities and created EcommerceAPIDb database and tables with Code-First migration commands. I wrote crud methods over Read and Write Repositories. I used IoC Container.<br>
<strong>Development:</strong><br>
I created Customers, Products and Orders Controller and performed request operations to db via swagger. I created the Mail Service structure. I checked the mail sending with smtp. I created the ‘Orders/SendCompletedOrderMail’ endpoint. I added the ‘IsOrdered’ bool variable to the Orders table and checked the ‘created order’ from the db. I filled the mail content by writing a query by taking the Customer and Product information about this order from the repository.<br>
<strong>Result:</strong><br>
I took a screenshot of the ‘Order created’ mail content. I both sent the changes in the code to github as I progressed and shared the mail content in the ReadMe file.<br>

<strong>Used Technologies:</strong> <br>
.Net 8.0 Web API <br>
MSSQL Database <br>
ORM Tool EntityFrameworkCore Code First Migration Commands <br>
* add-migration mig_1 <br>
* update-database <br>

An example of an email with the subject 'Your order has been placed' is shown in the screenshot below.
<br>
![Örnek Mail](https://github.com/gokgu/ECommerce_API/assets/15246646/57ad5756-94cc-4a61-91a8-fe801fc16622)
